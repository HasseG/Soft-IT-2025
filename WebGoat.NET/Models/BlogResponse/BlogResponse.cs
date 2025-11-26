using System;

namespace WebGoatCore.Models
{
    public class BlogResponse
    {
        public int Id { get; set; }
        public int BlogEntryId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Author { get; set; }
        public string Contents { get; set; }

        public virtual BlogEntry BlogEntry { get; set; }

        // Empty constructor for EF
        public BlogResponse() {}

        // Constructor to create BlogResponse (DTO) from BlogResponsePrimitive
        public BlogResponse(BlogResponsePrimitive primitive)
        {
            Id = primitive.Id;
            BlogEntryId = primitive.BlogEntryId;
            ResponseDate = primitive.ResponseDate;
            Author = primitive.Author;
            Contents = primitive.GetBlogResponseContent();
        }
    }
}
