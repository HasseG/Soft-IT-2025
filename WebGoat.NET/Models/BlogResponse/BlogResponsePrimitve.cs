using System;

namespace WebGoatCore.Models
{
    public class BlogResponsePrimitive
    {
        public int Id { get; set; }
        public int BlogEntryId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Author { get; set; }
        private BlogResponseContent _blogResponseContent;

        public virtual BlogEntry BlogEntry { get; set; }

        public BlogResponsePrimitive(int blogEntryId, DateTime responseDate, string author, BlogResponseContent blogResponseContent)
        {
            BlogEntryId = blogEntryId;
            ResponseDate = responseDate;
            Author = author;
            _blogResponseContent = blogResponseContent;
        }

        public string GetBlogResponseContent()
        {
            return _blogResponseContent.GetValue();
        }
    }
}
