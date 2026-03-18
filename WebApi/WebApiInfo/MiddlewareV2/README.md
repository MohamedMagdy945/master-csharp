# ASP.NET Core Middleware - Complete Guide (Advanced)

## What is Middleware?

Middleware is the core building block of ASP.NET Core request processing. It forms a pipeline where each component can handle, modify, or stop the request/response.

---

## Full Architecture (Deep Understanding)

```
Client (Browser / Postman)
        |
        v
   [IIS / Nginx]
        |
        v
   [Kestrel Server]
        |
        v
   Middleware Pipeline
        |
        v
   Endpoint (Controller / API)
```

### Important Insight 🔥

* IIS is just a reverse proxy
* Kestrel is the actual .NET web server

---

## Advanced Pipeline Diagram

```
→ Exception Middleware
   → Logging Middleware
      → Static Files (may STOP here)
         → Routing
            → CORS
               → Authentication
                  → Authorization
                     → Custom Middleware
                        → Endpoint
                     ← Custom Middleware
                  ← Authorization
               ← Authentication
            ← Routing
         ← Static Files
      ← Logging
← Exception
```

---

## Execution Model (Critical for Debugging)

```
Request Flow  ↓↓↓

Middleware A (Before)
    Middleware B (Before)
        Middleware C (Before)
            Endpoint
        Middleware C (After)
    Middleware B (After)
Middleware A (After)

Response Flow ↑↑↑
```

---

## Debugging Middleware (Real Scenario)

### Problem:

"Authorization not working"

### Debug Flow:

1. Check order:

```
UseAuthentication BEFORE UseAuthorization
```

2. Add logging middleware:

```
app.Use(async (context, next) =>
{
    Console.WriteLine($"User Authenticated: {context.User.Identity?.IsAuthenticated}");
    await next();
});
```

3. Check if token is parsed
4. Check claims exist

---

## Custom Middleware (Production-Level)

```
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Internal Server Error");
        }
    }
}
```

### Register:

```
app.UseMiddleware<ErrorHandlingMiddleware>();
```

---

## Middleware vs Real Life 🔥

Think of middleware like airport security:

* Passport check → Authentication
* Visa check → Authorization
* Baggage scan → Validation Middleware
* Boarding gate → Endpoint

---

## Kestrel vs IIS Flow

```
Client Request
    |
    v
IIS (Optional)
    |
    v
Kestrel (Always handles request)
    |
    v
Middleware Pipeline
```

### Key Idea:

* IIS forwards request to Kestrel
* Kestrel executes middleware

---

## Advanced Concepts

### 1. Branching Middleware

```
app.Map("/admin", adminApp =>
{
    adminApp.Use(async (ctx, next) =>
    {
        Console.WriteLine("Admin route");
        await next();
    });
});
```

---

### 2. Conditional Middleware

```
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.Use(async (ctx, next) =>
    {
        Console.WriteLine("API request");
        await next();
    });
});
```

---

### 3. Terminal Middleware

```
app.Run(async context =>
{
    await context.Response.WriteAsync("End of pipeline");
});
```

---

## Performance Deep Dive

* Each middleware = extra function call
* Avoid heavy logic
* Avoid database access
* Prefer caching middleware

---

## Common Production Mistakes

❌ Putting business logic in middleware
❌ Wrong order
❌ Forgetting next()
❌ Logging sensitive data

---

## Real Interview Questions 🔥

### Q: What happens if you don’t call next()?

➡️ Pipeline stops (short-circuit)

### Q: Difference between Use & Run?

➡️ Use → can call next
➡️ Run → terminal middleware

### Q: Where does Authentication happen?

➡️ Inside UseAuthentication middleware

---

## Final Summary

Middleware is:

* The backbone of ASP.NET Core
* Responsible for request lifecycle
* Ordered execution pipeline
* Key to authentication, logging, security

---

## Ultimate Pro Tip 💀

If you master middleware + authentication flow:

You basically understand 70% of ASP.NET Core internals.
