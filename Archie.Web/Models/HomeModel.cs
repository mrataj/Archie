namespace Archie.Web.Models
{
  using System.Collections.Generic;
  
  /// <summary>
  /// Model for home view.
  /// </summary>
  public class HomeModel
  {
    /// <summary>
    /// Initializes a new instance of the HomeModel class.
    /// </summary>
    public HomeModel()
    {
      this.Routes = new List<RouteModel>();
    }
    
    /// <summary>
    /// Gets list of registered url routes on server.
    /// </summary>
    public IList<RouteModel> Routes { get; private set; }
  }
}
