using FullShelves.Domain.Model;
using FullShelves.Repository.Contract;
using FullShelves.Service.Contract;
using System;
using System.Collections.Generic;

namespace FullShelves.Service
{
  public class GenreService : IGenreService
  {
    private readonly IGenreRepository genrerRepository;

    public GenreService(IGenreRepository genrerRepository) {
      this.genrerRepository = genrerRepository;
    }

    public Genre FindGenre(Func<Genre, Boolean> func)
    {
      return genrerRepository.Find(func);
    }
    public List<Genre> GetGenres()
    {
      return genrerRepository.Get();
    }
  }
}
