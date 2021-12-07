using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bugeto_Store.Domain.Entities.Users
{
    public class UserApp : IdentityUser
    {
      
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا 0 را وارد کنید")]
        [MaxLength(120)]
        public string FullName { get; set; }

        
    }
}
