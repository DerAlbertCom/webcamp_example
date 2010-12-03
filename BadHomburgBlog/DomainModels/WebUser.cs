using System;

namespace BadHomburgBlog.DomainModels
{
    public class WebUser
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string EMail { get; set; }
    }
}