using System.Collections.Generic;
using FullShelves.Domain.Model;
using FullShelves.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullShelves.API.Controllers
{

  [Route("author")]
  public class AuthorController : Controller
  {
    private readonly IAuthorService authorServices;
     
    public AuthorController(IAuthorService authorServices)
    {
      this.authorServices = authorServices;
    }

    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<Author> Get()
    {
      return authorServices.GetAuthors();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public Author Get(int id)
    {
      return authorServices.FindGenre(g => g.Id == id);
    }
  }
}
