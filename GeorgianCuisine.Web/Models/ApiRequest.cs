using static GeorgianCuisine.Web.StaticDetails;

namespace GeorgianCuisine.Web.Models
{
	public class ApiRequest
	{
		public ApiRequestType ApiRequestType { get; set; } = ApiRequestType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
