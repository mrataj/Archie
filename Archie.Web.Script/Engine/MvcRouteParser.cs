namespace Archie.Web.Script.Engine
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// ASP.NET MVC route parser engine.
  /// </summary>
  internal class MvcRouteParser : RouteParser
  {
    /// <summary>
    /// Parse url from route path and given parameters.
    /// </summary>
    /// <param name="routePath">Route path.</param>
    /// <param name="parameters">Url parameters.</param>
    /// <returns>Generated url.</returns>
    protected override string Parse(string routePath, Dictionary<string, string>[] parameters)
    {
      string url = routePath;

      foreach (Dictionary<string, string> parameter in parameters)
      {
        string parameterName = parameter.Keys[0];
        string parameterValue = parameter[parameterName];

        string searchPattern1 = "{" + parameterName + "}";
        if (url.IndexOf(searchPattern1) >= 0)
        {
          url = url.Replace(searchPattern1, parameterValue);
        }
        else
        {
          string searchPattern2 = "{*" + parameterName + "}";
          if (url.IndexOf(searchPattern2) >= 0)
          {
            url = url.Replace(searchPattern2, parameterValue);
          }
          else
          {
            url = this.AppendQueryParameter(url, parameterName, parameterValue);
          }
        }
      }

      url = this.RemoveUnusedParameters(url);

      return url;
    }

    #region Private
    
    /// <summary>
    /// Removes unused parameters from given url.
    /// </summary>
    /// <param name="url">Given url.</param>
    /// <returns>Url without unused parameters.</returns>
    private string RemoveUnusedParameters(string url)
    {
      RegularExpression regex = new RegularExpression("{.*}");
      url = url.ReplaceRegex(regex, string.Empty);
      url = this.RemoveTrailingSlash(url);
      return url;
    }

    /// <summary>
    /// Removes trailing slash from given url.
    /// </summary>
    /// <param name="url">Given url.</param>
    /// <returns>Url without trailing slash.</returns>
    private string RemoveTrailingSlash(string url)
    {
      if (url.EndsWith("/"))
      {
        // Remove slash at the end
        return url.Substring(0, url.Length - 1);
      }

      // Remove slash if it comes before ? character
      url = url.Replace("/?", string.Empty);

      return url;
    }

    #endregion
  }
}
