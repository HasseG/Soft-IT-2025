using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebGoatCore.Models
{
    public class ContentDomainPrimitive
    {
        private const string _regexPattern = @"[<>]";
        private const int _maxContentLength = 500;
        private string value;

        public ContentDomainPrimitive(string value)
        {
            IsContentNull(value);
            IsContentLengthValid(value);
            IsContentValid(value);
            this.value = value;
        }

        public string GetValue()
        {
            return value;
        }

        private void IsContentNull(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("Content cannot be empty.");
            }
        }

        private void IsContentValid(string value)
        {
            if (Regex.IsMatch(value, _regexPattern))
            {
                throw new ArgumentException("Content contains invalid characters.");
            }
        }

        private void IsContentLengthValid(string value)
        {
            if (value.Length > _maxContentLength)
            {
                throw new ArgumentException("Content length exceeds the maximum allowed limit of 500 characters.");
            }
        }
    }
}
