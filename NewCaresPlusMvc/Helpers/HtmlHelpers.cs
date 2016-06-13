using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewCaresPlusMvc.Helpers
{
    public static class HtmlHelpers
    {
        public static string MakeActive(this UrlHelper urlHelper, string view)
        {
            var result = "active";

            var name = urlHelper.RequestContext.RouteData.Values["name"] ?? urlHelper.RequestContext.RouteData.Values["action"];
            var viewName = string.Empty;

            if (name != null)
                viewName = name.ToString();

            if (!viewName.Equals(view, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return result;
        }

        public static IHtmlString ValuedCheckBox(this HtmlHelper helper, string name, string value, bool selected = false)
        {
            string html;

            if (selected)
                html = @"<input type=""checkbox"" name=""{0}"" value=""{1}"" checked=""checked"" />";
            else
                html = @"<input type=""checkbox"" name=""{0}"" value=""{1}"" />";

            return helper.Raw(string.Format(html, name, value));
        }

        public static MvcHtmlString LabelForWithAsterisk<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), new RouteValueDictionary(htmlAttributes));
        }

        private static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, IDictionary<string, object> htmlAttributes)
        {
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (string.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var sb = new StringBuilder();
            sb.Append(labelText);

            if (metadata.IsRequired)
                sb.Append("<span class='text-danger'>&nbsp;&nbsp;*</span>");

            var tag = new TagBuilder("label");

            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.MergeAttributes(htmlAttributes);
            tag.InnerHtml = sb.ToString();

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}