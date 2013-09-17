namespace Archie.Web.Script.Engine
{
  using System.Collections.Generic;
  using System.Runtime.CompilerServices;

  using Archie.Web.Script.Models;

  /// <summary>
  /// Main class for dealing with routes.
  /// </summary>
  [IgnoreNamespace]
  public static class Url
  {
    /// <summary>
    /// Route parser singleton.
    /// </summary>
    private static MvcRouteParser parser;

    /// <summary>
    /// Register route collection.
    /// </summary>
    /// <param name="routes">Collection with routes.</param>
    public static void RegisterRoutes(List<RouteModel> routes)
    {
      GetEngineImplementation().RegisterRoutes(routes);
    }

    /// <summary>
    /// Gets url from route name and given parameters.
    /// </summary>
    /// <param name="routeName">Route name.</param>
    /// <param name="parameters">Url parametrs.</param>
    /// <returns>Generated url.</returns>
    public static string RouteUrl(string routeName, Dictionary<string, string> parameters)
    {
      return GetEngineImplementation().RouteUrl(routeName, parameters);
    }

    /// <summary>
    /// Gets engine implementation.
    /// </summary>
    /// <returns></returns>
    private static IRouteParser GetEngineImplementation()
    {
      if (parser == null)
      {
        // todo: get from parameter?
        parser = new MvcRouteParser();
      }

      return parser;
    }
  }
}
