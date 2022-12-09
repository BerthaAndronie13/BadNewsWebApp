using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BadNews.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        [Required(ErrorMessage = "A title is required.")]
        [DisplayName("Enter the title of the article: ")]
        [StringLength(2000, ErrorMessage = "The title cannot exceed 150 characters. ")]
        public string Title { get; set; }
        [DisplayName("Write article: ")]
        [StringLength(2000, ErrorMessage = "The introduction cannot exceed 2000 characters. ")]
        public string Introduction { get; set; }
        public string Middle { get; set; }
        public string Quote { get; set; }
        public string Conclusion { get; set; }
        public string Image { get; set; }
        public string ImageCover { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
        [Required(ErrorMessage = "A category is required.")]
        [DisplayName("Category: ")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
