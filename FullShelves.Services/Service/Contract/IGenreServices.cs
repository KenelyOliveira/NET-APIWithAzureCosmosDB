using FullShelves.Domain.Model;
using System;
using System.Collections.Generic;

namespace FullShelves.Service.Contract
{
  public interface IGenreService
  {
    Genre FindGenre(Func<Genre, Boolean> func);
    List<Genre> GetGenres();
  }
}
