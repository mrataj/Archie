namespace Archie.Web.Controllers
{
  using System.Web.Mvc;
  using System.Web.Routing;

  using Archie.Web.Models;
  using Archie.Web.Models.Routes;

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
      var model = new HomeModel
        {
          Message = "Hello, Archie!",
          Routes = new RoutesModel(RouteTable.Routes)
        };
      return this.View("~/Views/Home/Home.cshtml", model);
    }
  }
}
