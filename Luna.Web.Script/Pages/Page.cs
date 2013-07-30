namespace Luna.Web.Script.Pages
{
  using System.Html;

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
      Window.Document.Title = "Hello, Luna!";
    }
  }
}
