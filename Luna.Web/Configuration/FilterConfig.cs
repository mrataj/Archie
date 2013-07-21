namespace Luna.Web.Configuration
{
  using System.Web.Mvc;

  /// <summary>
  /// Takes care for registering all filters.
  /// </summary>
  public class FilterConfig
  {
    /// <summary>
    /// Adds filters to given filter collection.
    /// </summary>
    /// <param name="filters">Given filter collection.</param>
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
