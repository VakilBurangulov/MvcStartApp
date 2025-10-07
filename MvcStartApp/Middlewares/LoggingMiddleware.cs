using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
  
    /// <summary>
    ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
    /// </summary>
    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
  
    /// <summary>
    ///  Необходимо реализовать метод Invoke  или InvokeAsync
    /// </summary>
    public async Task InvokeAsync(HttpContext context, IRequestRepository repo)
    {
        var newRequest = new Request { Id = Guid.NewGuid(), Date = DateTime.Now, Url = $"http://{context.Request.Host.Value + context.Request.Path}"};
        
        // Для логирования данных о запросе используем свойста объекта HttpContext
        Console.WriteLine($"[{newRequest.Date}]: New request to {newRequest.Url}");
        
        await repo.AddRequest(newRequest);
      
        // Передача запроса далее по конвейеру
        await _next.Invoke(context);
    }
}