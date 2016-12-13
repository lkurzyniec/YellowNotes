# YellowNotes
Sample ASP.NET Web API project with OAuth authentication and many other extensions.

## Table of contents
1. [The basics of API (CRUD)](#the-basics-of-api)
2. [Validation](#validation)
3. [Authentication and authorization](#authentication-and-authorization)
4. [Exceptions](#exceptions)
5. [Documentation](#documentation)
6. [Examples](#examples)
7. [Contributing](#contributing)
8. [Useful links](#useful-links)

---

## The basics of API
* Create -> Post
* Read -> Get
* Update -> Put
* Delete -> Delete

## Validation
* Basic validation (via [DataAnnotations](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx) attributes)
* ModelState validation ([ValidateModelStateAttribute](YellowNotes/YellowNotes.Api/Attributes/ValidateModelStateAttribute.cs))
* Model empty validation ([CheckModelForNullAttribute](YellowNotes/YellowNotes.Api/Attributes/CheckModelForNullAttribute.cs))

## Authentication and authorization
* Access Token (OAuth bearer token authentication using Owin middleware) ([SimpleAuthorizationServerProvider](YellowNotes/YellowNotes.Api/Providers/SimpleAuthorizationServerProvider.cs))
* Token custom parameter
* Authentication Ticket custom property
* Custom claim
* Refresh Token ([SimpleRefreshTokenProvider](YellowNotes/YellowNotes.Api/Providers/SimpleRefreshTokenProvider.cs))
* Custom Authorize attribute ([SimpleAuthorize](YellowNotes/YellowNotes.Api/Attributes/SimpleAuthorizeAttribute.cs))

## Exceptions
* API exceptions handling ([RequestExceptionAttribute](YellowNotes/YellowNotes.Api/Attributes/RequestExceptionAttribute.cs))

## Documentation
* Help Pages (via [Microsoft.AspNet.WebApi.HelpPage](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.HelpPage/) nuget package)
* Multiple XML documentation (XML comments beyond the main project)
* HTTP Status Codes (attribute to generate HTTP response codes in documentation) ([ResponseHttpStatusCodeAttribute](YellowNotes/YellowNotes.Api/Attributes/ResponseHttpStatusCodeAttribute.cs))
* Output Cache profile

---

## Samples and Examples

### Token generation
![Token generation](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-token-generation.png "Token generation")

### Access to resource denied
![Access denied](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-access-denied.png "Access denied")

### Access to resource granted
![Access granted](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-access-granted.png "Access granted")

### Refresh Token utilise
![Refresh Token utilise](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-refresh-token.png "Refresh Token utilise")

### Model validation
![Model empty validation](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-model-empty.png "Model empty validation")

### Documentation Help Pages
![Help Pages](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-help-pages.png "Help Pages")

![HTTP Status Codes](http://kurzyniec.pl/wp-content/uploads/2016/12/yellownotes-http-statuses.png "HTTP Status Codes")

---

## Contributing
You are very welcome to submit either issues or pull requests to this repository!

I'm trying to follow GitHub Flow process, so please follow this rules:
* Make changes on feature branch.
* Commit messages should be clear and as much as possible descriptive.
* Rebase if required.
* Make sure that your code compile and run locally.
* Push your feature branch to GitHub.
* Create pull request.

---

## Useful links
* http://www.restapitutorial.com/httpstatuscodes.html
* http://racksburg.com/choosing-an-http-status-code