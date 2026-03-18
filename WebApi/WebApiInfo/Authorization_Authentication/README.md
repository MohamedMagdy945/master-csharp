# 🔐 Authentication & Authorization in .NET (JWT)

## 📌 Overview

This project demonstrates how **Authentication** and **Authorization** work in ASP.NET Core using **JWT (JSON Web Token)**.

---

## 🧠 Concepts

### 🔐 Authentication (AuthN)

Responsible for identifying the user.

* Decodes JWT Token
* Validates:

  * Signature
  * Expiration
* Creates:

```csharp
HttpContext.User
```

---

### 🔑 Authorization (AuthZ)

Responsible for checking permissions.

* Uses `HttpContext.User`
* Decides access based on:

  * Roles
  * Claims
  * Policies

---

## 🔄 Request Flow

```
Client Request
     ↓
UseAuthentication()
     ↓
Validate Token & Create User
     ↓
UseAuthorization()
     ↓
Check [Authorize]
     ↓
Allow / Deny
```

---

## ⚙️ Setup

### 1️⃣ Add Authentication

```csharp
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("SECRET_KEY"))
        };
    });
```

---

### 2️⃣ Add Authorization

```csharp
builder.Services.AddAuthorization();
```

---

### 3️⃣ Middleware

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

---

## 🔑 Generate JWT Token

```csharp
var claims = new List<Claim>
{
    new Claim(ClaimTypes.Name, "Ali"),
    new Claim(ClaimTypes.Role, "Admin")
};

var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes("SECRET_KEY"));

var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

var token = new JwtSecurityToken(
    claims: claims,
    expires: DateTime.Now.AddHours(1),
    signingCredentials: creds);

var jwt = new JwtSecurityTokenHandler().WriteToken(token);
```

---

## 🔐 Protect Endpoints

### Any Authenticated User

```csharp
[Authorize]
```

### Role-Based

```csharp
[Authorize(Roles = "Admin")]
```

### Policy-Based

```csharp
[Authorize(Policy = "AdminOnly")]
```

---

## ⚠️ Common Errors

* Missing `UseAuthentication()`
* Invalid Secret Key
* Token expired
* Missing "Bearer" prefix
* Role not included in claims

---

## 💡 Key Takeaways

* Authentication = **Who are you?**
* Authorization = **What can you do?**
* JWT carries **claims**
* `[Authorize]` checks permissions only

---

## 🚀 How to Use

1. Call `/login` → get JWT
2. Add header:

```
Authorization: Bearer YOUR_TOKEN
```

3. Access protected endpoints

---

## 📬 License

Free to use for learning purposes.
