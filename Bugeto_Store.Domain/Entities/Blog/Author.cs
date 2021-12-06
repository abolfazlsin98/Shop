using Bugeto_Store.Domain.Entities.Commons;
using Bugeto_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bugeto_Store.Domain.Entities.Blog
{
    public class Author : BaseEntity
    {
           
        [ForeignKey("User")]
        public long UserId { get; set; }
        [Required]
        public User User { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
