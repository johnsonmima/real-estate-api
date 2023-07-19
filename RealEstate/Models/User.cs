using System;
namespace RealEstate.Models
{
	public class User
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


        // one to many
        public ICollection<Property> properties { get; set; }
    }
}

