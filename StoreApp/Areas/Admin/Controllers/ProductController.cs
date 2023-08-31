using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]

public class ProductController : Controller
{
    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Products";
        var model = _manager.ProductService.GetAllProducts(false);
        return View(model);
    }

    public IActionResult Create()
    {
        // viewbag ile view a veri taşıyabiliriz.
        ViewBag.Categories = GetCategoriesSelectList();
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot",
            "images",
            file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            productDto.ImageUrl = String.Concat("/images/", file.FileName);
            _manager.ProductService.CreateOneProduct(productDto);
            TempData["success"] = $"{productDto.ProductName} has been Created.";

            return RedirectToAction("Index");
        }
        return View();

    }

    [HttpGet]
    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
        var product = _manager.ProductService.DeleteOneProduct(id);
        TempData["danger"] = $"{product?.ProductName} has been Removed.";

        return RedirectToAction("Index");
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
        ViewBag.Categories = GetCategoriesSelectList();
        var model = _manager.ProductService.GetOneProductForUpdate(id, false);
        ViewData["Title"] = model.ProductName;
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
           "wwwroot",
           "images",
           file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            productDto.ImageUrl = String.Concat("/images/", file.FileName);

            _manager.ProductService.UpdateOneProduct(productDto);
            return RedirectToAction("Index");
        }
        return View();

    }


    private SelectList GetCategoriesSelectList()
    {
        return new SelectList(
            _manager.CategoryService.GetAllCategories(false),
            "CategoryId",
            "CategoryName",
            "1");
    }
}