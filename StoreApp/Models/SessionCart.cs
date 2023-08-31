using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructere.Extensions;

namespace StoreApp.Models;


public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; } 

    public static Cart GetCart(IServiceProvider services){

        var session = services.GetRequiredService<IHttpContextAccessor>()
        .HttpContext?.Session;

        var cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
        cart.Session = session;

        return cart;
    }

    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson<SessionCart>("cart",this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("cart");
    }

    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.SetJson<SessionCart>("cart",this);
    }
}