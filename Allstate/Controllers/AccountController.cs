using System.Web.Http;
using Allstate.Data;
using Allstate.Response;
using System.Security.Principal;
using System.Web.Security;

namespace Allstate.Controllers
{
    /// <summary>
    /// Controller for dealing with user accounts
    /// </summary>
    public class AccountController : ApiController
    {
        /// <summary>
        /// Verifies a user's login credentials and returns whether they're valid
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("login")]
        public LoginResponse Login(string username, string password)
        {
            var asUser = user.GetUser(username);
            
            if (asUser == null)
            {
                return new LoginResponse { Message = "Invalid username or password.", Success = false };
            }

            var hashedPass = HashPassword(password);

            if (asUser.password != hashedPass)
            {
                return new LoginResponse { Message = "Invalid username or password.", Success = false };
            }

            // save user authentication into session
            FormsAuthentication.SetAuthCookie(username, true);

            return new LoginResponse { Success = true };
        }

        private string HashPassword(string password)
        {
            // hash the password here
            var hashedPass = password;

            return hashedPass;
        }
    }
}