# HTTP Response Status Codes

## Overview

HTTP response status codes are standardized codes returned by a server to indicate the result of a client's request.  
These codes help the client understand whether the request was successful, failed, or requires further action.

In RESTful APIs such as **ASP.NET Core Web API**, response status codes are essential for clear communication between the client and the server.

HTTP status codes are divided into five main categories.

---

# Common Status Codes Used in REST APIs

In most REST APIs, the following codes are the most commonly used:

| Status Code | Meaning |
|-------------|--------|
| 200 | Request succeeded |
| 201 | Resource created |
| 204 | Successful request with no content |
| 400 | Bad request |
| 401 | Unauthorized |
| 403 | Forbidden |
| 404 | Resource not found |
| 409 | Conflict |
| 500 | Internal server error |

---

# 1xx — Informational Responses

These codes indicate that the request has been received and the process is continuing.

### 100 Continue
The server has received the request headers and the client should proceed with sending the request body.

### 101 Switching Protocols
The server is switching protocols as requested by the client.

### 102 Processing
The server has received the request but has not completed processing it yet.

---

# 2xx — Successful Responses

These codes indicate that the request was successfully received, understood, and processed.

### 200 OK
The request succeeded and the server returned the requested data.

### 201 Created
The request succeeded and a new resource was created.

Commonly used after **POST requests**.

### 202 Accepted
The request has been accepted for processing but has not been completed yet.

### 203 Non-Authoritative Information
The returned metadata may be modified from the original server response.

### 204 No Content
The request was successful but there is no content to return.

Commonly used after **DELETE operations**.

### 205 Reset Content
The client should reset the document view.

### 206 Partial Content
The server is delivering only part of the resource due to a range header.

---

# 3xx — Redirection Messages

These codes indicate that further action must be taken by the client to complete the request.

### 300 Multiple Choices
The request has multiple possible responses.

### 301 Moved Permanently
The resource has permanently moved to a new URL.

### 302 Found
The resource temporarily resides at a different URL.

### 303 See Other
The response can be found under another URI using a GET request.

### 304 Not Modified
The resource has not been modified since the last request.

Used in caching mechanisms.

### 307 Temporary Redirect
The request should be repeated with another URI but using the same HTTP method.

### 308 Permanent Redirect
The resource has permanently moved to another URI while keeping the same method.

---

# 4xx — Client Error Responses

These codes indicate that the client made an invalid request.

### 400 Bad Request
The server cannot process the request due to invalid syntax or bad data.

### 401 Unauthorized
Authentication is required and has failed or has not been provided.

### 403 Forbidden
The client is authenticated but does not have permission to access the resource.

### 404 Not Found
The requested resource could not be found on the server.

### 405 Method Not Allowed
The HTTP method used is not allowed for this endpoint.

### 406 Not Acceptable
The server cannot generate a response matching the client's accepted formats.

### 408 Request Timeout
The server timed out waiting for the request.

### 409 Conflict
The request conflicts with the current state of the resource.

### 410 Gone
The resource is permanently removed and no longer available.

### 415 Unsupported Media Type
The request payload format is not supported by the server.

### 422 Unprocessable Entity
The request is well-formed but contains semantic errors.

### 429 Too Many Requests
The client has sent too many requests in a given amount of time.

---

# 5xx — Server Error Responses

These codes indicate that the server failed to fulfill a valid request.

### 500 Internal Server Error
A generic error occurred on the server.

### 501 Not Implemented
The server does not support the functionality required to fulfill the request.

### 502 Bad Gateway
The server received an invalid response from an upstream server.

### 503 Service Unavailable
The server is currently unavailable due to overload or maintenance.

### 504 Gateway Timeout
The server did not receive a timely response from another server.

### 505 HTTP Version Not Supported
The server does not support the HTTP protocol version used in the request.

---

# Common Status Codes Used in REST APIs

In most REST APIs, the following codes are the most commonly used:

| Status Code | Meaning |
|-------------|--------|
| 200 | Request succeeded |
| 201 | Resource created |
| 204 | Successful request with no content |
| 400 | Bad request |
| 401 | Unauthorized |
| 403 | Forbidden |
| 404 | Resource not found |
| 409 | Conflict |
| 500 | Internal server error |

---

# Conclusion

HTTP status codes provide a standardized way for servers to communicate the outcome of a request.  
Using appropriate response codes improves API clarity, debugging, and client-server communication.