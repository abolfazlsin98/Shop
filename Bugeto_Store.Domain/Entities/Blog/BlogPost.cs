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
    public class BlogPost : BaseEntity
    {
        [Required]
        public string Title { get; set; }
     
        [Required]
        public string Content { get; set; }

        [ForeignKey("Author")]
        [Required]
        public long AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }


        [ForeignKey("BlogCategory")]
        [Required]
        public long BlogCategoryId { get; set; }
        [Required]
        public BlogCategory BlogCategory { get; set; }

        public ICollection<BlogInTags> BlogInTags { get; set; }

        [Required]

        public ICollection<BlogImage> BlogImages { get; set; }


        public ICollection<Comment> Comments { get; set; }
        public DateTime Published { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
