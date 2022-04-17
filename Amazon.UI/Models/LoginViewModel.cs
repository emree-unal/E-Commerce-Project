using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ad boş geçilemez.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre alanı zorunludur.")]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
