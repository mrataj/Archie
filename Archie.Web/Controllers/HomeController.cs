namespace Archie.Web.Controllers
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Mvc;
  using System.Web.Routing;

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
      
      foreach (var route in GetRoutes())
      {
        model.Routes.Add(route);
      }

      return this.View("~/Views/Home/Home.cshtml", model);
    }

    /// <summary>
    /// Gets view model of registered routes.
    /// </summary>
    /// <returns>Collection of registered routes.</returns>
    [NonAction]
    private static IEnumerable<RouteModel> GetRoutes()
    {
      var routes = new List<RouteModel>();
      
      foreach (var route in RouteTable.Routes.Where(r => r is Route).Cast<Route>())
      {
        var routeModel = new RouteModel
          {
            Url = route.Url
          };
        routes.Add(routeModel);
      }

      return routes;
    }
  }
}
