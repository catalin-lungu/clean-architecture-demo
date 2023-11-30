using Clean.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace webapi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate) 
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception) 
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch(exception) 
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            if(string.IsNullOrEmpty(result)) 
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }
            return context.Response.WriteAsync(result);

        }
    }
}
