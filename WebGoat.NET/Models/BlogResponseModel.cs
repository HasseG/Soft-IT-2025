using System;

namespace WebGoatCore.Models
{
    public class BlogResponseModel
    {
        public int Id { get; set; }
        public int BlogEntryId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Author { get; set; }
        private ContentDomainPrimitive contentDomainPrimitive;

        public virtual BlogEntry BlogEntry { get; set; }

        public BlogResponseModel(int blogEntryId, DateTime responseDate, string author, ContentDomainPrimitive contentDomainPrimitive)
        {
            BlogEntryId = blogEntryId;
            ResponseDate = responseDate;
            Author = author;
            this.contentDomainPrimitive = contentDomainPrimitive;
        }

        public string GetBlogResponseContent()
        {
            return contentDomainPrimitive.GetValue();
        }
    }
}
