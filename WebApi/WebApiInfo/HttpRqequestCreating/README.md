# HTTP Request Creation

## Overview

An HTTP request is a message sent from a **client** to a **server** to
request a resource or perform an operation.\
Clients such as browsers, mobile apps, backend services, or API testing
tools send HTTP requests to communicate with web servers.

Each HTTP request follows a standardized structure defined by the HTTP
protocol.

------------------------------------------------------------------------

# Structure of an HTTP Request

An HTTP request consists of four main parts:

1.  Request Line
2.  Headers
3.  Empty Line
4.  Request Body (optional)

Example HTTP request:

    POST /api/products HTTP/1.1
    Host: example.com
    Content-Type: application/json
    Authorization: Bearer token

    {
      "name": "Laptop",
      "price": 1500
    }

------------------------------------------------------------------------

# 1. Request Line

The request line is the first line of the HTTP request.

It contains three components:

-   HTTP Method
-   Request Target (URL / Endpoint)
-   HTTP Version

Example:

    POST /api/products HTTP/1.1

## HTTP Methods

  Method    Description
  --------- --------------------------------
  GET       Retrieve data from the server
  POST      Create a new resource
  PUT       Update an existing resource
  PATCH     Partially update a resource
  DELETE    Remove a resource
  OPTIONS   Retrieve communication options

------------------------------------------------------------------------

# 2. Request Headers

Headers provide additional information about the request and the client.

Common headers include:

### Host

Specifies the domain name of the server.

    Host: example.com

### Content-Type

Specifies the format of the request body.

    Content-Type: application/json

### Authorization

Used to send authentication credentials.

    Authorization: Bearer token

### Accept

Indicates the response format the client expects.

    Accept: application/json

Headers help the server understand how the request should be processed.

------------------------------------------------------------------------

# 3. Empty Line

After the headers, there is a blank line.

This blank line separates the headers from the request body.

------------------------------------------------------------------------

# 4. Request Body

The request body contains data sent to the server.

It is typically used with:

-   POST
-   PUT
-   PATCH

Most modern APIs use **JSON** as the body format.

Example:

``` json
{
  "name": "Laptop",
  "price": 1500
}
```

------------------------------------------------------------------------

# How Clients Create HTTP Requests

HTTP requests can be created using different clients.

## Web Browsers

Browsers automatically generate HTTP requests when users open URLs or
submit forms.

## JavaScript Applications

Front-end applications send requests using:

-   Fetch API
-   Axios
-   XMLHttpRequest

## API Testing Tools

Developers commonly use tools such as:

-   Postman
-   Insomnia
-   curl

## Backend Services

Servers can also create HTTP requests to communicate with other APIs or
microservices.

------------------------------------------------------------------------

# Request Flow

The general flow of an HTTP request:

1.  The client constructs the HTTP request.
2.  The request is sent over the network.
3.  The server receives the request.
4.  The server processes the request.
5.  The server returns an HTTP response.

------------------------------------------------------------------------

# Summary

HTTP requests are the foundation of communication between clients and
servers.\
Understanding how requests are created and structured is essential when
building or consuming RESTful APIs.
