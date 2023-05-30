using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RestoAppAPI.Modal;
using RestoAppAPI.Repository;

namespace RestoAppAPI.Middlewares
{
    public class ExceptionMiddlewareADO
    {
       
        private readonly RequestDelegate _requestDelegate;
        

        public ExceptionMiddlewareADO(RequestDelegate requestDelegate)        
        {
           
            _requestDelegate = requestDelegate;
          
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate.Invoke(httpContext);
            }
            catch (System.Exception ex) 
            {
                   using (var scope = httpContext.RequestServices.CreateScope())
                    {
                        // Resolve IExceptionLogRepository from the scope
                        var exceptionLogRepository = scope.ServiceProvider.GetRequiredService<IExceptionLogRepository>();

                      // Other middleware logic...
                      
                    
                        ExceptionModal exception= new ExceptionModal(){
                            LineNumber = int.Parse( ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(":line ") + 6)),
                            MethodName= ex.TargetSite.Name,
                            ClassName = ex.TargetSite.DeclaringType.FullName,
                            StackTrace=  ex.StackTrace,
                            ErrorMessage = ex.Message
                        };
                        exceptionLogRepository.log(exception);
                          httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";

                    await httpContext.Response.WriteAsJsonAsync(exception);
                    }
                   
            }

        }
    }
}