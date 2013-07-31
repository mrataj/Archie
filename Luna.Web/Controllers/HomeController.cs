namespace Luna.Web.Controllers
{
  using System.Web.Mvc;

  using Luna.Web.Models;

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
      var model = new HomeModel { Message = "Hello, Luna!" };
      return this.View("~/Views/Home/Home.cshtml", model);
    }
  }
}
