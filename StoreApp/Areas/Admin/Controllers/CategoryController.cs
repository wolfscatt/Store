using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    private readonly IServiceManager _manager;

    public CategoryController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        return View(_manager.CategoryService.GetAllCategories(false));
    }
     public IActionResult Create()
    {
        // viewbag ile view a veri taşıyabiliriz.
        var categories = _manager.CategoryService.GetAllCategories(false);
        return View();
    }
}