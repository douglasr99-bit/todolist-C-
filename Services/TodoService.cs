using TodoList.Models;
using TodoList.Repositories;
using TodoList.Services.Exceptions;

namespace TodoList.Services;

public class TodoService
{
    private readonly ITodoRepository _repository;


    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public Todo CriarTarefa(Todo todo)
    {
        if (!todo.PossuiTituloValido())
        {
            throw new TituloInvalidoException("título inválido");
        }
        return _repository.Salvar(todo);
    }

    public List<Todo> ListarTarefas()
    {
        return _repository.ListarTodos();
    }

    public void RemoverTarefa(int id)
    {
        BuscarTarefaExistente(id);
        _repository.Remover(id);
    }

    public void AlternarStatus(int id)
    {
        Todo tarefa = BuscarTarefaExistente(id);
        tarefa.AlternarStatus();
        _repository.AtualizarStatus(id, tarefa.Completed);
    }

    private Todo BuscarTarefaExistente(int id)
    {
        return _repository.BuscarPorId(id)
            ?? throw new TarefaNaoEncontradaException("tarefa não encontrada");
    }
}
