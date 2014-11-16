using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class News  
    {
        [Key]
        public int Id { get; set; }
        public string Headline { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageSrc { get; set; }
        public string Lead { get; set; }
        public string BodyFileName { get; set; }
        public int ViewCount { get; set; }
    }   
}
