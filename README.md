# abaqisSSO-client
ASP.NET solution for clients looking to integrate their users with abaqis utilizing the current SSO API.

There are a few samples within this solution.
If you are using ASP.NET MVC with .NET 4.5 you will see a solution in the 45 directory.

There is also an ASP.NET approach using WebForms which requires a different approach due to the WebForms page lifecycle.  Instead of using server code to process the login, instead we will use some simple JavaScript. The JavaScript will dynamically create a FORM, add two hidden input fields called login_token  and onsessionend. These are assigned the login token and onsessionend redirect url via Page_Load. The JavaScript then posts to the abaqis SSO login service. This service will redirect the browser to the  Abaqis application with the correct headers in-place to login the user.

Note:

  *   When moving to production, update the form.action = 'https://test.abaqis.com/sso/token_login'; line in the JavaScript to the production URL.
  *   The SessionEnd variable in the code behind determines the redirect URL after the user ends their Abaqis session.

