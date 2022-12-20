using System.Collections.Generic;
using System.Security.Claims;

namespace Minesweeper.Models.User
{
    public class CustomUserIdentity : ClaimsIdentity
    {
		public int ID { get; set; }

		public CustomUserIdentity(Entities.User user, string authenticationType = "Cookie") : base(GetUserClaims(user), authenticationType)
        {
            ID = user.ID;
        }

		private static List<Claim> GetUserClaims(Entities.User user)
		{
			var result = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Login),
				new Claim(ClaimTypes.Role, "Admin"),
			};
			
			return result;
		}
	}
}
