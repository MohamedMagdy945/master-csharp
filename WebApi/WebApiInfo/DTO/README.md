# Data Transfer Objects (DTOs) in ASP.NET Core

This document explains **DTOs (Data Transfer Objects)**, their purpose, benefits, and best practices in ASP.NET Core applications.

---

## 1. What is a DTO?

* A **DTO** is a simple object that **carries data between processes**, such as between a client and a server.
* Usually contains **no business logic**.
* Helps **decouple internal domain models** from external API contracts.

**Example:**

```csharp
public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

---

## 2. Why Use DTOs?

1. **Decoupling**: Avoid exposing internal database or domain models.
2. **Security**: Prevent sensitive data from being sent to clients.
3. **Performance**: Transfer only necessary data.
4. **Validation**: Apply simple validation rules to incoming requests.

---

## 3. Common Scenarios

### Request DTOs

Represent data sent by clients to the API.

```csharp
public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}
```

### Response DTOs

Represent data sent from the API to clients.

```csharp
public class UserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

### Mapping

* Use libraries like [AutoMapper](https://automapper.org/) or manual mapping to convert between **entity models** and **DTOs**.

---

## 4. Best Practices

* **Keep DTOs simple**: Avoid methods or business logic.
* **Separate Request and Response DTOs**: Enhances security and clarity.
* **Use Validation Attributes**: e.g., `[Required]`, `[MaxLength(100)]` for request DTOs.
* **Mapping**: Use AutoMapper or manual mapping to prevent exposing internal structures.

---

## 5. Summary

* DTOs are **lightweight objects** for transferring data.
* They **decouple API contracts** from internal models.
* They **improve security, performance, and maintainability**.

---

## References

* [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0)
* [AutoMapper Documentation](https://automapper.org/)
