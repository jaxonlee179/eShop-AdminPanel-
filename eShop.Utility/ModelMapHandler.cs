using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Utility
{
    public static class ModelMapHandler
    {
        static MapperConfiguration _config;

        public static TDestination BuildModelMapping<TSource,TDestination>(TSource source, TDestination destination) where TSource : class where TDestination : class
        {
            _config = new MapperConfiguration(cfg => {
                cfg.CreateMap(source.GetType(), destination.GetType());
            });

            var mapper = new Mapper(_config);
            return mapper.Map(source, destination);
        }
    }
}
