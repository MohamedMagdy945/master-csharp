# Entity Framework Core – Relationships

## Overview

In **Entity Framework Core (EF Core)**, relationships define how entities are connected in the data model.  
EF Core supports three main types of relationships:

- **One-to-One (1:1)**
- **One-to-Many (1:N)**
- **Many-to-Many (N:N)**

Relationships are represented using **navigation properties** and **foreign keys (FKs)**. EF Core uses these at runtime for **queries, tracking, joins, cascade delete, and lazy loading**.

---

## 1️⃣ One-to-One (1:1)

- Each principal entity is associated with **exactly one dependent entity**.
- Can use **PK = FK** (dependent entity shares the primary key of principal) or **separate FK**.
- Example usage:
  - `Person` ↔ `PersonAddress`
- EF Core ensures FK integrity and supports **Include, SaveChanges, cascade delete**.

---

## 2️⃣ One-to-Many (1:N)

- One principal entity is related to **many dependent entities**.
- Common case: `Customer` ↔ `Orders`
- Navigation properties:
  - Principal: `ICollection<Order> Orders`
  - Dependent: `Customer Customer`
- EF Core uses FK in the dependent table for joins, tracking, and cascade delete.

---

## 3️⃣ Many-to-Many (N:N)

- Multiple entities on both sides can relate to multiple entities on the other side.
- EF Core 5+ supports **implicit join tables**.
- Example: `Student` ↔ `Course`
- EF Core creates **join table** automatically or can be defined explicitly.
- Supports **Include, tracking, and cascade rules**.

---

## 4️⃣ Navigation Properties

- Used to **navigate between related entities**.
- Enable **Include** queries for eager loading.
- Can support **lazy loading** if proxies are enabled.
- EF Core requires at least one navigation property per relationship for full tracking.

---

## 5️⃣ Foreign Keys (FK)

- Stored in the **dependent entity** pointing to the principal's primary key.
- EF Core can **infer FK automatically** using conventions (e.g., `PrincipalId`), or you can configure explicitly using `HasForeignKey`.
- FK is used for:
  - Joins in SQL queries
  - Change tracking
  - Maintaining referential integrity

---

## 6️⃣ EF Core Runtime Usage

EF Core uses relationship metadata for:

- **Include / JOIN**: Automatically generate SQL joins.
- **Change Tracking / SaveChanges**: Updates related entities and maintains FK.
- **Cascade Delete**: Deletes dependents automatically if configured.
- **Lazy Loading**: Loads related entities on demand.

---

## 7️⃣ Key Points

- Principal vs Dependent entities are identified in One-to-One and One-to-Many.
- Relationships can be **required** or **optional**.
- PK = FK simplifies One-to-One mapping.
- Separate FK provides flexibility for optional relationships or independent primary keys.
- Metadata for relationships is stored internally in `DbContext.Model` and used at runtime.

---

> Relationships in EF Core are **metadata-driven**, allowing the framework to handle queries, updates, and deletions automatically while maintaining consistency.