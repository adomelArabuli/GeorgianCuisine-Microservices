using AutoMapper;
using GeorgianCuisine.Services.ProductApi.Data;
using GeorgianCuisine.Services.ProductApi.Models;
using GeorgianCuisine.Services.ProductApi.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GeorgianCuisine.Services.ProductApi.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _db;
		private IMapper _mapper;
		public ProductRepository(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ProductDTO>> GetProducts()
		{
			var products = await _db.Products.ToListAsync();
			//return _mapper.Map<List<ProductDTO>>(products);
			return products.Select(p => _mapper.Map<ProductDTO>(p)).ToList();
		}

		public async Task<ProductDTO> GetProductById(int productId)
		{
			//var product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
			var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<ProductDTO> AddOrUpdate(ProductDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO);
			if (product.ProductId > 0) 
			{
				_db.Products.Update(product);
			}
			else
			{
				await _db.Products.AddAsync(product);
			}
			await _db.SaveChangesAsync();

			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			try
			{
				var productToDelete = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
				if (productToDelete == null)
				{
					return false;
				}
				_db.Products.Remove(productToDelete);
				await _db.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		


		
	}
}
