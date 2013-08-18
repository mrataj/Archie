namespace Archie.Web.Script.Models
{
  using System.Runtime.CompilerServices;

  /// <summary>
  /// Model with information about route.
  /// </summary>
  [Imported, IgnoreNamespace, ScriptName("Object")]
  public class RouteModel
  {
    /// <summary>
    /// Gets or sets url pattern for this route.
    /// </summary>
    public string Url;

    /// <summary>
    /// Gets or sets name of this route.
    /// </summary>
    public string Name;
  }
}
