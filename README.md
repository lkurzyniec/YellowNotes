# YellowNotes
Sample ASP.NET Web API project.

## Table of contents
1. [The basics of API (CRUD)](#the-basics-of-api)
2. [Validation](#validation)
3. [Authentication and authorization](#authentication-and-authorization)

---

## The basics of API
* Create -> Post
* Read -> Get
* Update -> Put
* Delete -> Delete

## Validation
* Basic validation (via [DataAnnotations](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx) attributes)
* ModelState validation ([ValidateModelStateAttribute](YellowNotes/YellowNotes.Api/Attributes/ValidateModelStateAttribute.cs))
* Model validation ([CheckModelForNullAttribute](YellowNotes/YellowNotes.Api/Attributes/CheckModelForNullAttribute.cs))

## Authentication and authorization
* Access Token (OAuth bearer token authentication using Owin middleware) ([SimpleAuthorizationServerProvider](YellowNotes/YellowNotes.Api/Providers/SimpleAuthorizationServerProvider.cs))
* Token custom parameter
* Authentication Ticket custom property
* Custom claim
* Refresh Token ([SimpleRefreshTokenProvider](YellowNotes/YellowNotes.Api/Providers/SimpleRefreshTokenProvider.cs))
* Custom Authorize attribute ([SimpleAuthorize](YellowNotes/YellowNotes.Api/Attributes/SimpleAuthorizeAttribute.cs))

---

### Useful links:
* http://www.restapitutorial.com/httpstatuscodes.html
* http://racksburg.com/choosing-an-http-status-code