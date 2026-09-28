using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("todos")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<Todo> Listar()
    {
        return _service.ListarTarefas();
    }

    [HttpPost]
    public Todo Criar([FromBody] Todo todo)
    {
        return _service.CriarTarefa(todo);
    }

    [HttpPatch("{id}/toggle")]
    public void AlternarStatus(int id)
    {
        _service.AlternarStatus(id);
    }

    [HttpDelete("{id}")]
    public void Remover(int id)
    {
        _service.RemoverTarefa(id);
    }
}
