using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BadNews.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "A category is required.")]
        [DisplayName("Category: ")]
        public string CategoryName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}