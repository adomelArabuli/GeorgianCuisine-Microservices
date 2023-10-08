using AutoMapper;
using GeorgianCuisine.Services.ProductApi.Models;
using GeorgianCuisine.Services.ProductApi.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GeorgianCuisine.Services.ProductApi
{
	public class MappingProfile
	{
		public static MapperConfiguration RegisterMappings()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<Product, ProductDTO>().ReverseMap();
			});
			return mappingConfig;
		}
	}
}
