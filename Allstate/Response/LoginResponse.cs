using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allstate.Response
{
    /// <summary>
    /// Response from calling the account login
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Message returned if login failed
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns if the login was successful
        /// </summary>
        public bool Success { get; set; }
    }
}