
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugeto_Store.Domain.Entities.Commons;

namespace Bugeto_Store.Domain.Entities.Blog
{
    public class BlogInTags : BaseEntity
    {
        [Required]
        public long BlogPostId { get; set; }

        [Required]
        public BlogPost BlogPost { get; set; }

        [Required]
        public long TagsId { get; set; }
        [Required]
        public Tags Tags { get; set; }
    }
}
