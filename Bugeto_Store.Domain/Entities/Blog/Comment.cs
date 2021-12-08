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
    public class Comment : BaseEntity
    {
        [Required]
        public string Content { get; set; }

        [ForeignKey("BlogPost")]
        [Required]

        public long? BlogPostId { get; set; }
        [Required]
        public virtual BlogPost BlogPost { get; set; }

        public bool IsAccepted { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        [ForeignKey("User")]
        [Required]
        public long? UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
        public DateTime Published { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
