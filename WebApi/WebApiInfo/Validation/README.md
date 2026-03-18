# ASP.NET Core Validation - Complete Guide

## What is Validation?

Validation is the process of ensuring that incoming data is correct, safe, and meets business rules before processing it.

---

## Why Validation is Important

* Prevent invalid data from entering system
* Protect against bad requests
* Improve API reliability

---

## How Validation Works in ASP.NET Core

### Flow:

```
Client Request
      |
      v
Model Binding
      |
      v
Model Validation
      |
      v
ModelState
      |
      v
Controller Action
```

---

## Data Annotations (Most Common)

```
public class CreateProductDto
{
    [Required]
    public string Name { get; set; }

    [Range(1, 1000)]
    public decimal Price { get; set; }

    [StringLength(100)]
    public string Description { get; set; }
}
```

---

## Common Attributes

* [Required]
* [MaxLength]
* [MinLength]
* [Range]
* [EmailAddress]
* [Phone]

---

## ModelState

```
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```

---

## ApiController Behavior (Important)

If you use:

```
[ApiController]
```

ASP.NET Core automatically:

* Validates model
* Returns 400 BadRequest if invalid

No need for ModelState check manually.

---

## Example Request

```
POST /api/products
{
    "name": "",
    "price": -10
}
```

### Response:

```
400 Bad Request
{
    "errors": {
        "Name": ["The Name field is required."],
        "Price": ["The field Price must be between 1 and 1000."]
    }
}
```

---

## Custom Validation

### Create Custom Attribute

```
public class CustomValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        if (value.ToString() == "invalid")
            return new ValidationResult("Invalid value");

        return ValidationResult.Success;
    }
}
```

---

## FluentValidation (Advanced)

Instead of Data Annotations, you can use FluentValidation.

```
public class ProductValidator : AbstractValidator<CreateProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
```

---

## Validation vs Business Logic

| Validation      | Business Logic |
| --------------- | -------------- |
| Input rules     | System rules   |
| Required, Range | Complex rules  |

---

## Common Mistakes

* Forgetting [ApiController]
* Trusting client input
* Mixing validation with business logic

---

## Real Flow Example

```
POST Request
   |
   v
Model Binding
   |
   v
Validation Attributes
   |
   v
ModelState
   |
   v
Controller executes (only if valid)
```

---

## Summary

Validation ensures:

* Clean data
* Secure API
* Better user experience

---

## Pro Tip 🔥

Always validate at the API boundary before touching database.

Bad data in = broken system.
