﻿using AutoMapper;
using System.Collections.Generic;

namespace CristianRP.BL.Helpers
{
    public static class MapperGenericHelper<T, C>
    {
        public static C ToMapper(T model)
        {
            var config = new MapperConfiguration(mc => mc.CreateMap<T, C>());
            var mapper = new Mapper(config);

            return mapper.Map<T, C>(model);
        }
    }
}
