using GeorgianCuisine.Services.ProductApi.Models;
using GeorgianCuisine.Services.ProductApi.Models.DTO;

namespace GeorgianCuisine.Services.ProductApi.Repository
{
	public interface IProductRepository
	{
		Task<IEnumerable<ProductDTO>> GetProducts();
		Task<ProductDTO> GetProductById(int productId);
		Task<ProductDTO> AddOrUpdate(ProductDTO productDTO);
		Task<bool> DeleteProduct(int productId);
	}
}
