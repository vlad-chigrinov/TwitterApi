using LiteDB;
using TwitterApi.Entity;

namespace TwitterApi
{
    public class DataContext
    {
        readonly string _dbPath;

        public DataContext(IConfiguration configuration)
        {
            _dbPath = configuration.GetConnectionString("LiteDB");
        }

        public ILiteDatabase GetConnection()
        {
            return new LiteDatabase(_dbPath);
        }

    }
}