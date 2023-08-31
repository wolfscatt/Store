using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructere.TagHelpers;


[HtmlTargetElement("div", Attributes = "products")]
public class LatestProductTagHelper : TagHelper
{
    private readonly IServiceManager _manager;
    [HtmlAttributeName("number")]
    public int Number { get; set; }

    public LatestProductTagHelper(IServiceManager manager)
    {
        _manager = manager;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var div = new TagBuilder("div");
        div.Attributes.Add("class", "my-3");

        var h6 = new TagBuilder("div");
        h6.Attributes.Add("class", "lead");

        var icon = new TagBuilder("i");
        icon.Attributes.Add("class", "fa-solid fa-box-archive");

        var ul = new TagBuilder("ul");
        var products = _manager.ProductService.GetLatestProducts(Number, false);
        foreach (var product in products)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");
            a.Attributes.Add("href", $"/product/get/{product.ProductId}");
            li.InnerHtml.AppendHtml(a);
            a.InnerHtml.AppendHtml(product.ProductName);
            ul.InnerHtml.AppendHtml(li);

        }


        h6.InnerHtml.AppendHtml(icon);
        h6.InnerHtml.AppendHtml("Latest Products");

        div.InnerHtml.AppendHtml(h6);
        div.InnerHtml.AppendHtml(ul);

        output.Content.AppendHtml(div);
    }
}