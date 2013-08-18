namespace Archie.Web.Script.Pages
{
  using System.Collections.Generic;
  using System.Html;
  using System.Serialization;

  using Archie.Web.Script.Engine;
  using Archie.Web.Script.Models;

  using jQueryApi;

  /// <summary>
  /// Simple page base class.
  /// </summary>
  public class Page
  {
    /// <summary>
    /// Initializes a new instance of the Page class.
    /// </summary>
    public Page()
    {
      Window.Document.Title = "Hello, Archie!";
      Url.RegisterRoutes(this.GetRoutes());
    }

    /// <summary>
    /// Gets routes from DOM.
    /// </summary>
    /// <returns>Routes collection.</returns>
    private List<RouteModel> GetRoutes()
    {
      string json = jQuery.Select("input[name='Model/Routes']").GetValue();
      return Json.ParseData<List<RouteModel>>(json);
    }
  }
}
