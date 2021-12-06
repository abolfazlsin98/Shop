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
    public class BlogCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
