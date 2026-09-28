using Microsoft.Data.Sqlite;
using TodoList.Models;

namespace TodoList.Repositories;

// Equivalente ao TodoRepositoryJdbc: acesso ao banco via ADO.NET (o "JDBC" do .NET).
public class TodoRepositorySqlite : ITodoRepository
{
    private const string Schema = @"
        CREATE TABLE IF NOT EXISTS todos (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            title VARCHAR(255) NOT NULL,
            weekday VARCHAR(20) NOT NULL,
            priority VARCHAR(10),
            completed BOOLEAN
        );";

    private readonly string _connectionString;

    public TodoRepositorySqlite(string connectionString)
    {
        _connectionString = connectionString;
        CriarTabela();
    }

    public Todo Salvar(Todo todo)
    {
        const string sql = @"INSERT INTO todos (title, weekday, priority, completed)
                             VALUES ($title, $weekday, $priority, $completed)
                             RETURNING id";

        using SqliteConnection conexao = AbrirConexao();
        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;
        comando.Parameters.AddWithValue("$title", todo.Title);
        comando.Parameters.AddWithValue("$weekday", todo.Weekday);
        comando.Parameters.AddWithValue("$priority", (object?)todo.Priority ?? DBNull.Value);
        comando.Parameters.AddWithValue("$completed", todo.Completed);

        todo.Id = Convert.ToInt32(comando.ExecuteScalar());
        return todo;
    }

    public List<Todo> ListarTodos()
    {
        const string sql = "SELECT * FROM todos";

        using SqliteConnection conexao = AbrirConexao();
        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;

        return LerTarefas(comando);
    }

    public void AtualizarStatus(int id, bool completed)
    {
        const string sql = "UPDATE todos SET completed = $completed WHERE id = $id";

        using SqliteConnection conexao = AbrirConexao();
        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;
        comando.Parameters.AddWithValue("$completed", completed);
        comando.Parameters.AddWithValue("$id", id);
        comando.ExecuteNonQuery();
    }

    public void Remover(int id)
    {
        const string sql = "DELETE FROM todos WHERE id = $id";

        using SqliteConnection conexao = AbrirConexao();
        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;
        comando.Parameters.AddWithValue("$id", id);
        comando.ExecuteNonQuery();
    }

    public Todo? BuscarPorId(int id)
    {
        const string sql = "SELECT * FROM todos WHERE id = $id";

        using SqliteConnection conexao = AbrirConexao();
        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = sql;
        comando.Parameters.AddWithValue("$id", id);

        return LerTarefas(comando).FirstOrDefault();
    }

    private SqliteConnection AbrirConexao()
    {
        var conexao = new SqliteConnection(_connectionString);
        conexao.Open();
        return conexao;
    }

    private void CriarTabela()
    {
        using SqliteConnection conexao = AbrirConexao();
        using SqliteCommand comando = conexao.CreateCommand();
        comando.CommandText = Schema;
        comando.ExecuteNonQuery();
    }

    private static List<Todo> LerTarefas(SqliteCommand comando)
    {
        var tarefas = new List<Todo>();

        using SqliteDataReader leitor = comando.ExecuteReader();
        while (leitor.Read())
        {
            tarefas.Add(MapearTarefa(leitor));
        }
        return tarefas;
    }

    private static Todo MapearTarefa(SqliteDataReader leitor)
    {
        return new Todo(
            id: leitor.GetInt32(leitor.GetOrdinal("id")),
            title: leitor.GetString(leitor.GetOrdinal("title")),
            weekday: leitor.GetString(leitor.GetOrdinal("weekday")),
            priority: leitor.IsDBNull(leitor.GetOrdinal("priority")) ? null : leitor.GetString(leitor.GetOrdinal("priority")),
            completed: !leitor.IsDBNull(leitor.GetOrdinal("completed")) && leitor.GetBoolean(leitor.GetOrdinal("completed"))
        );
    }
}
