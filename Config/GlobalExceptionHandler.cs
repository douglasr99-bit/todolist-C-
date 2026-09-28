using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.Services.Exceptions;

namespace TodoList.Config;

// Equivalente ao @RestControllerAdvice: converte exceções de negócio em respostas HTTP.
public class GlobalExceptionHandler : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TodoException excecao)
        {
            context.Result = new ObjectResult(new Dictionary<string, string> { ["erro"] = excecao.Message })
            {
                StatusCode = excecao.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}
