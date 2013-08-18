namespace Archie.Web.Models
{
  using Archie.Web.Models.Routes;

  /// <summary>
  /// Model for home view.
  /// </summary>
  public class HomeModel
  {
    /// <summary>
    /// Gets or sets message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets collection of routes.
    /// </summary>
    public RoutesModel Routes { get; set; }
  }
}
