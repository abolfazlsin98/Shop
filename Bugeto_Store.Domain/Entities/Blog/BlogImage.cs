using Bugeto_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Domain.Entities.Blog
{
    public class BlogImage : BaseEntity
    {
        [Required]
        public virtual BlogPost BlogPost { get; set; }
        [Required]
        public long BlogPostId { get; set; }
        public string Src { get; set; }

    }
}
