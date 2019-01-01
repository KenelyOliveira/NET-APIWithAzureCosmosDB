using System.Collections.Generic;
using FullShelves.Domain.Model;
using FullShelves.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullShelves.API.Controllers
{

  [Route("author")]
  public class AuthorController : BaseController
  {
    private readonly IAuthorService authorServices;
     
    public AuthorController(IAuthorService authorServices)
    {
      this.authorServices = authorServices;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseResponse<IEnumerable<Author>>), 200)]
    [ProducesResponseType(typeof(BaseResponse<IEnumerable<Author>>), 404)]
    [ProducesResponseType(typeof(BaseResponse<IEnumerable<Author>>), 500)]
    public IEnumerable<Author> Get()
    {
      return authorServices.GetAuthors();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseResponse<Author>), 200)]
    [ProducesResponseType(typeof(BaseResponse<Author>), 404)]
    [ProducesResponseType(typeof(BaseResponse<Author>), 500)]
    public Author Get(int id)
    {
      return authorServices.FindGenre(g => g.Id == id);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<Author>), 200)]
    [ProducesResponseType(typeof(BaseResponse<Author>), 404)]
    [ProducesResponseType(typeof(BaseResponse<Author>), 500)]
    public void Post(Author author)
    {
      authorServices.Save(author);
    }
  }
}
