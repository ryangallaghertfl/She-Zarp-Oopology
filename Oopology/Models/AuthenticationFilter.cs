namespace Oopology.Models;

public class AuthenticationFilter
{
    public bool IsLoggedIn(HttpContext httpContext)
    {
        int? userId = httpContext.Session.GetInt32("User_Id");
        return userId != null;
    }
}