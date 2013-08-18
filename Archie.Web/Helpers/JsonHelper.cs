namespace Archie.Web.Helpers
{
  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;
  using System.Web.Mvc;

  using Newtonsoft.Json;

  /// <summary>
  /// Provides helper methods for rendering model data in view.
  /// </summary>
  public static class JsonHelper
  {
    /// <summary>
    /// Gets input element with given property as a value.
    /// </summary>
    /// <typeparam name="TModel">Type of a model.</typeparam>
    /// <typeparam name="TProperty">Property on a model.</typeparam>
    /// <param name="htmlHelper">Html helper to extend.</param>
    /// <param name="expression">Expression containing model and property to be rendered.</param>
    /// <returns>MVC html string.</returns>
    public static MvcHtmlString JsonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
      return JsonFor(htmlHelper, expression, null);
    }

    /// <summary>
    /// Gets input element with given property as a value.
    /// </summary>
    /// <typeparam name="TModel">Type of a model.</typeparam>
    /// <typeparam name="TProperty">Property on a model.</typeparam>
    /// <param name="htmlHelper">Html helper to extend.</param>
    /// <param name="expression">Expression containing model and property to be rendered.</param>
    /// <param name="htmlAttributes">Additional html attributes.</param>
    /// <returns>MVC html string.</returns>
    public static MvcHtmlString JsonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
    {
      return JsonFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Gets input element with given property as a value.
    /// </summary>
    /// <typeparam name="TModel">Type of a model.</typeparam>
    /// <typeparam name="TProperty">Property on a model.</typeparam>
    /// <param name="htmlHelper">Html helper to extend.</param>
    /// <param name="expression">Expression containing model and property to be rendered.</param>
    /// <param name="htmlAttributes">Additional html attributes.</param>
    /// <returns>MVC html string.</returns>
    public static MvcHtmlString JsonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
    {
      if (expression == null)
      {
        throw new ArgumentNullException("expression");
      }

      if (htmlHelper == null)
      {
        throw new ArgumentNullException("htmlHelper");
      }

      var name = ExpressionHelper.GetExpressionText(expression);
      var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

      var tagBuilder = new TagBuilder("input");
      tagBuilder.MergeAttributes(htmlAttributes);
      tagBuilder.MergeAttribute("name", name);
      tagBuilder.MergeAttribute("type", "hidden");

      var json = JsonConvert.SerializeObject(metadata.Model);

      tagBuilder.MergeAttribute("value", json);

      return MvcHtmlString.Create(tagBuilder.ToString());
    }
  }
}
