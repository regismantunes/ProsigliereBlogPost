﻿using System.Net;
using System.Text.Json;

namespace ProsigliereBlogPost.Api.Extensions
{
    internal static class HttpResponseExtensions
    {
        public static async Task SendErrorMessageAsync(this HttpResponse response, HttpStatusCode httpStatus, string message)
        {
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatus;
            
            await response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
        }
    }
}
