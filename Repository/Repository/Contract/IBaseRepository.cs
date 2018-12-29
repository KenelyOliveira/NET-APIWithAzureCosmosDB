using System;
using System.Collections.Generic;

namespace FullShelves.Repository.Contract
{
  public interface IBaseRepository<T> where T : class
  {
    T Find(Func<T, Boolean> func);
    List<T> Get();
  }
}
