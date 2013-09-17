namespace Archie.Web.Script.Engine
{
  using System.Collections.Generic;

  using Archie.Web.Script.Models;

  /// <summary>
  /// ASP.NET MVC route parser engine.
  /// </summary>
  internal class MvcRouteParser : IRouteParser
  {
    /// <summary>
    /// Register route collection.
    /// </summary>
    /// <param name="routes">Collection with routes.</param>
    public void RegisterRoutes(List<RouteModel> routes)
    {
      // todo - implement me
    }

    /// <summary>
    /// Gets url from route name and given parameters.
    /// </summary>
    /// <param name="routeName">Route name.</param>
    /// <param name="parameters">Url parametrs.</param>
    /// <returns>Generated url.</returns>
    public string RouteUrl(string routeName, Dictionary<string, string> parameters)
    {
      // todo - implement me
      return null;
    }
  }
}
