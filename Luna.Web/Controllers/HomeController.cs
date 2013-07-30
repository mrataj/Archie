namespace Luna.Web.Controllers
{
  using System.Web.Mvc;

  /// <summary>
  /// Simple home controller.
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// Gets default view.
    /// </summary>
    /// <returns>View result with home view.</returns>
    public ActionResult Index()
    {
      return this.View("~/Views/Home/Home.cshtml");
    }
  }
}
