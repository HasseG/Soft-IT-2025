using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebGoatCore.Models
{
    public class BlogResponseContent
    {
        private const string _regexPattern = @"[<>]";
        private string value;

        public BlogResponseContent(string value)
        {
            IsContentValid(value);
            this.value = value;
        }

        public string GetValue()
        {
            return value;
        }

        private void IsContentValid(string value)
        {
            if (Regex.IsMatch(value, _regexPattern))
            {
                throw new ArgumentException("Content contains invalid characters.");
            }
        }
    }
}