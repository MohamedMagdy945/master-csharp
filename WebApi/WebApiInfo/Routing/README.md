# ASP.NET Core Routing - Complete Guide

## What is Routing?

Routing in ASP.NET Core is the process of matching an incoming HTTP request to an endpoint (Controller, Action, or Minimal API).

---

## How Routing Works

### Flow:

```
Client Request
      |
      v
UseRouting()
      |
      v
Match URL to Endpoint
      |
      v
UseEndpoints()
      |
      v
Execute Controller / Action
```

---

## Types of Routing

### 1. Conventional Routing

```
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

### Explanation:

* controller → Controller name
* action → Method inside controller
* id → optional parameter

---

### 2. Attribute Routing (Most Important)

```
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() { }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) { }
}
```

---

## Route Parameters

```
[HttpGet("{id}")]
```

* id is dynamic value from URL

Example:

```
/api/products/5
```

---

## Optional Parameters

```
[HttpGet("{id?}")]
```

---

## Query String vs Route

### Route:

```
/api/products/5
```

### Query:

```
/api/products?id=5
```

---

## Route Constraints

```
[HttpGet("{id:int}")]
```

Other examples:

* int
* guid
* bool

---

## Route Order

Routing matches in order:

* Specific routes first
* General routes last

---

## Minimal API Routing

```
app.MapGet("/products", () => "All Products");

app.MapGet("/products/{id}", (int id) => $"Product {id}");
```

---

## Routing + Middleware

```
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
```

---

## Common Mistakes

* Forgetting UseRouting()
* Wrong route template
* Conflict between routes

---

## Real Example Flow

```
GET /api/products/10

→ UseRouting matches route
→ Controller = Products
→ Action = GetById
→ id = 10
```

---

## Summary

Routing is responsible for:

* Mapping URL to code
* Extracting parameters
* Deciding which endpoint runs

---

## Pro Tip 🔥

If routing is wrong → your API will never reach the controller.

So always debug routing first when request fails.
