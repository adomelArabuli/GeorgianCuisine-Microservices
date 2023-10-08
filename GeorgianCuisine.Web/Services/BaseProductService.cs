using GeorgianCuisine.Web.Models;
using GeorgianCuisine.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GeorgianCuisine.Web.Services
{
	public class BaseProductService : IBaseProductService
	{
		public ResponseDTO ResponseModel { get; set; }
		public IHttpClientFactory HttpClient { get; set; }

		public BaseProductService(IHttpClientFactory httpClient)
		{
			ResponseModel = new ResponseDTO();
			HttpClient = httpClient;
		}

		public async Task<T> SendAsync<T>(ApiRequest apiRequest)
		{
			try
			{
				var client = HttpClient.CreateClient("GeorgianCuisineApi");
				var message = new HttpRequestMessage();
				message.Headers.Add("Accept", "application/json");
				message.RequestUri = new Uri(apiRequest.Url);
				client.DefaultRequestHeaders.Clear();
				if (apiRequest.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8, "application/json");
				}

				if (!string.IsNullOrEmpty(apiRequest.AccessToken))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
				}

				HttpResponseMessage apiResponse = null;

				switch (apiRequest.ApiRequestType)
				{
					case StaticDetails.ApiRequestType.POST:
						message.Method = HttpMethod.Post;
						break;
					case StaticDetails.ApiRequestType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case StaticDetails.ApiRequestType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}

				apiResponse = await client.SendAsync(message);

				var apiContent = await apiResponse.Content.ReadAsStringAsync();

				var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);

				return apiResponseDTO;
			}
			catch (Exception ex)
			{
				var dto = new ResponseDTO
				{
					DisplayMessage = "Error",
					ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
					Success = false
				};

				var res = JsonConvert.SerializeObject(dto);
				var apiResponseDTO = JsonConvert.DeserializeObject<T>(res);

				return apiResponseDTO;
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}
