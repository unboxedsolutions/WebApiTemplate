# WebApiTemplate
Skeleton WebAPI project with token authentication, log4net, and Castle Windsor IoC, and <b>no</b> Entity Framework

This WebAPI project will give you a starting point for JWT authentication without being bound to EF using the standard Visual Studio template. The JWT authentication concept is mostly derived from Scott Allen's blog post <a href="http://odetocode.com/blogs/scott/archive/2015/01/15/using-json-web-tokens-with-katana-and-webapi.aspx">Using JSON Web Tokens with Katana and WebAPI</a>.  I generally use log4net as well as Castle Windsor for Inversion of Control. I also added some inline Angular code on the Index.cshtml page to ensure that the authentication request to /Token is working, as well as a simple call to GET some test data. CORS support allows all OPTIONS requests, which I find useful for testing code from Ionic, Electron, or a SPA.

From an empty Web application, you'll need to add the following NuGet packages:

<ul>
<li>Microsoft.AspNet.WebApi.Cors</li>
<li>Microsoft.Owin.Security.OAuth</li>
<li>Microsoft.Owin.Security.Jwt</li>
<li>Microsoft.AspNet.WebApi.Owin</li>
<li>Microsoft.Owin.Host.SystemWeb</li>
<ul>

## Added ExampleNodeEndpoint
The ExampleNodeEndpoint folder contains an ExpressJS app that uses passport to validate the JWT token created by the Web API which is demonstrated by the AngularJS client application calling to it as well as the Web API.
