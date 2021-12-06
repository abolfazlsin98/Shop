using Bugeto_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bugeto_Store.Domain.Entities.Blog
{
    public class Tags : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<BlogInTags> BlogInTags { get; set; }

        public DateTime Published { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }



    }
}
