namespace Luna.Web.Configuration
{
  using System;
  using System.Web.Mvc;

  /// <summary>
  /// Takes care for registering all filters.
  /// </summary>
  public static class FilterConfig
  {
    /// <summary>
    /// Adds filters to given filter collection.
    /// </summary>
    /// <param name="filters">Given filter collection.</param>
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      if (filters == null)
      {
        throw new ArgumentNullException("filters");
      }

      filters.Add(new HandleErrorAttribute());
    }
  }
}
