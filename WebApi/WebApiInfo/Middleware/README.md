# Middleware in ASP.NET Core

## What is Middleware?
Middleware is a component in ASP.NET Core that handles HTTP requests and responses in a pipeline.

Each middleware:
- Receives an HTTP request
- Can process it
- Either passes it to the next middleware or stops the pipeline
- Can also modify the response on the way back

---

## Middleware Pipeline

ASP.NET Core processes requests using a pipeline of middleware components.

Execution flow:
1. Request enters the pipeline
2. Each middleware runs in order
3. Response travels back through the same middleware (in reverse order)

---

## How Middleware Works

Each middleware has:
- Request logic (before calling next)
- Optional call to the next middleware
- Response logic (after next middleware)

---

## Types of Middleware

### 1. Built-in Middleware
Provided by ASP.NET Core:
- Routing
- Authentication
- Authorization
- Static Files
- CORS

### 2. Custom Middleware
You can create your own middleware to:
- Log requests
- Handle exceptions
- Modify headers
- Validate requests

---

## Middleware Ordering (VERY IMPORTANT)

Order defines behavior.

Typical order:
1. Exception Handling
2. HTTPS Redirection
3. Static Files
4. Routing
5. Authentication
6. Authorization
7. Endpoints

Wrong order may cause:
- Authentication not working
- Authorization failing
- Routes not matching

---

## Short-Circuiting

Middleware can stop the pipeline:
- If it does NOT call next middleware
- The request ends immediately

Used in:
- Authentication failures
- Custom validation
- Error handling

---

## Request and Response Flow

Request:
Client → Middleware 1 → Middleware 2 → Controller

Response:
Controller → Middleware 2 → Middleware 1 → Client

---

## Why Middleware is Important

- Central place for cross-cutting concerns
- Improves code reuse
- Keeps controllers clean
- Handles security, logging, and performance

---

## Common Use Cases

- Logging requests and responses
- Authentication and authorization
- Exception handling
- Performance monitoring
- Request validation

---

## Summary

Middleware is the backbone of ASP.NET Core request handling.
It allows you to build a flexible and powerful pipeline to control how requests and responses are processed.
