using System.Data.Entity.Database;

namespace BadHomburgBlog.Data
{
    public class DatabaseSetup
    {
        public static void Initialize()
        {
            DbDatabase.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            DbDatabase.SetInitializer(new BlogDevelopDbInitializer());
        }
    }
}