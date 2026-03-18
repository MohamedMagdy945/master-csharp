# ASP.NET Core - HttpContext Complete Guide

## Overview

`HttpContext` in ASP.NET Core is the central object representing **all information about the current HTTP request and response**. It is accessible in Middleware, Filters, Controllers, and Razor Pages.

---

## 1. HttpContext Properties

| Property          | Type                          | Description                                                                                               |
| ----------------- | ----------------------------- | --------------------------------------------------------------------------------------------------------- |
| `Request`         | `HttpRequest`                 | Contains the incoming HTTP request information (path, headers, query, body)                               |
| `Response`        | `HttpResponse`                | Used to set status code, headers, and body for the response                                               |
| `User`            | `ClaimsPrincipal`             | Represents the currently authenticated user and their claims                                              |
| `Session`         | `ISession`                    | Stores per-user session data                                                                              |
| `Items`           | `IDictionary<object, object>` | Stores data for the lifetime of a single request (useful for sharing data between Middleware and Filters) |
| `Connection`      | `ConnectionInfo`              | Information about the network connection (IP, Port, Protocol)                                             |
| `TraceIdentifier` | `string`                      | Unique identifier for the current request for logging and diagnostics                                     |
| `Features`        | `IFeatureCollection`          | Low-level HTTP features provided by the server                                                            |

---

## 2. Accessing HttpContext

### 2.1 In Controllers

```csharp
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var ip = HttpContext.Connection.RemoteIpAddress;
        var user = HttpContext.User.Identity?.Name;
        return Ok(new { ClientIP = ip, User = user });
    }
}
```

### 2.2 In Middleware

```csharp
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request Path: {context.Request.Path}");
        await _next(context);
    }
}
```

### 2.3 In Filters

```csharp
public class MyActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
        Console.WriteLine("User Agent: " + userAgent);
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
```

---

## 3. Common Use Cases

1. **Authentication / Authorization**

```csharp
var isAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
```

2. **Access Request Data**

```csharp
var method = HttpContext.Request.Method;
var query = HttpContext.Request.Query["search"];
```

3. **Modify Response**

```csharp
HttpContext.Response.StatusCode = 404;
HttpContext.Response.Headers.Add("X-Custom", "Value");
```

4. **Sharing Data Across Middleware**

```csharp
HttpContext.Items["RequestStart"] = DateTime.UtcNow;
```

5. **Access Connection Info**

```csharp
var clientIp = HttpContext.Connection.RemoteIpAddress;
var protocol = HttpContext.Request.Protocol;
```

---

## 4. Lifecycle

* `HttpContext` exists **per request**.
* It is **created by the server (Kestrel/IIS)** when a request comes in.
* It is **disposed automatically** after the request is completed.
* Use `HttpContext.Items` for sharing temporary request-specific data.

---

# ASP.NET Core - HttpContext Properties Detailed Explanation

This document explains in detail each property inside `HttpContext` in ASP.NET Core.

---

## 1. Request

**Type:** `HttpRequest`
Contains all information about the incoming HTTP request.

**Key members:**

* `Path` → The requested URL path
* `Query` → Query string parameters
* `Headers` → HTTP headers collection
* `Body` → The request body stream
* `Method` → GET, POST, PUT, DELETE etc.

**Example:**

```csharp
var path = HttpContext.Request.Path;
var search = HttpContext.Request.Query["search"];
```

---

## 2. Response

**Type:** `HttpResponse`
Used to configure the HTTP response sent back to the client.

**Key members:**

* `StatusCode` → Set HTTP status code
* `Headers` → Add or modify response headers
* `Body` → Stream for writing response content

**Example:**

```csharp
HttpContext.Response.StatusCode = 404;
HttpContext.Response.Headers.Add("X-Custom", "Value");
```

---

## 3. User

**Type:** `ClaimsPrincipal`
Represents the currently authenticated user.

**Key members:**

* `Identity.IsAuthenticated` → true if authenticated
* `Claims` → List of user claims
* `Identity.Name` → Username or identifier

**Example:**

```csharp
var isAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
var username = HttpContext.User.Identity?.Name;
```

---

## 4. Session

**Type:** `ISession`
Stores per-user session data across multiple requests.

**Key members:**

* `SetString(key, value)` → store string value
* `GetString(key)` → retrieve string value
* Session expires after timeout

**Example:**

```csharp
HttpContext.Session.SetString("CartId", "12345");
var cartId = HttpContext.Session.GetString("CartId");
```

---

## 5. Items

**Type:** `IDictionary<object, object>`
Temporary storage for a single request. Useful for sharing data between middleware, filters, and controllers.

**Example:**

```csharp
HttpContext.Items["RequestStart"] = DateTime.UtcNow;
var start = HttpContext.Items["RequestStart"];
```

---

## 6. Connection

**Type:** `ConnectionInfo`
Information about the network connection.

**Key members:**

* `RemoteIpAddress` → Client IP
* `LocalIpAddress` → Server IP
* `RemotePort` → Client port
* `LocalPort` → Server port

**Example:**

```csharp
var clientIp = HttpContext.Connection.RemoteIpAddress;
var clientPort = HttpContext.Connection.RemotePort;
```

---

## 7. TraceIdentifier

**Type:** `string`
Unique identifier for the current request, useful for logging and diagnostics.

**Example:**

```csharp
var requestId = HttpContext.TraceIdentifier;
Console.WriteLine("Request ID: " + requestId);
```

---

## 8. Features

**Type:** `IFeatureCollection`
Provides access to low-level HTTP features offered by the server.

**Example:**

```csharp
var features = HttpContext.Features;
var connectionFeature = features.Get<IHttpConnectionFeature>();
```

---

**End of HttpContext Properties Detailed Guide**
