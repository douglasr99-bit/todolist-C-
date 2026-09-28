namespace TodoList.Services.Exceptions;

public class TarefaNaoEncontradaException : TodoException
{
    public TarefaNaoEncontradaException(string mensagem) : base(mensagem)
    {
    }

    public override int StatusCode => StatusCodes.Status404NotFound;
}
