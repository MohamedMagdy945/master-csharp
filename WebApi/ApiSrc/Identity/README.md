# ASP.NET Core Identity Framework

## Overview

ASP.NET Core Identity is a membership system that adds login
functionality to ASP.NET Core applications.\
It provides authentication and authorization features such as user
registration, login, password management, roles, and claims.

------------------------------------------------------------------------

## Features

-   User Registration & Login
-   Password Hashing & Security
-   Role-based Authorization
-   Claims-based Authorization
-   External Logins (Google, Facebook, etc.)
-   Token generation (JWT)
-   Account Lockout & Security Policies

------------------------------------------------------------------------

## Architecture

Identity is built on top of:

-   Entity Framework Core
-   ASP.NET Core Middleware
-   Authentication Schemes

### Main Components:

-   UserManager`<TUser>`{=html} → Manage users
-   SignInManager`<TUser>`{=html} → Handle login/logout
-   RoleManager`<TRole>`{=html} → Manage roles

------------------------------------------------------------------------

## Setup

### 1. Install Packages

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

------------------------------------------------------------------------

### 2. Configure Services

builder.Services.AddIdentity\<ApplicationUser, IdentityRole\>()
.AddEntityFrameworkStores`<ApplicationDbContext>`{=html}()
.AddDefaultTokenProviders();

------------------------------------------------------------------------

### 3. Configure Middleware

app.UseAuthentication(); app.UseAuthorization();

------------------------------------------------------------------------

## Authentication vs Authorization

  Feature          Description
  ---------------- ----------------------------
  Authentication   Verifies who you are
  Authorization    Determines what you can do

------------------------------------------------------------------------

## Example

### Register User

var user = new ApplicationUser { UserName = model.Email }; var result =
await \_userManager.CreateAsync(user, model.Password);

------------------------------------------------------------------------

### Login

var result = await \_signInManager.PasswordSignInAsync( model.Email,
model.Password, false, false);

------------------------------------------------------------------------

## Security Features

-   Password Hashing
-   Email Confirmation
-   Two-Factor Authentication (2FA)
-   Account Lockout

------------------------------------------------------------------------

## Database Tables

-   AspNetUsers
-   AspNetRoles
-   AspNetUserRoles
-   AspNetUserClaims

------------------------------------------------------------------------

## Best Practices

-   Always use HTTPS
-   Enable password policies
-   Use JWT for APIs
-   Avoid storing sensitive data in claims

------------------------------------------------------------------------

## Conclusion

ASP.NET Core Identity is a powerful and flexible system for handling
authentication and authorization in modern web applications.
