using System.Web.Mvc;

namespace Blog.WebUI.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString ListStringItems(this HtmlHelper html, string[] list, string type, string name, object htmlAttributes = null)
        {
            TagBuilder tag = new TagBuilder("ul");
            foreach (string str in list)
            {
                TagBuilder listItemTag = new TagBuilder("li");
                TagBuilder inputItemTag = new TagBuilder("input");
                TagBuilder spanItemTag = new TagBuilder("span");
                spanItemTag.SetInnerText(str);
                inputItemTag.MergeAttribute("name", name);
                inputItemTag.MergeAttribute("class", "form-check-input");
                inputItemTag.MergeAttribute("type", type);
                inputItemTag.MergeAttribute("value", str);
                listItemTag.AddCssClass("marker");
                listItemTag.InnerHtml += inputItemTag.ToString();
                listItemTag.InnerHtml += spanItemTag.ToString();

                tag.InnerHtml += listItemTag.ToString();
            }
            tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return new MvcHtmlString(tag.ToString());
        }
    }
}