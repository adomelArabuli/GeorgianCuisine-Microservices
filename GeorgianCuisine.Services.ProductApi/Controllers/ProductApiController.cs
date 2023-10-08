using GeorgianCuisine.Services.ProductApi.Models.DTO;
using GeorgianCuisine.Services.ProductApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeorgianCuisine.Services.ProductApi.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductApiController : ControllerBase
	{
		protected ResponseDTO _response;
		private IProductRepository _productRepository;

		public ProductApiController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
			_response = new ResponseDTO();
		}

		[HttpGet]
		public async Task<object> Get()
		{
			try
			{
				var products = await _productRepository.GetProducts();
				_response.Result = products;
			}
			catch (Exception ex)
			{
				_response.Success = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpGet]
        [Route("{id}")]
		public async Task<object> Get(int id)
		{
			try
			{
				var product = await _productRepository.GetProductById(id);
				_response.Result = product;
			}
			catch (Exception ex)
			{
				_response.Success = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDTO productDTO)
		{
			try
			{
				var product = await _productRepository.AddOrUpdate(productDTO);
				_response.Result = product;
			}
			catch (Exception ex)
			{
				_response.Success = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDTO productDTO)
		{
			try
			{
				var product = await _productRepository.AddOrUpdate(productDTO);
				_response.Result = product;
			}
			catch (Exception ex)
			{
				_response.Success = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("{id}")]
		public async Task<object> Delete(int id)
		{
			try
			{
				var success = await _productRepository.DeleteProduct(id);
				_response.Result = success;
			}
			catch (Exception ex)
			{
				_response.Success = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}
	}
}
