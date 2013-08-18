namespace Archie.Web.Controllers
{
  using System.Web.Mvc;

  using Archie.Web.Models;

  /// <summary>
  /// Simple home controller.
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// Gets default view.
    /// </summary>
    /// <returns>View result with home view.</returns>
    public ActionResult Index()
    {
      var model = new HomeModel { Message = "Hello, Archie!" };
      return this.View("~/Views/Home/Home.cshtml", model);
    }
  }
}
