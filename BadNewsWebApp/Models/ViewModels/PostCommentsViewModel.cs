using System.Collections.Generic;
using BadNews.Models;

namespace BadNewsWebApp.Models.ViewModels
{
    public class PostCommentsViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
