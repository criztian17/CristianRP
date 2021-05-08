using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CristianRP.Repository.Entities
{
    public class PropertyEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Property Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Property Code
        /// </summary>
        public string Code { get; set; }
    }
}
