namespace Archie.Web.Script.Engine
{
  using System.Collections.Generic;
  using Archie.Web.Script.Models;

  /// <summary>
  /// Route parser interface.
  /// </summary>
  internal interface IRouteParser
  {
    /// <summary>
    /// Register route collection.
    /// </summary>
    /// <param name="routes">Collection with routes.</param>
    void RegisterRoutes(List<RouteModel> routes);

    /// <summary>
    /// Gets url from route name and given parameters.
    /// </summary>
    /// <param name="routeName">Route name.</param>
    /// <param name="parameters">Url parametrs.</param>
    /// <returns>Generated url.</returns>
    string RouteUrl(string routeName, Dictionary<string, string> parameters);
  }
}
