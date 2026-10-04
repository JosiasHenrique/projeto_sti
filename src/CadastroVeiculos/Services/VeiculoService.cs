using CadastroVeiculos.Models;
using CadastroVeiculos.Repositories;
using MySqlConnector;

namespace CadastroVeiculos.Services;

public class VeiculoService
{
    private readonly VeiculoRepository _repository = new VeiculoRepository();

    public static readonly string[] Portes = { "Pequeno", "Medio", "Grande" };

    public List<Veiculo> ListarTodos()
    {
        return _repository.ListarTodos();
    }

    public List<Veiculo> Pesquisar(string? termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
        {
            return _repository.ListarTodos();
        }
        return _repository.Pesquisar(termo.Trim());
    }

    public Veiculo? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    public void Excluir(int id)
    {
        _repository.Excluir(id);
    }

    // Retorna os erros encontrados. Se a lista vier vazia, o veículo foi salvo.
    public Dictionary<string, string> Salvar(Veiculo veiculo)
    {
        Normalizar(veiculo);

        var erros = Validar(veiculo);
        if (erros.Count > 0)
        {
            return erros;
        }

        try
        {
            if (veiculo.Id == 0)
            {
                _repository.Inserir(veiculo);
            }
            else
            {
                _repository.Atualizar(veiculo);
            }
        }
        catch (MySqlException ex) when (ex.Number == 1062) // 1062 = registro duplicado
        {
            erros[""] = "Placa ou chassi já cadastrado em outro veículo.";
        }

        return erros;
    }

    private void Normalizar(Veiculo veiculo)
    {
        veiculo.Placa = veiculo.Placa.Trim().Replace("-", "").ToUpper();
        veiculo.Chassis = veiculo.Chassis.Trim().ToUpper();
        veiculo.Marca = veiculo.Marca.Trim();
        veiculo.Modelo = veiculo.Modelo.Trim();
        veiculo.Cor = veiculo.Cor.Trim();
        veiculo.TipoCarga = veiculo.TipoCarga.Trim();
    }

    private Dictionary<string, string> Validar(Veiculo veiculo)
    {
        var erros = new Dictionary<string, string>();

        int anoMaximo = DateTime.Now.Year + 1;
        if (veiculo.Ano > anoMaximo)
        {
            erros["Ano"] = $"O ano não pode ser maior que {anoMaximo}.";
        }

        if (!Portes.Contains(veiculo.Porte))
        {
            erros["Porte"] = "Selecione um porte válido.";
        }

        if (_repository.ExistePlaca(veiculo.Placa, veiculo.Id))
        {
            erros["Placa"] = "Já existe um veículo com esta placa.";
        }

        if (_repository.ExisteChassis(veiculo.Chassis, veiculo.Id))
        {
            erros["Chassis"] = "Já existe um veículo com este chassi.";
        }

        return erros;
    }
}