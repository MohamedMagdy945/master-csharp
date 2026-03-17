# Sending Parameters in Requests

Parameters allow the client to send data to the API.

There are several ways to pass parameters.

------------------------------------------------------------------------

## 1. Route Parameters

The parameter is part of the URL.

Example:

GET /api/department/5

Controller example:

```csharp
[HttpGet("{id}")\] public IActionResult GetById(int id)
```

The value "5" will be assigned to id.

------------------------------------------------------------------------

## 2. Query Parameters

Parameters appear after a question mark in the URL.

Example:

GET /api/department?name=IT&page=2

Controller example:

public IActionResult Search(string name, int page)

ASP.NET Core automatically binds the values.

------------------------------------------------------------------------

## 3. Request Body

Parameters are sent inside the request body as JSON.

Example request:

POST /api/department

Body:

{ "name": "IT" }

Controller example:

\[HttpPost\] public IActionResult Add(Department department)

ASP.NET automatically converts JSON to an object.

------------------------------------------------------------------------

## 4. Header Parameters

Data can be sent in the request headers.

Example:

Authorization: Bearer token

Controller example:

public IActionResult Test(\[FromHeader\] string token)

Commonly used for authentication.

------------------------------------------------------------------------

## 5. Form Data

Form data is also sent inside the **request body**, but in a different
format.

Used mainly with:

HTML forms\
File uploads

Two main formats exist.

------------------------------------------------------------------------

### application/x-www-form-urlencoded

Example body:

name=IT&location=Cairo

Header:

Content-Type: application/x-www-form-urlencoded

------------------------------------------------------------------------

### multipart/form-data

Used when uploading files.

Example structure:

Content-Disposition: form-data; name="name"

IT

Controller example:

\[HttpPost\] public IActionResult Add(\[FromForm\] string name)

Or:

public IActionResult Add(\[FromForm\] Department dept)

------------------------------------------------------------------------

# 6. JSON vs Form Data

JSON is the most common format used in modern APIs.

Comparison:

JSON\
Body format: { "name": "IT" }\
Content-Type: application/json

Form Data\
Body format: name=IT\
Content-Type: application/x-www-form-urlencoded

------------------------------------------------------------------------

# 7. Typical API Request Flow

Client\
↓\
HTTP Request\
↓\
ASP.NET Core Routing\
↓\
Controller\
↓\
Entity Framework / Database\
↓\
HTTP Response\
↓\
Client

------------------------------------------------------------------------

# Conclusion

Understanding how HTTP requests work is essential for building APIs.

Key topics include:

-   HTTP request structure
-   Status codes
-   Request methods
-   Parameter passing
-   JSON vs Form Data

Mastering these fundamentals makes it easier to design and build robust
APIs in ASP.NET Core.
