using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheURLShortener.Models
{
    public class URLEntity
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
    }
}
