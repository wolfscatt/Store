using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]

public class OrderController : Controller
{
    private readonly IServiceManager _maanger;

    public OrderController(IServiceManager maanger)
    {
        _maanger = maanger;
    }

    public IActionResult Index()
    {
        var orders = _maanger.OrderService.Orders;
        return View(orders);
    }
    [HttpPost]
    public IActionResult Complete([FromForm] int id)
    {
        _maanger.OrderService.Complete(id);
        return RedirectToAction("Index");
    }
}