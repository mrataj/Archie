namespace Archie.Web
{
  using System.Web;
  using System.Web.Mvc;
  using System.Web.Optimization;
  using System.Web.Routing;

  using Archie.Web.Configuration;

  /// <summary>
  /// Starting point for our application.
  /// </summary>
  public class WebApplication : HttpApplication
  {
    /// <summary>
    /// Triggers when application starts.
    /// </summary>
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
