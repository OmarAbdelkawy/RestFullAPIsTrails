using BasicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicAPI.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        public JsonExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            var err = new ApiError();
            if (_env.IsDevelopment())
            {
                err.Message = context.Exception.Message;
                err.Details = context.Exception.StackTrace;
            }
            else
            {
                err.Message = "error occured in server";
                err.Details = context.Exception.Message;
            }
            context.Result = new ObjectResult(err)
            {
                StatusCode = 500
            };

        }
    }
}
