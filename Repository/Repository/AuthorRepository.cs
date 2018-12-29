using FullShelves.Domain.Model;
using FullShelves.Repository.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullShelves.Repository
{
  public class AuthorRepository : IBaseRepository<Author>, IAuthorRepository
  {
    private readonly IConnection connection;

    public AuthorRepository(IConnection connection)
    {
      this.connection = connection;
    }

    public Author Find(Func<Author, bool> func)
    {
      var con = connection.GetConnection();
      return con.GetCollection<Author>("Author").Find(new BsonDocument()).ToList().Where(func).FirstOrDefault();
    }

    public List<Author> Get()
    {
      var genre = connection.GetConnection().GetCollection<Author>("Author");
      return genre.Find(new BsonDocument()).ToList();
    }

  }
}
