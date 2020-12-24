using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ParkerCodingTest.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ParkerCodingTest.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response
                .WriteAsync
                (JsonConvert.SerializeObject(
                    new ErrorResponseContract()
                    {
                        StatusCode = context.Response.StatusCode,
                        ErrorMessage = exception.Message
                    })
                );
        }
    }
}
