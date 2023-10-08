namespace GeorgianCuisine.Web
{
	public static class StaticDetails
	{
		public static string ProductApiBaseUrl { get; set; }
		public enum ApiRequestType
		{
			GET,
			POST,
			PUT,
			DELETE
		}
	}
}
