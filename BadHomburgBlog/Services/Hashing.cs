using System;
using System.Security.Policy;
using System.Text;

namespace BadHomburgBlog.Services
{
    public class Hashing
    {
        private string salt = "BadHomburg";

        public string GetHash(string password)
        {
            var hash = Hash.CreateSHA1(Encoding.UTF8.GetBytes(password + salt));
            return Convert.ToBase64String(hash.SHA1);
        }
    }
}