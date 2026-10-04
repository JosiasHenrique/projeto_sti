using CadastroVeiculos.Data;
using CadastroVeiculos.Models;
using Dapper;

namespace CadastroVeiculos.Repositories;

public class VeiculoRepository
{
    private readonly ConexaoFactory _factory = ConexaoFactory.GetInstance();
    private const string Colunas = "Id, Placa, Marca, Modelo, Cor, Ano, Porte, TipoCarga, Chassis";

    public List<Veiculo> ListarTodos()
    {
        using var conexao = _factory.CriarConexao();
        string sql = $"SELECT {Colunas} FROM Veiculos ORDER BY Placa";
        return conexao.Query<Veiculo>(sql).ToList();
    }

    public List<Veiculo> Pesquisar(string termo)
    {
        using var conexao = _factory.CriarConexao();
        string sql = $"SELECT {Colunas} FROM Veiculos WHERE Placa LIKE @Termo OR Modelo LIKE @Termo ORDER BY Placa";
        return conexao.Query<Veiculo>(sql, new { Termo = $"%{termo}%" }).ToList();
    }

    public Veiculo? BuscarPorId(int id)
    {
        using var conexao = _factory.CriarConexao();
        string sql = $"SELECT {Colunas} FROM Veiculos WHERE Id = @Id";
        return conexao.QueryFirstOrDefault<Veiculo>(sql, new { Id = id });
    }

    public void Inserir(Veiculo veiculo)
    {
        using var conexao = _factory.CriarConexao();
        string sql = @"INSERT INTO Veiculos (Placa, Marca, Modelo, Cor, Ano, Porte, TipoCarga, Chassis)
                       VALUES (@Placa, @Marca, @Modelo, @Cor, @Ano, @Porte, @TipoCarga, @Chassis)";
        conexao.Execute(sql, veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        using var conexao = _factory.CriarConexao();
        string sql = @"UPDATE Veiculos
                       SET Placa = @Placa, Marca = @Marca, Modelo = @Modelo, Cor = @Cor,
                           Ano = @Ano, Porte = @Porte, TipoCarga = @TipoCarga, Chassis = @Chassis
                       WHERE Id = @Id";
        conexao.Execute(sql, veiculo);
    }

    public void Excluir(int id)
    {
        using var conexao = _factory.CriarConexao();
        string sql = "DELETE FROM Veiculos WHERE Id = @Id";
        conexao.Execute(sql, new { Id = id });
    }

    public bool ExistePlaca(string placa, int idIgnorado = 0)
    {
        using var conexao = _factory.CriarConexao();
        string sql = "SELECT COUNT(*) FROM Veiculos WHERE Placa = @Placa AND Id <> @Id";
        return conexao.ExecuteScalar<int>(sql, new { Placa = placa, Id = idIgnorado }) > 0;
    }

    public bool ExisteChassis(string chassis, int idIgnorado = 0)
    {
        using var conexao = _factory.CriarConexao();
        string sql = "SELECT COUNT(*) FROM Veiculos WHERE Chassis = @Chassis AND Id <> @Id";
        return conexao.ExecuteScalar<int>(sql, new { Chassis = chassis, Id = idIgnorado }) > 0;
    }
}