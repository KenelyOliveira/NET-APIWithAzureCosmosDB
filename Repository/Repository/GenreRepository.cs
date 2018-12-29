using FullShelves.Domain.Model;
using FullShelves.Repository.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullShelves.Repository
{
  public class GenreRepository : IBaseRepository<Genre>, IGenreRepository
  {
    private readonly IConnection connection;

    public GenreRepository(IConnection connection)
    {
      this.connection = connection;
    }

    public Genre Find(Func<Genre, bool> func)
    {
      var con = connection.GetConnection();
      return con.GetCollection<Genre>("Genre").Find(new BsonDocument()).ToList().Where(func).FirstOrDefault();
    }

    public List<Genre> Get()
    {
      var genre = connection.GetConnection().GetCollection<Genre>("Genre");
      return genre.Find(new BsonDocument()).ToList();
    }
  }
}
