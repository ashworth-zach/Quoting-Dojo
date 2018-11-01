using System;
namespace quotes.Models
{
    public class Quote
    {
        public string name{get;set;}
        public string content{get;set;}
        public Quote(string username, string contents)
        {
            content=contents;
            name=username;
        }
    }
}