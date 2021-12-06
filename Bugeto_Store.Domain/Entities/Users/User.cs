using Bugeto_Store.Domain.Entities.Blog;
using Bugeto_Store.Domain.Entities.Commons;
using Bugeto_Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bugeto_Store.Domain.Entities.Users
{
    public class User : BaseEntity 
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        //[ForeignKey("Author")]
        public long? AuthorId { get; set; }
        public virtual Author Author { get; set; }


    }
}
