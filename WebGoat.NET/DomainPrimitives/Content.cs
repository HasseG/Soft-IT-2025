using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebGoatCore.DomainPrimitives
{
    // Sealed is used to combat getting around invarians using inheritance
    // Record ensures value based equality and not identity based woth overrides to built in methods
    public sealed record Content
    {
        private const string _regexPattern = @"[<>]";

        // init ensures that "set" can only be used in construction of the object
        public string value { get; init;}

        // Forced constructor for creating object
        public Content(string value)
        {
            if (value is null)
                throw new ArgumentException("Comment cannot be empty.");
            
            if (Regex.IsMatch(value, _regexPattern))
                throw new ArgumentException("Comment contains invalid characters.");

            this.value = value;
        }
    }
}