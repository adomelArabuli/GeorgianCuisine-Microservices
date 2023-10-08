using AutoMapper;

namespace GeorgianCuisine.Services.ShoppingCartApi
{
    public class MappingProfile
    {
        public static MapperConfiguration RegisterMappings()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
