using FullShelves.Repository.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Authentication;

namespace FullShelves.Repository
{
  public class Connection : IConnection
  {
    public string ConnectionString { get { return @"mongodb://kenely:FgmKYZj2qKIw1YPEBtiHQv5lW0BWJzF3LOkMHa6EWNeOHkBTccD7c8feIQKbknxHlm5cQ7oyCXP3r2uFB7E97w==@kenely.documents.azure.com:10255/?ssl=true&replicaSet=globaldb"; } }
    public IMongoDatabase Db { get; set; }
    
    public Connection()
    {
      MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
      settings.SslSettings =
        new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

      var mongoClient = new MongoClient(settings);
      Db = mongoClient.GetDatabase("FullShelves");

      #region insert

      //var database = MongoClient.GetDatabase("FullShelves");
      //database.CreateCollection("Books");
      //database.CreateCollection("Genre");
      //database.CreateCollection("Author");


      //var genre = database.GetCollection<Genre>("Genre");
      //genre.InsertOne(new Genre() { Id = 1, Description = "Fantasy" });
      //genre.InsertOne(new Genre() { Id = 2, Description = "Sci-Fi" });
      //genre.InsertOne(new Genre() { Id = 3, Description = "Romance" });
      //genre.InsertOne(new Genre() { Id = 4, Description = "Thriller" });
      //genre.InsertOne(new Genre() { Id = 5, Description = "Terror" });

      //var author = database.GetCollection<Author>("Author");
      //author.InsertOne(new Author() { Id = 1, Name = "J. R. R. Tolkien" });
      //author.InsertOne(new Author() { Id = 2, Name = "C. S. Lewis" });
      //author.InsertOne(new Author() { Id = 3, Name = "Stephen King" });


      #endregion
    }

    public IMongoDatabase GetConnection()
    {
      return Db;
    }
  }
}
