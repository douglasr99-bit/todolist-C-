using TodoList.Models;

namespace TodoList.Repositories;

public class TodoRepositoryMemoria : ITodoRepository
{
    private readonly List<Todo> _tarefas = new();

    private readonly object _trava = new();

    private int _proximoId = 1;


    public Todo Salvar(Todo todo)
    {
        lock (_trava)
        {
            todo.Id = _proximoId;
            _proximoId++;
            _tarefas.Add(todo);
            return todo;
        }
    }

    public List<Todo> ListarTodos()
    {
        lock (_trava)
        {
            return new List<Todo>(_tarefas);
        }
    }

    public void AtualizarStatus(int id, bool completed)
    {
        lock (_trava)
        {
            Todo? todo = _tarefas.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.Completed = completed;
            }
        }
    }

    public void Remover(int id)
    {
        lock (_trava)
        {
            _tarefas.RemoveAll(t => t.Id == id);
        }
    }

    public Todo? BuscarPorId(int id)
    {
        lock (_trava)
        {
            return _tarefas.FirstOrDefault(t => t.Id == id);
        }
    }
}
