using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bugeto_Store.Domain.Entities.Users
{
    public class UserApp 
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا 0 را وارد کنید")]
        [MaxLength(120)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا 0 را وارد کنید")]
        [MaxLength(120)]
        public string Family { get; set; }

        [Display(Name = "تاریخ ایجاد حساب")] public DateTime CreatedTime { get; set; } = DateTime.Now;

        [Display(Name = "تاریخ فعال سازی حساب")]
        public DateTime? ExpireActivationTime { get; set; } = null;

        public bool IsActive { get; set; } = false;
        public string UserCode { get; set; } = new Random().Next(100000, 999999).ToString();
        public string LoginCode { get; set; }
        public DateTime ExpireLoginCode { get; set; }
    }
}
