namespace TodoList.Services.Exceptions;

public class TituloInvalidoException : TodoException
{
    public TituloInvalidoException(string mensagem) : base(mensagem)
    {
    }

    public override int StatusCode => StatusCodes.Status400BadRequest;
}
