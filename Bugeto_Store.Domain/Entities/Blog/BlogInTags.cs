using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugeto_Store.Domain.Entities.Commons;

namespace Bugeto_Store.Domain.Entities.Blog
{
    public class BlogInTags : BaseEntity
    {
        public long BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        public long TagsId { get; set; }
        public Tags Tags { get; set; }
    }
}
