using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebGoatCore.Models
{
    public class BlogResponseContent
    {
        public int Id { get; set; }
        private const string _regexPattern = @"[<>]";
        private string content;
        
        virtual public string Content
        {
            get => content;
            private set => content = value;
        }

        protected BlogResponseContent() { }

        public BlogResponseContent(string content)
        {
            IsContentValid(content);
            this.content = content;
        }

        private void IsContentValid(string content)
        {
            if (Regex.IsMatch(content, _regexPattern))
            {
                throw new ArgumentException("You cannot use krokodillenæb");
            }
        }

        public int BlogResponseId { get; set; }
        public virtual BlogResponse BlogResponse { get; set; }

    }
}