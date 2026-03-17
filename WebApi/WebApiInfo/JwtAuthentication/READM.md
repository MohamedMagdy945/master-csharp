# JWT Authentication in ASP.NET Core

This document is a comprehensive guide to **JWT (JSON Web Token) Authentication** in ASP.NET Core, including predefined claims, token structure, validation, and best practices.

---

## 1. Introduction

* **JWT Authentication** is a stateless authentication mechanism commonly used in web APIs.
* Tokens are issued after successful login and sent with each subsequent request for authorization.
* ASP.NET Core provides built-in support for JWT authentication via the `Microsoft.AspNetCore.Authentication.JwtBearer` package.

---

## 2. How JWT Authentication Works

1. **User Login**: Client sends credentials to the server.
2. **Token Issuance**: Server validates credentials and issues a JWT containing claims.
3. **Client Stores Token**: Usually in local storage or memory.
4. **Request with Token**: Client sends the token in the `Authorization` header as `Bearer <token>`.
5. **Token Validation**: Server validates signature, expiration, and claims for each request.
6. **Access Granted/Denied**: Based on token validity and claims.

---

## 3. JWT Structure

A JWT consists of three parts separated by dots:

```
Header.Payload.Signature
```

### 3.1 Header

* Contains metadata about the token type and signing algorithm.
* Example:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```

### 3.2 Payload (Claims)

* Contains the **claims**, which are statements about the user.
* Types of claims:

  * **Registered Claims** (standard): `iss`, `sub`, `aud`, `exp`, `nbf`, `iat`, `jti`
  * **Public Claims**: Can be defined by application but must avoid collisions.
  * **Private Claims**: Custom claims used internally.

**Example Payload:**

```json
{
  "sub": "1234567890",
  "name": "John Doe",
  "role": "Admin",
  "iat": 1615159072
}
```

### 3.3 Signature

* Created by combining the encoded header, payload, and a secret key using the algorithm specified in the header.
* Ensures **token integrity**.

---

## 4. Predefined / Registered Claims in JWT

| Claim | Description                                   |
| ----- | --------------------------------------------- |
| `iss` | Issuer of the token                           |
| `sub` | Subject (usually user id)                     |
| `aud` | Audience (who the token is intended for)      |
| `exp` | Expiration time                               |
| `nbf` | Not before (token not valid before this time) |
| `iat` | Issued at (time token was issued)             |
| `jti` | Unique identifier for the token               |

---

## 5. Implementing JWT Authentication in ASP.NET Core

### 5.1 Configure Services

```csharp
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});
```

### 5.2 Use Authentication & Authorization Middleware

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### 5.3 Protect Endpoints

```csharp
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { message = "Authenticated!" });

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult Post() => Ok(new { message = "Admin only!" });
}
```

---

## 6. Role-Based and Claims-Based Authorization

* **Role-Based**: Uses `role` claim in token to restrict access.
* **Claims-Based**: Checks specific claims for finer-grained access.

### Example of Custom Claim Authorization

```csharp
services.AddAuthorization(options => {
    options.AddPolicy("EmployeeOnly", policy =>
        policy.RequireClaim("EmployeeNumber"));
});

[Authorize(Policy = "EmployeeOnly")]
public IActionResult GetEmployeeData() { ... }
```

---

## 7. Token Validation

* The server validates:

  * Signature (integrity)
  * Expiration (`exp` claim)
  * Issuer (`iss`)
  * Audience (`aud`)
  * Optional custom claims
* If validation fails, the request is rejected with `401 Unauthorized`.

---

## 8. Security Best Practices

1. **Use HTTPS** to protect tokens in transit.
2. **Short-lived tokens** and **refresh tokens** for long sessions.
3. **Strong signing keys** (HS256, RS256).
4. **Validate all claims** you rely on.
5. **Store tokens safely** on the client (avoid localStorage for XSS-sensitive apps).
6. **Rotate keys periodically**.

---

## 9. Summary

* JWT Authentication is **stateless**, scalable, and widely used for APIs.
* Tokens carry **predefined and custom claims**.
* ASP.NET Core supports JWT natively with **middleware and validation**.
* Combine **role-based** and **claims-based authorization** for fine-grained security.

---

## References

* [Microsoft Docs: JWT Bearer Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwtbearer?view=aspnetcore-10.0)
* [JWT.io Introduction](https://jwt.io/introduction/)
* [RFC 7519 - JSON Web Token](https://tools.ietf.org/html/rfc7519)
