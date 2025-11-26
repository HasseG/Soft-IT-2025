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
    }
}