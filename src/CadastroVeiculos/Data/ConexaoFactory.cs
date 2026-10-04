using System.Data;
using MySqlConnector;

namespace CadastroVeiculos.Data;

public sealed class ConexaoFactory
{
    private static ConexaoFactory? _instancia;

    private readonly string _connectionString;

    private ConexaoFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public static void Inicializar(string connectionString)
    {
        if (_instancia == null)
        {
            _instancia = new ConexaoFactory(connectionString);
        }
    }

    public static ConexaoFactory GetInstance()
    {
        if (_instancia == null)
        {
            throw new InvalidOperationException("ConexaoFactory não foi inicializada.");
        }
        return _instancia;
    }

    public IDbConnection CriarConexao()
    {
        return new MySqlConnection(_connectionString);
    }
}