using System.ComponentModel.DataAnnotations;
using System;
namespace quotes.Models
{
    public class Quote
    {
        [Required]
        [MinLength(4)]
        public string name{get;set;}
        [Required]
        [MinLength(4)]
        public string content{get;set;}
        public Quote(string username, string contents)
        {
            content=contents;
            name=username;
        }
    }
}