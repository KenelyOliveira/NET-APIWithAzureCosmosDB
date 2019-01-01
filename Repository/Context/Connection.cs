using FullShelves.Repository.Contract;
using MongoDB.Driver;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;

namespace FullShelves.Repository
{
  public class Connection : IConnection
  {
    #region Constructor

    private readonly IConfiguration configuration;

    public Connection(IConfiguration configuration)
    {
      this.configuration = configuration;

      Connect();
    }

    #endregion

    public IMongoDatabase Db { get; set; }

    public void Connect()
    {
      //var connectionString = @"mongodb://fullshelves:BgRmXlyPKHFHr6Jz9Hpj8JP72GPM0LmOqCM3K6IIJVCwqFtHwdLLCAge90EgkZVtmj51km6NgfueeEFZsgPmiA==@fullshelves.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

      MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetConnectionString("AzureCosmosDB")));
      settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

      var mongoClient = new MongoClient(settings);
      Db = mongoClient.GetDatabase("FullShelves");

      #region Initial Seed

      //var database = mongoClient.GetDatabase("FullShelves");
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
