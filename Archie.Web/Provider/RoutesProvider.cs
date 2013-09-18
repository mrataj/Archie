namespace Archie.Web.Provider
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;
  using System.Reflection;
  using System.Web.Routing;

  using Archie.Web.Models;

  /// <summary>
  /// Provides methods for providing collection of route models.
  /// </summary>
  public static class RoutesProvider
  {
    /// <summary>
    /// Gets view model of registered routes.
    /// </summary>
    /// <returns>Collection of registered routes.</returns>
    public static IEnumerable<RouteModel> GetRoutes()
    {
      var routes = new List<RouteModel>();

      foreach (var route in RouteTable.Routes.Where(r => r is Route).Cast<Route>())
      {
        var routeModel = new RouteModel { Path = route.Url, Name = GetRouteName(route) };
        routes.Add(routeModel);
      }

      return routes;
    }

    #region Private

    /// <summary>
    /// Gets route name for given route.
    /// </summary>
    /// <param name="route">Given route.</param>
    /// <returns>Route name.</returns>
    private static string GetRouteName(Route route)
    {
      if (route == null)
      {
        throw new ArgumentNullException("route");
      }

      var routes = GetRouteNames();
      foreach (var registeredRoute in routes.Values)
      {
        if (registeredRoute == route)
        {
          return routes.Single(x => x.Value == route).Key;
        }
      }

      return null;
    }

    /// <summary>
    /// Gets all routes with their names.
    /// </summary>
    /// <returns>Dictionary with routes and their names.</returns>
    private static Dictionary<string, RouteBase> GetRouteNames()
    {
      var fields = RouteTable.Routes.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
      var fieldInfo = fields.Single(x => x.Name == "_namedMap");

      var keys = fieldInfo.GetValue(RouteTable.Routes);
      if (keys == null)
      {
        throw new InvalidOperationException();
      }

      return keys as Dictionary<string, RouteBase>;
    }

    #endregion
  }
}
