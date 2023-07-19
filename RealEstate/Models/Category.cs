using System;
using System.ComponentModel.DataAnnotations;
namespace RealEstate.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Category name can't be null or empty")]
		public required string Name { get; set; }
        [Required(ErrorMessage = "Image url cant be null or empty")]
        public required string ImageUrl { get; set; }
        //public string Description { get; set; }

        // one to many
        public ICollection<Property> properties { get; set; }

    }
}

