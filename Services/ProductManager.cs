using AutoMapper;
using Entities.Dto;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;
namespace Services;

public class ProductManager : IProductService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public ProductManager(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public void CreateOneProduct(ProductDtoForInsertion productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _manager.Product.Create(product);
        _manager.Save();
    }

    public Product DeleteOneProduct(int id)
    {
        var product = GetOneProduct(id, false);
        if (product is not null)
        {
            _manager.Product.DeleteOneProduct(product);
            _manager.Save();
            return product;
        }
        return new Product();

    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        return _manager.Product.GetAllProducts(trackChanges);
    }

    public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
    {
        return _manager.Product.GetAllProductsWithDetails(p);
    }

    public IEnumerable<Product> GetLatestProducts(int n, bool trackChanges)
    {
        return _manager.Product.FindAll(trackChanges)
        .OrderByDescending(prd => prd.ProductId)
        .Take(n);

    }

    public Product? GetOneProduct(int id, bool trackChanges)
    {
        var product = _manager.Product.GetOneProduct(id, trackChanges);

        return product is null
        ? throw new Exception("Product Not Found!")
        : product;
    }

    public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
    {
        var product = GetOneProduct(id, trackChanges);
        return _mapper.Map<ProductDtoForUpdate>(product);
    }

    public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
    {
        var products = _manager.Product.GetShowcaseProducts(trackChanges);
        return products;
    }

    public void UpdateOneProduct(ProductDtoForUpdate productDto)
    {
        // var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
        // entity.ProductName = productDto.ProductName;
        // entity.Price = productDto.Price;
        // entity.CategoryId = productDto.CategoryId;

        var product = _mapper.Map<Product>(productDto);
        _manager.Product.UpdateOneProduct(product);

        _manager.Save();
    }
}
