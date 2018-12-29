using System;
using System.Collections.Generic;
using FullShelves.Domain.Model;

namespace FullShelves.Service.Contract
{
  public interface IAuthorService
  {
    Author FindGenre(Func<Author, bool> func);
    List<Author> GetAuthors();
  }
}
