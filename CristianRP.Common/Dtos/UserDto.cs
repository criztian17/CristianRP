namespace CristianRP.Common.Dtos
{
    /// <summary>
    /// UserDto Class
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// UserDto Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// UserDto Password
        /// </summary>
        public string Pwd { get; set; }
    }
}
