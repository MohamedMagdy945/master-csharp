# ASP.NET Core Request Pipeline & Kestrel Explained

This document explains what happens **under the hood** when an ASP.NET Core application runs and receives HTTP requests, focusing on **Kestrel**, the **middleware pipeline**, and the role of **IIS**.

---

## 1. What is a Web Server?

A **Web Server** is a program responsible for:

- Listening for **HTTP requests** from clients (e.g., browsers, Postman).
- Parsing the raw TCP/IP packets into **HTTP request objects**.
- Forwarding requests to your application.
- Sending back **HTTP responses** to the client.

> In short, a Web Server is the bridge between the network and your application.

---

## 2. Kestrel in ASP.NET Core

**Kestrel** is the official web server for ASP.NET Core:

- **Responsibilities:**
  1. Accepts TCP/IP connections and parses HTTP requests.
  2. Converts requests into **`HttpContext`** objects.
  3. Passes the context through the **middleware pipeline**.
  4. Sends back the response as TCP/IP packets to the client.

- **Advantages:**
  - Lightweight and high-performance.
  - Fully asynchronous I/O.
  - Supports HTTPS natively.
  - Can run **standalone** or behind a **reverse proxy**.

---

## 3. Running an ASP.NET Core Application

Typical `Program.cs` in .NET 9/10:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Define endpoints
app.MapControllers();

app.Run();

---

# What Happens Under the Hood When `app.Run()` is Called

This section explains step by step what happens internally in an ASP.NET Core application when `app.Run()` is executed.

---

## 1. Create Host

- Builds the host containing:
  - **Kestrel Web Server**
  - **Dependency Injection container**
  - **Logging**
  - **Configuration** (appsettings.json, environment variables, etc.)

---

## 2. Build Middleware Pipeline

- Combines all `Use*` middlewares into a **single pipeline**.
- Prepares **Endpoint Routing** to match requests to controllers or Minimal APIs.

---

## 3. Start Kestrel Server

- Opens a **TCP/IP port** (e.g., 5000 or 5001 for HTTPS) and starts listening for incoming connections.
- Converts incoming network packets into **`HttpRequest` objects**.

---

## 4. Request Handling

- Each request passes through the **middleware pipeline** in order.
- Middleware can:
  - Modify the request
  - Perform logging
  - Perform authentication or authorization
  - Short-circuit the pipeline and return a response immediately

---

## 5. Routing & Endpoint Execution

- Determines which **controller/action** or **Minimal API endpoint** should handle the request.
- Performs **model binding** for controller parameters.
- Executes the **action method** to generate a response.

---

## 6. Response Sent

- Response flows back through middleware (e.g., for logging, compression, or exception handling).
- **Kestrel** sends the final response as **TCP/IP packets** to the client.

---

## 7. Middleware Pipeline Overview

Middleware is code that runs for every HTTP request and response. Examples:

- `UseRouting()` → Determines the correct endpoint.
- `UseAuthentication()` → Checks user identity.
- `UseAuthorization()` → Checks user permissions.
- `UseExceptionHandler()` → Global error handling.
- `UseLogging()` → Logs requests/responses.

> **Important:** Middleware order is critical because each middleware can modify or short-circuit the pipeline.



Client Request
      ↓
  TCP/IP + SSL
      ↓
  Kestrel (Server)
      ↓
  Middleware Pipeline
      ↓
  Routing → Controller/Endpoint
      ↓
  Model Binding & Validation
      ↓
  Handler Execution (Business Logic)
      ↓
  Serialize Response (JSON)
      ↓
  Middleware Pipeline (Outgoing)
      ↓
  Kestrel Sends Response
      ↓
Client Receives Response