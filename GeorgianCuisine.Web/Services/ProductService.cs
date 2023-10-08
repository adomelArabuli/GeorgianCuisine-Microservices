using GeorgianCuisine.Web.Models;
using GeorgianCuisine.Web.Services.IServices;

namespace GeorgianCuisine.Web.Services
{
	public class ProductService : BaseProductService, IProductService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<T> CreateProductAsync<T>(ProductDTO productDTO, string token)
		{
			return await SendAsync<T>(new ApiRequest()
			{
				ApiRequestType = StaticDetails.ApiRequestType.POST,
				Data = productDTO,
				Url = $"{StaticDetails.ProductApiBaseUrl}/api/products",
				AccessToken = token
			});
		}

		public async Task<T> DeleteProductAsync<T>(int id, string token)
		{
			return await SendAsync<T>(new ApiRequest()
			{
				ApiRequestType = StaticDetails.ApiRequestType.DELETE,
				Url = $"{StaticDetails.ProductApiBaseUrl}/api/products/{id}",
				AccessToken = token
            });
		}

		public async Task<T> GetAllProductsAsync<T>(string token)
		{
			return await SendAsync<T>(new ApiRequest()
			{
				ApiRequestType = StaticDetails.ApiRequestType.GET,
				Url = $"{StaticDetails.ProductApiBaseUrl}/api/products",
				AccessToken = token
			});
		}

		public async Task<T> GetProductByIdAsync<T>(int id, string token)
		{
			return await SendAsync<T>(new ApiRequest()
			{
				ApiRequestType = StaticDetails.ApiRequestType.GET,
				Url = $"{StaticDetails.ProductApiBaseUrl}/api/products/{id}",
				AccessToken = token
            });
		}

		public async Task<T> UpdateProductAsync<T>(ProductDTO productDTO, string token)
		{
			return await SendAsync<T>(new ApiRequest()
			{
				ApiRequestType = StaticDetails.ApiRequestType.PUT,
				Data = productDTO,
				Url = $"{StaticDetails.ProductApiBaseUrl}/api/products",
				AccessToken = token
            });
		}
	}
}
