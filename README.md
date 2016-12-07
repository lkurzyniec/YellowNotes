# YellowNotes
Sample ASP.NET Web API project.

## Table of contents
1. [The basics of API (CRUD)](#the-basics-of-api)
2. [Validation](#validation)
3. [Authentication and authorization](#authentication-and-authorization)
4. [Documentation](#documentation)
5. [Examples](#examples)
6. [Useful links](#useful-links)

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

## Documentation
* Help Pages (via [Microsoft.AspNet.WebApi.HelpPage](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.HelpPage/) nuget package)
* Multiple XML documentation (XML comments beyond the main project)
* HTTP Status Codes (attribute to generate HTTP response codes in documentation) ([ResponseHttpStatusCodeAttribute](YellowNotes/YellowNotes.Api/Attributes/ResponseHttpStatusCodeAttribute.cs))

---

## Examples

---

## Useful links
* http://www.restapitutorial.com/httpstatuscodes.html
* http://racksburg.com/choosing-an-http-status-code