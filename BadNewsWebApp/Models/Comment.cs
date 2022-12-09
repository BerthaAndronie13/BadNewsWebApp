using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace BadNews.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public int Review { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }

    }
}
