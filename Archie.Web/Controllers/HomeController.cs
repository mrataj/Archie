namespace Archie.Web.Controllers
{
  using System.Web.Mvc;

  using Archie.Web.Models;
  using Archie.Web.Provider;

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
      var model = new HomeModel();

      foreach (var route in RoutesProvider.GetRoutes())
      {
        model.Routes.Add(route);
      }

      return this.View("~/Views/Home/Home.cshtml", model);
    }
  }
}
