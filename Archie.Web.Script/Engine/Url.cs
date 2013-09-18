namespace Archie.Web.Script.Engine
{
  using System;
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
    private static RouteParser parser;

    /// <summary>
    /// Register route collection.
    /// </summary>
    /// <param name="routes">Collection with routes.</param>
    public static void RegisterRoutes(List<RouteModel> routes)
    {
      GetParserImplementation().RegisterRoutes(routes);
    }

    /// <summary>
    /// Gets url from route name and given parameters.
    /// </summary>
    /// <param name="routeName">Route name.</param>
    /// <param name="parameters">Url parameters.</param>
    /// <returns>Generated url.</returns>
    public static string RouteUrl(string routeName, Dictionary<string, string>[] parameters)
    {
      return GetParserImplementation().RouteUrl(routeName, parameters);
    }

    /// <summary>
    /// Gets parser implementation.
    /// </summary>
    /// <returns>Route parser implementation.</returns>
    private static RouteParser GetParserImplementation()
    {
      if (parser == null)
      {
        parser = new MvcRouteParser();
      }

      return parser;
    }
  }
}
