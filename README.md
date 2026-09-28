# todolist

API de tarefas (To-Do List) em **C# / ASP.NET Core**, seguindo o paradigma **orientado a objetos**.
O front-end (`wwwroot/`) é o mesmo da versão em Java — só o back-end foi reescrito.

## Como executar

Requer o [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet run
```

Acesse http://localhost:8080 (a porta pode ser alterada com a variável `PORT`).

### Escolha do repositório

Equivalente aos perfis `memoria` / `jdbc` do Spring, definido pela chave `Repositorio` no `appsettings.json`:

- `banco` (padrão): persiste em SQLite no arquivo `data/tododb.db`
- `memoria`: guarda as tarefas apenas em memória

Também pode ser definido na execução:

```bash
Repositorio=memoria dotnet run
```

## Endpoints

| Método | Rota                 | Descrição                  |
|--------|----------------------|----------------------------|
| GET    | `/todos`             | Lista as tarefas           |
| POST   | `/todos`             | Cria uma tarefa            |
| PATCH  | `/todos/{id}/toggle` | Alterna concluída/pendente |
| DELETE | `/todos/{id}`        | Remove uma tarefa          |

## Estrutura (POO)

- `Models/Todo.cs` — entidade com atributos encapsulados e comportamentos (`AlternarStatus`, `PossuiTituloValido`)
- `Repositories/ITodoRepository.cs` — interface (abstração) implementada por `TodoRepositoryMemoria` e `TodoRepositorySqlite` (polimorfismo)
- `Services/TodoService.cs` — regras de negócio, recebe o repositório por injeção de dependência
- `Services/Exceptions/` — `TodoException` abstrata, herdada por `TituloInvalidoException` (400) e `TarefaNaoEncontradaException` (404)
- `Controllers/TodoController.cs` — endpoints REST
- `Config/` — tratamento global de exceções e escolha do repositório
