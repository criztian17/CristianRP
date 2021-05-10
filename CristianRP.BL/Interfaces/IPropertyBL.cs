using CristianRP.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CristianRP.BL.Interfaces
{
    /// <summary>
    /// Property Business Logic Interface
    /// </summary>
    public interface IPropertyBL
    {
        /// <summary>
        /// Create a Property
        /// </summary>
        /// <param name="property">PropertyDto object</param>
        /// <returns>PropertyDto object</returns>
        Task<PropertyDto> CreatePropertyAsync(PropertyDto property);

        /// <summary>
        /// Delete a Property
        /// </summary>
        /// <param name="PropertyDto">PropertyDto object</param>
        /// <returns>bool</returns>
        Task<bool> DeletePropertyAsync(PropertyDto property);

        /// <summary>
        /// Get all properties
        /// </summary>
        /// <returns>Collection of PropertyDto</returns>
        Task<ICollection<PropertyDto>> GetAllPropertiesAsync();

        /// <summary>
        /// Get a property by Id
        /// </summary>
        /// <param name="id">Property Id</param>
        /// <returns>PropertyDto object</returns>
        Task<PropertyDto> GetPropertyByIdAsync(int id);

        /// <summary>
        /// Update a Property
        /// </summary>
        /// <param name="property">PropertyDto object</param>
        /// <returns>bool</returns>
        Task<bool> UpdatePropertyAsync(PropertyDto property);
    }
}
