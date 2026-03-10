## Projection in LINQ

**Projection** is the process of **transforming each element of a collection** into a new form.  
It allows you to **select specific properties, create new objects, or shape the data** in a way that suits your needs.

---

### Key Points

- Projection is used to **change the type or structure of elements** in a collection.
- It does **not modify the original data**, it creates a new sequence.
- Commonly used when you want **only part of the data** or a **different representation**.

---

### Common Methods for Projection

- `Select` – transforms each element into a new form.  
- `SelectMany` – flattens nested collections into a single sequence.

---

### Why Projection Is Important

- Reduces memory usage by selecting only what you need.  
- Creates **DTOs (Data Transfer Objects)** or anonymous types.  
- Makes queries **readable and expressive**.  
- Helps in **preparing data for display or further processing**.

---

### Example Concepts (No Code)

1. **Selecting specific properties:** Extract only certain fields from objects.  
2. **Creating new objects:** Project each element into a new class or structure.  
3. **Flattening collections:** Convert a collection of collections into a single sequence.  

---

**Tip:** Projection is a **core concept in LINQ** and is often combined with **filtering (`Where`) and sorting (`OrderBy`)** for powerful data queries.