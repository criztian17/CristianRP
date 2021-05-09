using System;

namespace CristianRP.Common.Dtos
{
    /// <summary>
    /// TokenDto Class
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token Expiration
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
