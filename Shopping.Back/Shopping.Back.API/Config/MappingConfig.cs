using AutoMapper;
using Shopping.API.Data.ValueObjects;
using Shopping.API.Model;

namespace Shopping.Back.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductVO, Product>();
                c.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
