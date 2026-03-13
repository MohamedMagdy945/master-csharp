# Entity Framework Core – Database First (Reverse Engineering)

## Overview

Database First (Reverse Engineering) is an approach in Entity Framework Core where entity classes and the DbContext are generated from an existing database.

Instead of creating the database from code, developers start with an existing database schema and generate the corresponding C# models automatically.

---

## How It Works
Entity Framework Core reads the database schema and generates:

- Entity classes that represent database tables
- A `DbContext` class to manage database access

This process is called **Scaffolding**.

---

## How It Works

In this approach, Entity Framework Core reads the structure of the database tables and automatically creates:

*Entity classes that represent the tables.
* A DbContext class that manages the database connection and entity sets.

This process is known as **scaffolding**.

---

## When to Use Database First

This approach is commonly used when:

*The database already exists.
* The database schema is managed by a separate team (such as a DBA).
* Working with legacy systems.
* Rapidly generating models from an existing database structure.

---
## Required Packages

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

## Reverse Engineering Command

```
dotnet ef dbcontext scaffold "Server=.;Database=YourDatabase;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

This command will:

* Connect to the database
* Read the database schema
* Generate entity classes
* Generate a DbContext

---

## Example with Custom DbContext Name

```
dotnet ef dbcontext scaffold "Server=.;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext
```

---

## Common Options

| Option             | Description                                |
| ------------------ | ------------------------------------------ |
| -o                 | Output folder for generated models         |
| -c                 | Specify DbContext name                     |
| --data-annotations | Use Data Annotations instead of Fluent API |
| --force            | Overwrite existing files                   |

Example:

```
dotnet ef dbcontext scaffold "Server=.;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext --data-annotations
```

---

## Advantages

* Fast model generation from existing databases
* Reduces manual coding
* Useful when working with legacy systems

---

## Limitations

* Less control over generated code
* Regenerating models may overwrite manual changes

---

## Summary

Database First in Entity Framework Core allows developers to generate entity classes and a DbContext from an existing database using the reverse engineering process.
