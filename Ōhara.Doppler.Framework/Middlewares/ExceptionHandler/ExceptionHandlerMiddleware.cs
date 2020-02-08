using System;
using System.Net;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Ōhara.Doppler.Framework.Middlewares.ExceptionHandler.DTOs;

namespace Ōhara.Doppler.Framework.Middlewares.ExceptionHandler
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context /* Other Dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 If Unexpected

            if (exception.GetType().Name.Contains("Invalid")) code = HttpStatusCode.BadRequest;

            var result = MessagePackSerializer.Serialize(new RequestErrorRequestOutputDto
            {
                Message = exception.Message,
                IsSuccessful = false,
                ExceptionStatusCode = Convert.ToInt16(exception.Data["ExceptionStatusCode"])
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(MessagePackSerializer.ConvertToJson(result));
        }
    }
}