using System.Collections.Generic;
using FullShelves.Domain.Model;
using FullShelves.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullShelves.API.Controllers
{
  [Route("genre")]
  public class GenresController : Controller
  {
    private readonly IGenreService genreServices;

    public GenresController(IGenreService genreServices)
    {
      this.genreServices = genreServices;
    }

    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<Genre> Get()
    {
      return genreServices.GetGenres();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public Genre Get(int id)
    {
      return genreServices.FindGenre(g => g.Id == id);
    }
  }
}
