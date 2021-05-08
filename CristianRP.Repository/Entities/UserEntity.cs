using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CristianRP.Repository.Entities
{
    public class UserEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// User Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Pwd { get; set; }
    }
}
