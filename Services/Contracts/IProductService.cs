using Entities.Dto;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetLatestProducts(int n, bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);

        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        Product? DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}