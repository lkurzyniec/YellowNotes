# YellowNotes
Sample ASP.NET Web API project with OAuth authentication and many other extensions.

## Table of contents
1. [The basics of API (CRUD)](#1-the-basics-of-api)
2. [Validation](#2-validation)
3. [Authentication and authorization](#3-authentication-and-authorization)
4. [Documentation](#4-documentation)
5. [Other](#5-other)
6. [Samples and Examples](#6-samples-and-examples)
7. [Contributing](#7-contributing)
8. [Useful links](#8-useful-links)

---

## 1. The basics of API
* Create -> Post
* Read -> Get
* Update -> Put
* Delete -> Delete

## 2. Validation
* Basic validation (via [DataAnnotations](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx) attributes)
* ModelState validation ([ValidateModelStateAttribute](YellowNotes/YellowNotes.Api/Attributes/ValidateModelStateAttribute.cs))
* Model empty validation ([CheckModelForNullAttribute](YellowNotes/YellowNotes.Api/Attributes/CheckModelForNullAttribute.cs))
* Action parameters validation ([ActionParametersValidationAttribute](YellowNotes/YellowNotes.Api/Attributes/ActionParametersValidationAttribute.cs))

## 3. Authentication and authorization
* Access Token (OAuth bearer token authentication using OWIN middleware) ([SimpleAuthorizationServerProvider](YellowNotes/YellowNotes.Api/Providers/SimpleAuthorizationServerProvider.cs))
* Client credentials validation
* Token custom parameter
* Authentication Ticket custom property
* Custom claim
* Refresh Token ([SimpleRefreshTokenProvider](YellowNotes/YellowNotes.Api/Providers/SimpleRefreshTokenProvider.cs))
* Custom Authorize attribute ([SimpleAuthorize](YellowNotes/YellowNotes.Api/Attributes/SimpleAuthorizeAttribute.cs))

## 4. Documentation
* Help Pages (via [Microsoft.AspNet.WebApi.HelpPage](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.HelpPage/) nuget package)
* Multiple XML documentation (XML comments beyond the main project)
* HTTP Status Codes (attribute to generate HTTP response codes in documentation) ([ResponseHttpStatusCodeAttribute](YellowNotes/YellowNotes.Api/Attributes/ResponseHttpStatusCodeAttribute.cs))
* Output Cache profile

## 5. Other
* API exceptions handling ([RequestExceptionAttribute](YellowNotes/YellowNotes.Api/Attributes/RequestExceptionAttribute.cs))
* Working CORS (Cross-Origin Resource Sharing) implementation ([CorsProvider](YellowNotes/YellowNotes.Api/Providers/CorsProvider.cs))

---

## 6. Samples and Examples

### Token generation
![Token generation](http://kurzyniec.pl/wp-content/uploads/2017/03/yellownotes-token-generation.png "Token generation")

### Access to resource denied
![Access denied](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-access-denied.png "Access denied")

### Access to resource granted
![Access granted](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-access-granted.png "Access granted")

### Refresh Token utilise
![Refresh Token utilise](http://kurzyniec.pl/wp-content/uploads/2017/03/yellownotes-refresh-token.png "Refresh Token utilise")

### Model validation
![Model empty validation](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-model-empty.png "Model empty validation")

### CORS (Cross-Origin Resource Sharing)
![CORS](http://kurzyniec.pl/wp-content/uploads/2017/03/yellownotes-cors.png "CORS")

### Documentation Help Pages
![Help Pages](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-help-pages.png "Help Pages")

![HTTP Status Codes](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-http-statuses.png "HTTP Status Codes")

---

## 7. Contributing
You are very welcome to submit either issues or pull requests to this repository!

I'm trying to follow GitHub Flow process, so please follow this rules:
* Make changes on feature branch.
* Commit messages should be clear and as much as possible descriptive.
* Rebase if required.
* Make sure that your code compile and run locally.
* Push your feature branch to GitHub.
* Create pull request.

---

## 8. Useful links
* http://www.restapitutorial.com/httpstatuscodes.html
* http://racksburg.com/choosing-an-http-status-code