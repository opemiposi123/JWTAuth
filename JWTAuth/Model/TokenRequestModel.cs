using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Model
{
	public class TokenRequestModel
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
