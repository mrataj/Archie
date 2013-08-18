namespace Archie.Web.Models.Routes
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Routing;

  /// <summary>
  /// Model with routes.
  /// </summary>
  public class RoutesModel
  {
    /// <summary>
    /// Initializes a new instance of the RoutesModel class using collection of routes.
    /// </summary>
    /// <param name="routes">Collection of routes.</param>
    public RoutesModel(IEnumerable<RouteBase> routes) : this()
    {
      if (routes == null)
      {
        throw new ArgumentNullException("routes");
      }

      foreach (var route in routes.Where(r => r is Route).Cast<Route>())
      {
        var routeModel = new RouteModel
          {
            Url = route.Url
          };
        this.Routes.Add(routeModel);
      }
    }

    /// <summary>
    /// Initializes a new instance of the RoutesModel class.
    /// </summary>
    public RoutesModel()
    {
      this.Routes = new List<RouteModel>();
    }

    /// <summary>
    /// Gets list of registered url routes on server.
    /// </summary>
    public IList<RouteModel> Routes { get; private set; }
  }
}
