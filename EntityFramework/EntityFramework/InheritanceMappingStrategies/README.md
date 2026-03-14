# Entity Framework Core – Inheritance Mapping Strategies

## Overview

**Inheritance mapping** in Entity Framework Core (EF Core) allows a class hierarchy in the object-oriented model to be represented in a relational database.

EF Core supports multiple strategies to map inheritance structures between entities and database tables.

---

## 1️⃣ Table Per Hierarchy (TPH)

Table Per Hierarchy is the **default inheritance strategy in EF Core**.

In this approach:

- All classes in the inheritance hierarchy are stored in **a single table**.
- A **discriminator column** is used to identify which type each row represents.

### Characteristics

- Only **one table** for the entire hierarchy
- Uses a **Discriminator column**
- Some columns may contain **NULL values** for unrelated types
- Generally **fast for queries** because it avoids joins

### Advantages

- Simpler schema
- Better query performance
- Fewer joins

### Disadvantages

- Table may contain many nullable columns
- Less strict normalization

---

## 2️⃣ Table Per Type (TPT)

In the Table Per Type strategy:

- Each class in the inheritance hierarchy has **its own table**
- Derived tables reference the base table using **foreign keys**

### Characteristics

- Base class properties stored in **base table**
- Derived class properties stored in **separate tables**
- Queries require **JOIN operations**

### Advantages

- Cleaner and more normalized database structure
- No unnecessary nullable columns

### Disadvantages

- Queries can be slower due to multiple joins
- More complex schema

---

## 3️⃣ Table Per Concrete Type (TPC)

Table Per Concrete Type maps each **concrete class** to its **own table**, including all inherited properties.

### Characteristics

- No table for abstract base classes
- Each concrete entity contains **all inherited columns**
- No joins required for derived types

### Advantages

- Queries are often faster than TPT
- No discriminator column needed

### Disadvantages

- Data duplication across tables
- Schema maintenance may be more complex

---

## 4️⃣ Choosing a Strategy

Each strategy has trade-offs between **performance**, **schema clarity**, and **normalization**.

| Strategy | Tables | Joins | Nullable Columns | Performance |
|--------|--------|--------|--------|--------|
| TPH | Single table | None | Possible | Fast |
| TPT | Multiple tables | Required | Minimal | Slower |
| TPC | Separate tables per concrete type | None | None | Medium |

---

## 5️⃣ Key Points

- **TPH** is the default and most commonly used strategy.
- **TPT** is useful when strict database normalization is required.
- **TPC** is useful when avoiding joins is important and duplication is acceptable.
- EF Core internally manages inheritance mapping using **model metadata** inside the `DbContext`.

---

## Summary

Inheritance mapping strategies allow EF Core to represent object-oriented inheritance in relational databases.

The choice between **TPH, TPT, and TPC** depends on:

- Database design requirements
- Query performance considerations
- Schema complexity