using CristianRP.BL.Helpers;
using CristianRP.BL.Interfaces;
using CristianRP.Common.Dtos;
using CristianRP.Common.Exceptions;
using CristianRP.Repository.Entities;
using CristianRP.Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CristianRP.BL.Implementations
{
    public class PropertyBL : IPropertyBL
    {
        #region Attributes
        private readonly IPropertyRepository _propertyRepository;
        #endregion

        #region Constructor
        public PropertyBL(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        #endregion

        #region Public Methods
        public async Task<PropertyDto> CreatePropertyAsync(PropertyDto property)
        {
            try
            {
                if (!ValidateModel(property))
                {
                    throw new BusinessException(400, Constants.PropertyModelErrorMessage);
                }

                var result = await _propertyRepository.CreateAsync(MapperGenericHelper<PropertyDto, PropertyEntity>.ToMapper(property));

                return MapperGenericHelper<PropertyEntity, PropertyDto>.ToMapper(result);

            }
            catch (Exception ex)
            {
                if (!(ex is BusinessException) && ex.InnerException != null)
                {
                    if (ex.InnerException.Message.ToLower().Contains("unique"))
                    {
                        throw new BusinessException(400, string.Format(Constants.PropertyExists, property.Code));
                    }
                }
                throw ex;
            }
        }

        public async Task<bool> DeletePropertyAsync(PropertyDto property)
        {
            try
            {
                if (!await _propertyRepository.ExistAsync(property.Id))
                {
                    throw new BusinessException(400, string.Format(Constants.PropertyNoExist, property.Id));
                }
                return await _propertyRepository.DeleteAsync(MapperGenericHelper<PropertyDto, PropertyEntity>.ToMapper(property));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<PropertyDto>> GetAllPropertiesAsync()
        {
            try
            {
                List<PropertyDto> list = new List<PropertyDto>();

                var result = await _propertyRepository.GetAll().ToListAsync();

                if (!result.Any())
                {
                    return list;
                }

                result.ForEach(x => list.Add(new PropertyDto
                {
                    Address = x.Address,
                    Code = x.Code,
                    Description = x.Description,
                    Id = x.Id
                }));

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PropertyDto> GetPropertyByIdAsync(int id)
        {
            try
            {
                var entity = await _propertyRepository.GetByIdAsync(id);

                if (entity == null)
                {
                    throw new BusinessException(400, string.Format(Constants.PropertyNoExist, id));
                }

                return MapperGenericHelper<PropertyEntity, PropertyDto>.ToMapper(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePropertyAsync(PropertyDto property)
        {
            try
            {
                if (!await _propertyRepository.ExistAsync(property.Id))
                {
                    throw new BusinessException(400, string.Format(Constants.PropertyNoExist, property.Id));
                }

                if (!ValidateModel(property))
                {
                    throw new BusinessException(400, Constants.PropertyModelErrorMessage);
                }

                return await _propertyRepository.UpdateAsync(MapperGenericHelper<PropertyDto, PropertyEntity>.ToMapper(property));
            }
            catch (Exception ex)
            {
                if (!(ex is BusinessException) && ex.InnerException != null)
                {
                    if (ex.InnerException.Message.ToLower().Contains("unique"))
                    {
                        throw new BusinessException(400, string.Format(Constants.PropertyExists, property.Code));
                    }
                }
                throw ex;
            }   
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validate if the model is valid
        /// </summary>
        /// <param name="property">PropertyDto object</param>
        /// <returns>bool</returns>
        private bool ValidateModel(PropertyDto property)
        {
            if (!ValidateCode(property.Code) || !ValidateDescription(property.Description) || !ValidateAddress(property.Address))
            {
                return false;
            }

            return true;
        }

        private bool ValidateCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            return true;
        }

        private bool ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return false;
            }

            return true;
        }

        private bool ValidateAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
