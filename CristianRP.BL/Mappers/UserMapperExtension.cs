using AutoMapper;
using CristianRP.Common.Dtos;
using CristianRP.Repository.Entities;

namespace CristianRP.BL.Mappers
{
    public static class UserMapperExtension
    {
        public static UserEntity ToEntityMapper(this UserDto userDto)
        {
            var config = new MapperConfiguration(mc => mc.CreateMap<UserDto , UserEntity>());
            var mapper = new Mapper(config);

            return mapper.Map<UserDto, UserEntity>(userDto);
        }

        public static UserDto ToUserDtoMapper(this UserEntity userEntity)
        {
            var config = new MapperConfiguration(mc => mc.CreateMap<UserEntity, UserDto>());
            var mapper = new Mapper(config);

            return mapper.Map<UserEntity, UserDto>(userEntity);
        }
    }
}
