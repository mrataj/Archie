namespace Archie.Web.Configuration
{
  using System;
  using System.Web.Optimization;

  /// <summary>
  /// Takes care for bundle configuration.
  /// </summary>
  public static class BundleConfig
  {
    /// <summary>
    /// Add bundles to given bundle collection.
    /// </summary>
    /// <param name="bundles">Given bundle collection.</param>
    public static void RegisterBundles(BundleCollection bundles)
    {
      if (bundles == null)
      {
        throw new ArgumentNullException("bundles");
      }

      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));
      
      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.unobtrusive*",
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
    }
  }
}
