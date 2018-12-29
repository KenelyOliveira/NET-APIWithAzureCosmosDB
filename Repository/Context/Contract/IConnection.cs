using MongoDB.Driver;

namespace FullShelves.Repository.Contract
{
  public interface IConnection
  {
    IMongoDatabase GetConnection();
  }
}
