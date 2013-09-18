namespace Archie.Web.Script.Engine
{
  using System;
  using System.Collections.Generic;
  using Archie.Web.Script.Models;

  /// <summary>
  /// Route parser interface.
  /// </summary>
  internal abstract class RouteParser
  {
    #region Properties

    /// <summary>
    /// Server side routes.
    /// </summary>
    protected List<RouteModel> Routes;

    #endregion

    #region Internal methods

    /// <summary>
    /// Register route collection.
    /// </summary>
    /// <param name="routeCollection">Collection with routes.</param>
    internal void RegisterRoutes(List<RouteModel> routeCollection)
    {
      this.Routes = routeCollection;
    }

    /// <summary>
    /// Gets url from route name and given parameters.
    /// </summary>
    /// <param name="routeName">Route name.</param>
    /// <param name="parameters">Url parameters.</param>
    /// <returns>Generated url.</returns>
    internal string RouteUrl(string routeName, Dictionary<string, string>[] parameters)
    {
      if (this.Routes == null)
      {
        throw new Exception("Routes were not registered yet");
      }

      if (this.Routes.Count == 0)
      {
        throw new Exception("No route was registered");
      }

      RouteModel route = this.FindRoute(routeName);
      if (route == null)
      {
        throw new Exception("Unable to find route " + routeName);
      }

      return this.Parse(route.Path, parameters);
    }

    /// <summary>
    /// Parse url from route path and given parameters.
    /// </summary>
    /// <param name="routePath">Route path.</param>
    /// <param name="parameters">Url parameters.</param>
    /// <returns>Generated url.</returns>
    protected abstract string Parse(string routePath, Dictionary<string, string>[] parameters);

    #endregion

    #region Protected

    /// <summary>
    /// Find route by route name.
    /// </summary>
    /// <param name="routeName">Route name.</param>
    /// <returns>Route model.</returns>
    protected RouteModel FindRoute(string routeName)
    {
      foreach (RouteModel route in this.Routes)
      {
        if (routeName == route.Name)
        {
          return route;
        }
      }

      return null;
    }

    /// <summary>
    /// Appends url query parameter to given url.
    /// </summary>
    /// <param name="url">Given url.</param>
    /// <param name="parameterName">Name of the parameter.</param>
    /// <param name="parameterValue">Parameter value.</param>
    /// <returns>Url with appended parameter.</returns>
    protected string AppendQueryParameter(string url, string parameterName, string parameterValue)
    {
      bool hasAnyParameter = url.IndexOf("?") >= 0;
      string separator = hasAnyParameter ? "&" : "?";
      return url + separator + parameterName + "=" + parameterValue;
    }

    #endregion
  }
}
