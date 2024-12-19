using MongoDB.Driver;

namespace FinTrack.Data
{
    public interface IDbConnectionFactory
    {
        IMongoDatabase OpenConnection();
    }
}
