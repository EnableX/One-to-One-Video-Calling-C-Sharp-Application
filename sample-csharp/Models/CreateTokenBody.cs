using System.ComponentModel.DataAnnotations;

namespace EnableX.Models
{
    /// <summary>
    /// EnableX token request object model
    /// </summary>
    class CreateTokenBody
    {
        // Name of the user who is creating token to join session
        [Required]
        public string name { get; set; }
        // Role of User
        [Required]
        public string role { get; set; }
        // User ID or Reference
        [Required]
        public string user_ref { get; set; }
        // EnableX room id
        [Required]
        public string roomId { get; set; }
    }
}
