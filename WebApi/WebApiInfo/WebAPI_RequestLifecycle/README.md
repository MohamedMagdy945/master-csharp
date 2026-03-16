# ASP.NET Core Web API Request Lifecycle

## Overview

This README explains in detail the lifecycle of an HTTP request in **ASP.NET Core Web API**.  
It covers the full journey from the moment a client sends a request until the server responds.

ASP.NET Core Web API follows **RESTful principles**, allowing clients to interact with resources over HTTP in a structured and stateless manner.

---

## 1. Request Arrival

- A client (browser, mobile app, or another service) sends an HTTP request.
- The request includes:
  - HTTP Method (GET, POST, PUT, DELETE)
  - URL / Endpoint
  - Headers (authentication, content-type, etc.)
  - Body (optional, usually JSON)
- The request arrives at the server’s network interface, typically on port 80 (HTTP) or 443 (HTTPS).

---

## 2. Kestrel Web Server

- ASP.NET Core uses **Kestrel** as its web server.
- Kestrel reads the raw HTTP request from the network and:
  - Parses HTTP headers, method, URL, and body
  - Creates an **HttpContext** object representing the request
  - Passes the HttpContext to the **ASP.NET Core middleware pipeline**

---

## 3. Middleware Pipeline

- Middleware are **components that process requests in sequence**.
- Common middleware functions:
  - Logging
  - Exception handling
  - HTTPS redirection
  - Authentication & Authorization
  - Routing
  - Response compression
- Each middleware can:
  - Process the request
  - Modify it
  - Short-circuit the pipeline and return a response immediately
- Requests flow **through middleware in order**, and responses flow **back in reverse order**.

---

## 4. Routing

- Routing determines **which endpoint (controller or minimal API method)** should handle the request.
- ASP.NET Core matches:
  - HTTP Method
  - URL pattern
- Example:
  - Request: `GET /api/products/1`
  - Endpoint: `ProductsController.GetProductById(int id)`

---

## 5. Model Binding

- ASP.NET Core automatically converts request data into **C# objects**.
- Sources of data:
  - Route parameters (e.g., `{id}`)
  - Query strings (e.g., `?page=2`)
  - Request body (JSON)
  - Headers
- This process allows endpoints to work with **strongly typed objects** instead of raw HTTP data.

---

## 6. Model Validation

- ASP.NET Core checks validation attributes defined on models:
  - `[Required]`, `[StringLength]`, `[Range]`, etc.
- If validation fails:
  - The pipeline returns a **400 Bad Request** response automatically
  - The controller method is **not executed**

---

## 7. Controller / Endpoint Execution

- Once model binding and validation succeed, the **controller method or endpoint** executes.
- Actions performed may include:
  - Business logic
  - Database operations (via Entity Framework Core or other ORMs)
  - Calls to external services
- The method produces a **result**, which could be:
  - A status code
  - A data object
  - Both

---

## 8. Result Processing

- The framework converts the controller result into an **HTTP response**:
  - Objects → serialized to JSON (default) or XML if configured
  - Status codes → 200, 201, 404, 500, etc.
- Response headers may be added (CORS, caching, content-type)

---

## 9. Outgoing Middleware

- After the controller returns a result, the response flows back through the **middleware pipeline in reverse**.
- Middleware can:
  - Log the response
  - Apply compression
  - Add security headers
  - Handle exceptions if they occur during serialization

---

## 10. Response Sent to Client

- Kestrel sends the fully prepared **HTTP response** back over the network to the client.
- Example JSON response:

```json
{
  "id": 1,
  "name": "Laptop",
  "price": 1500
}

# ASP.NET Core Web API Request Lifecycle - Summary

1. **Request Arrival** → Client sends HTTP request.
2. **Kestrel Handling** → Server reads request and creates HttpContext.
3. **Middleware Pipeline (Incoming)** → Logging, security, routing, authentication.
4. **Routing** → Determine which endpoint will handle the request.
5. **Model Binding** → Convert request data into C# objects.
6. **Model Validation** → Validate objects according to defined rules.
7. **Controller/Endpoint Execution** → Run business logic and prepare result.
8. **Result Processing** → Serialize result and set status codes.
9. **Middleware Pipeline (Outgoing)** → Modify response, logging, compression.
10. **Response Sent** → Kestrel sends the response to the client.