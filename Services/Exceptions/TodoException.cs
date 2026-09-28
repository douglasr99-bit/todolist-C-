namespace TodoList.Services.Exceptions;

// Classe base abstrata: cada exceção de negócio define seu próprio status HTTP (polimorfismo).
public abstract class TodoException : Exception
{
    protected TodoException(string mensagem) : base(mensagem)
    {
    }

    public abstract int StatusCode { get; }
}
