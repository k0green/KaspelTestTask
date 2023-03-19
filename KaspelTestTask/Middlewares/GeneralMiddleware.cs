﻿namespace KaspelTestTask.Middleware;

public class GeneralMiddleware
{
    private readonly RequestDelegate _next;

    public GeneralMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Resource error"); 
        }
    }
}