# IIS (Internet Information Services) in ASP.NET Core

This document explains what **IIS** is, its role, benefits, and advantages when hosting ASP.NET Core applications.

---

## 1. What is IIS?

**IIS (Internet Information Services)** is a **web server software developed by Microsoft** for hosting websites and web applications on Windows.

- Listens for **HTTP/HTTPS requests** on designated ports (e.g., 80, 443).
- Serves **static files** (HTML, CSS, JS) and forwards **dynamic requests** to web applications like ASP.NET Core.
- Can act as a **reverse proxy** to Kestrel, the internal ASP.NET Core web server.

---

## 2. Role of IIS with ASP.NET Core

When hosting an ASP.NET Core application, IIS typically works as a **reverse proxy**:

```text
Client Request
      │
      ▼
     IIS
      │ (forwards request)
      ▼
   Kestrel Web Server
      │
      ▼
ASP.NET Core Application
      │
      ▼
   Kestrel Response
      │
      ▼
     IIS
      │ (sends back to client)
      ▼
    Client

    ## Key Responsibilities of IIS

- **Process Management**: Ensures your ASP.NET Core app runs reliably; restarts it if it crashes.  
- **Security**: Handles authentication, SSL termination, and request filtering.  
- **Integration with Windows**: Supports Windows authentication, port sharing, and system services.  
- **Logging and Diagnostics**: Centralizes logs for monitoring, auditing, and troubleshooting.  

---

## Benefits of Using IIS

### 1. Reliability & Stability
- Automatically restarts apps if they crash.  
- Manages multiple applications on the same server efficiently.  

### 2. Security
- Provides SSL/TLS termination.  
- Handles authentication and authorization at the server level.  
- Protects applications from certain types of attacks (request filtering, URL restrictions).  

### 3. Performance Optimization
- Caches static content.  
- Compresses responses before sending them to clients.  

### 4. Centralized Management
- Easy configuration through **IIS Manager GUI** or PowerShell.  
- Centralized logging, monitoring, and diagnostics for multiple web applications.  

### 5. Enterprise Features
- Supports load balancing and web farms.  
- Integrates with Active Directory for enterprise authentication.  
- Compatible with other Windows Server features like Windows Event Logs.  

---

## Why Combine IIS with Kestrel?

- **Kestrel alone**: lightweight, fast, fully capable of serving requests, but limited in enterprise-level features like process management and advanced security.  
- **IIS + Kestrel**: best of both worlds:  
  - Kestrel handles high-performance request processing.  
  - IIS provides enterprise-grade features (security, monitoring, process control).  

> **Recommendation:** Use IIS as a reverse proxy in production environments on Windows for reliability and security.  

---

## Summary Comparison

| Feature                       | IIS + Kestrel | Kestrel Standalone |
|-------------------------------|---------------|------------------|
| HTTP/HTTPS Listening           | ✅             | ✅                |
| Reverse Proxy                  | ✅             | ❌                |
| Process Management             | ✅             | ❌                |
| Windows Authentication         | ✅             | ❌                |
| Centralized Logging & Monitoring | ✅           | ❌                |
| High Performance               | ✅             | ✅                |