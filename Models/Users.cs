    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

namespace game.Models{
    //User
    public class User{

        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="Please Input Your Name")]
        public string Name {get;set;}

        [Required(ErrorMessage="Please Input Your Email")]
        [EmailAddress]
        public string Email{get;set;}

        [Required(ErrorMessage="Please Input Your Password")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters ")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[0-9])(?=.*[@#$%^&+=!]).*$",ErrorMessage="Password Must Have At Least one number and One Special")]
        public string Password{get;set;}

        [NotMapped]
        [Required(ErrorMessage="Please Input Confirmation Password")]
        [Compare("Password",ErrorMessage="Passwords Must Be Matched")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}
    }
    public class Login{

        [EmailAddress]
        public string Email {get; set;}

        [DataType(DataType.Password)]
        public string Password { get; set; }

        }
    
}