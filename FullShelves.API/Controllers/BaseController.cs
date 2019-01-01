using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FullShelves.API.Controllers
{
  public class BaseController : Controller
  {
  }

  public class BaseResponse<T> where T : class
  {
    public bool Success { get; set; }
    public object Data { get; set; }
    public List<string> Messages { get; set; }
  }
}
