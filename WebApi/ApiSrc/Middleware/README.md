# ASP.NET Core Middleware - Complete Guide (Enhanced)

## What is Middleware?

Middleware in ASP.NET Core is a component assembled into a request-processing pipeline. Each middleware can:

* Inspect/modify the incoming HTTP request
* Decide whether to pass control to the next middleware
* Inspect/modify the outgoing HTTP response

> Think of it as a chain where each link can run logic **before** and **after** the next link.

---

## Visualizing the Pipeline

### High-level flow

```
Client
  |
  v
[Kestrel]
  |
  v
[Exception]
  |
  v
[Static Files]
  |
  v
[Routing]
  |
  v
[Authentication]
  |
  v
[Authorization]
  |
  v
[Endpoints (Controller/Minimal API)]
```

### Before/After execution model

```
Middleware A (before)
   |
   v
Middleware B (before)
   |
   v
Endpoint executes
   |
   v
Middleware B (after)
   |
   v
Middleware A (after)
```

---

## How Middleware Works Internally

Each middleware receives:

* `HttpContext` → request + response
* `RequestDelegate next` → the next component

### Execution pattern

* Code **before** `await next(context)` → runs on request
* Code **after** `await next(context)` → runs on response

---

## Built-in Middleware (Important Ones)

### 1. UseRouting()

Maps request to endpoint.

### 2. UseAuthentication()

* Reads token (JWT)
* Builds `User` (ClaimsPrincipal)

### 3. UseAuthorization()

* Checks permissions (policies/roles)

### 4. UseEndpoints()

* Executes controller or minimal API

### 5. UseStaticFiles()

* Serves files directly (short-circuit)

### 6. UseExceptionHandler()

* Global error handling

---

## Middleware Order (CRITICAL)

### Correct order example:

```
app.UseExceptionHandler("/error");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(...);
```

### Why?

* Authentication must come before Authorization
* Routing must come before Endpoints

---

## Short-Circuiting (Important Concept)

A middleware can stop the pipeline by NOT calling `next()`.

### Example:

```
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.ContainsKey("X-API-KEY"))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized");
        return; // STOP pipeline
    }

    await next();
});
```

---

## Creating Custom Middleware

### Step 1: Create Class

```
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request: {context.Request.Path}");

        await _next(context);

        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}
```

### Step 2: Register Middleware

```
app.UseMiddleware<LoggingMiddleware>();
```

---

## Inline Middleware (Shortcut)

```
app.Use(async (context, next) =>
{
    Console.WriteLine("Before");

    await next();

    Console.WriteLine("After");
});
```

---

## Middleware with JWT (Important for You)

### Flow:

```
Request with JWT
   |
   v
UseAuthentication()
   |
   v
Token validated
   |
   v
User Claims created
   |
   v
UseAuthorization()
```

### Example Config:

```
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
```

---

## Middleware vs Filters

| Feature         | Middleware  | Filters       |
| --------------- | ----------- | ------------- |
| Scope           | Global      | MVC only      |
| Runs Before MVC | Yes         | No            |
| Access          | HttpContext | ActionContext |

---

## Middleware vs DelegatingHandler

| Feature  | Middleware | DelegatingHandler |
| -------- | ---------- | ----------------- |
| Side     | Server     | Client            |
| Use case | API        | HttpClient        |

---

## Performance Tips

* Keep middleware lightweight
* Avoid DB calls inside middleware
* Use short-circuit wisely

---

## Common Mistakes

* Wrong order
* Forgetting `await next()`
* Putting business logic here

---

## Real Execution Scenario

```
Client → Kestrel
        → Middleware (Logging)
        → Routing
        → Authentication
        → Authorization
        → Controller
        → Response back through same middleware
```

---

## Final Summary

Middleware is the **core engine** of ASP.NET Core.

* Controls request/response lifecycle
* Built as a pipeline
* Order defines behavior
* Used for cross-cutting concerns

---

## Pro Tip 🔥

If you deeply understand middleware, you understand:

* Authentication flow
* Request lifecycle
* How ASP.NET Core actually works internally

And that’s a BIG level-up as a backend developer.
