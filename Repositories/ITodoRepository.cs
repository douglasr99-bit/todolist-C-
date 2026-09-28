using TodoList.Models;

namespace TodoList.Repositories;

public interface ITodoRepository
{
    Todo Salvar(Todo todo);

    List<Todo> ListarTodos();

    void AtualizarStatus(int id, bool completed);

    void Remover(int id);

    Todo? BuscarPorId(int id);
}
