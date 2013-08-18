namespace Archie.Web.Configuration
{
  using System.Web.Mvc;
  using System.Web.Routing;

  /// <summary>
  /// Takes care for all routes.
  /// </summary>
  public static class RouteConfig
  {
    /// <summary>
    /// Adds routes to given routes collection.
    /// </summary>
    /// <param name="routes">Given routes collection.</param>
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }
  }
}
