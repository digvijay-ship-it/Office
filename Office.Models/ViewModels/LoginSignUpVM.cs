using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Models.ViewModels
{
    public class LoginSignUpViewModel
    {

        public int Id { get; set; }
public string Username { get; set; }
public string Email { get; set; }
public long Mobile { get; set; }
public string Password { get; set; }
public string ConfirmPassword { get; set; }
public bool IsActive { get; set; }
public bool IsRemember { get; set; }
    }
}
