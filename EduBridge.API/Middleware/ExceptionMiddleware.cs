using System;
using System.Net;
using EduBridge.API.Exceptions;
using EduBridge.API.Models.GenericResponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace EduBridge.API.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			this._next = next;
			this._logger = logger;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Something went wrong while processing {httpContext.Request.Path}");
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
		{
			httpContext.Response.ContentType = "application/json";
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

			ErrorResponse errorResponse = new ErrorResponse
			{
				ErrorMessage = $"{ex.Message}"
			};

			switch (ex)
			{
				case NotFoundException notFoundException:
					statusCode = HttpStatusCode.NotFound;
					break;

				default:
					break;
			}

			string response = JsonConvert.SerializeObject(errorResponse);
			httpContext.Response.StatusCode = (int)statusCode;
			return httpContext.Response.WriteAsync(response);
		}
	}
}

