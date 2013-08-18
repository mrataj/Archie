namespace Archie.Web.Script.Pages
{
  using System.Html;

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
      Window.Document.Title = this.GetRoutesJson();
    }

    /// <summary>
    /// Gets routes json from DOM.
    /// </summary>
    /// <returns>Routes collection.</returns>
    private string GetRoutesJson()
    {
      return jQuery.Select("#routes").GetAttribute("data-collection");
    }
  }
}
