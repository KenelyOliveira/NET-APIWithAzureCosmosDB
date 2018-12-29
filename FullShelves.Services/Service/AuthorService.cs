using FullShelves.Domain.Model;
using FullShelves.Repository.Contract;
using FullShelves.Service.Contract;
using System;
using System.Collections.Generic;

namespace FullShelves.Service
{
    public class AuthorService : IAuthorService
  {
    private readonly IAuthorRepository authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
      this.authorRepository = authorRepository;
    }

    public Author FindGenre(Func<Author, Boolean> func)
    {
      return authorRepository.Find(func);
    }
    public List<Author> GetAuthors()
    {
      return authorRepository.Get();
    }
  }
}
