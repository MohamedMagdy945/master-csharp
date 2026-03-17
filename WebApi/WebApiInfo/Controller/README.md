# ASP.NET Core Controller - Educational Notes

This README explains the basics of Controllers in **ASP.NET Core Web API** projects.

---

# 1. What is a Controller

A Controller is a class responsible for:

* Receiving HTTP requests from clients
* Processing logic
* Returning HTTP responses

It acts as a bridge between **Client** and **Database**.

```
Client → Controller → Database → Response
```

---

# 2. Creating a Basic Controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    AppDbContext dbContext = new AppDbContext();

    [HttpGet]
    public IActionResult ShowAll()
    {
        var departments = dbContext.Departments.ToList();
        return Ok(departments);
    }
}
```

---

# 3. Key Components

## 3.1 [ApiController] Attribute

* Marks the class as an API Controller
* Enables automatic model validation and binding

## 3.2 [Route] Attribute

* Defines the URL route to access this controller
* `[controller]` is replaced with the controller's class name minus 'Controller'

Example:

```
DepartmentController → /api/department
```

---

# 4. Action Methods

## GET - Retrieve all records

```csharp
[HttpGet]
public IActionResult ShowAll() { ... }
```

* URL: `GET /api/department`

## GET by ID

```csharp
[HttpGet("{id}")]
public IActionResult GetById(int id) { ... }
```

* URL: `GET /api/department/1`

## POST - Create record

```csharp
[HttpPost]
public IActionResult Add(Department department) { ... }
```

* URL: `POST /api/department`
* Request Body:

```json
{
  "name":"IT"
}
```

## PUT - Update record

```csharp
[HttpPut("{id}")]
public IActionResult Update(int id, Department department) { ... }
```

## DELETE - Remove record

```csharp
[HttpDelete("{id}")]
public IActionResult Delete(int id) { ... }
```

---

# 5. Common HTTP Status Codes

| Code | Meaning               |
| ---- | --------------------- |
| 200  | OK                    |
| 201  | Created               |
| 204  | No Content            |
| 400  | Bad Request           |
| 404  | Not Found             |
| 500  | Internal Server Error |

---

# 6. Controller Request Flow

```
Client
   ↓
HTTP Request
   ↓
Routing
   ↓
Controller
   ↓
Database
   ↓
HTTP Response
```

---

# Summary

Controllers handle all HTTP requests in ASP.NET Core APIs. Understanding controllers is essential for building functional Web APIs.

---

*Educational project notes by Mohamed Magdy*
