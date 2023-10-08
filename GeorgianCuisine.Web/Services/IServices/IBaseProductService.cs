using GeorgianCuisine.Web.Models;

namespace GeorgianCuisine.Web.Services.IServices
{
	public interface IBaseProductService : IDisposable
	{
		ResponseDTO ResponseModel { get; set; }
		Task<T> SendAsync<T>(ApiRequest apiRequest);
	}
}
