# Mapper and Performance in ASP.NET Core - Educational Notes

This README explains the concept of Object Mapping in ASP.NET Core, its usage, and performance considerations.

---

# 1. What is a Mapper

A Mapper is a tool or library that helps you convert one object type to another.

Common scenarios

 Entity → DTO (Data Transfer Object)
 DTO → Entity
 ViewModel → Entity

This is very useful in APIs where you don't want to expose your database entities directly.

---

# 2. Popular Mapper in .NET

AutoMapper is the most commonly used mapper in .NET projects.

### Installing AutoMapper via NuGet

```
Install-Package AutoMapper
```

### Basic Usage

```csharp
public class DepartmentDto {
    public int Id { get; set; }
    public string Name { get; set; }
}

 Create mapping configuration
var config = new MapperConfiguration(cfg = {
    cfg.CreateMapDepartment, DepartmentDto();
});

IMapper mapper = config.CreateMapper();

Department dept = new Department { Id = 1, Name = IT };
DepartmentDto dto = mapper.MapDepartmentDto(dept);
```

Now you have a DepartmentDto object from Department.

---

# 3. Mapper in Controller Example

```csharp
[HttpGet]
public IActionResult GetDepartments()
{
    var departments = dbContext.Departments.ToList();
    var dtoList = mapper.MapListDepartmentDto(departments);
    return Ok(dtoList);
}
```

 The API now returns DTOs instead of database entities.
 Helps hide sensitive data and keeps responses clean.

---

# 4. Performance Considerations

Mapping objects introduces additional processing. Here are some tips

### 4.1 Map Only What You Need

 Only include necessary fields in your DTO.
 Avoid mapping entire objects if you need only a few properties.

### 4.2 Use Projection with EF Core

 Instead of retrieving entities and then mapping

```csharp
var dtos = dbContext.Departments.ToList().Select(d = mapper.MapDepartmentDto(d));
```

 Use LINQ projection to map during the query

```csharp
var dtos = dbContext.Departments
    .Select(d = new DepartmentDto { Id = d.Id, Name = d.Name })
    .ToList();
```

 This reduces memory usage and improves performance.

### 4.3 Avoid Mapping Large Collections Unnecessarily

 If your database returns thousands of rows, consider paging.

### 4.4 AutoMapper Performance

 AutoMapper is fast, but mapping millions of objects can slow down.
 Profile and benchmark mapping in heavy-load scenarios.

---

# 5. Summary

 Use Mapper to convert entities to DTOs or other object types.
 Mapping improves security, clarity, and maintainability.
 For performance, map only required fields and use projections when possible.

Educational project notes by Mohamed Magdy
