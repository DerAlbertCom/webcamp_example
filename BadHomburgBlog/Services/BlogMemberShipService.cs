using System;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web.Security;
using BadHomburgBlog.Data;
using BadHomburgBlog.DomainModels;
using BadHomburgBlog.Models;

namespace BadHomburgBlog.Services
{
    public class BlogMemberShipService : IMembershipService
    {
        public int MinPasswordLength
        {
            get { return 6; }
        }

        public bool ValidateUser(string userName, string password)
        {
            using (var dbContext = new BlogDbContext()){
                var user = dbContext.Users.SingleOrDefault(u => u.Name == userName);
                if (user == null)
                    return false;
                return user.PasswordHash == GetHash(password);
            }
        }

        private  string GetHash(string password)
        {
            return new Hashing().GetHash(password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            using (var dbContext = new BlogDbContext()){
                var user = dbContext.Users.SingleOrDefault(u => u.Name == userName || u.EMail == email);
                if (user != null)
                    return MembershipCreateStatus.DuplicateUserName;
                user = new WebUser {Name = userName, EMail = email, PasswordHash = GetHash(password)};
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return MembershipCreateStatus.Success;
            }
        }


        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            using (var dbContext = new BlogDbContext()){
                var user = dbContext.Users.SingleOrDefault(u => u.Name == userName);
                if (user == null)
                    return false;
                if (user.PasswordHash == GetHash(oldPassword)){
                    user.PasswordHash = GetHash(newPassword);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}