using System.Data.Entity.Infrastructure;

namespace BadHomburgBlog.Data
{
    public class DatabaseSetup
    {
        public static void Initialize()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            Database.SetInitializer(new BlogDevelopDbInitializer());
        }
    }
}