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
        [Column("user_name")]
        public string UserName {get;set;}

        [Required(ErrorMessage="Please Input Your Email")]
        [EmailAddress]
        [Column("email")]
        public string Email{get;set;}

        [Required(ErrorMessage="Please Input Your Password")]
        [DataType(DataType.Password)]
        [Column("pw")]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters ")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[0-9])(?=.*[@#$%^&+=!]).*$",ErrorMessage="Password Must Have At Least one number and One Special")]
        public string Password{get;set;}


        [NotMapped]
        [Required(ErrorMessage="Please Input Confirmation Password")]
        [Compare("Password",ErrorMessage="Passwords Must Be Matched")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public bool Wizard{get;set;}
        public bool Samurai{get;set;}
        public bool Archer{get;set;}

    }

    public class Characters{
        [Key]
        public int CharId{get;set;}

        public int Strength{get;set;} 

        public int Dexterity {get;set;}

        public int Health {get;set;}
        public int Level {get;set;}
        public int Exp{get;set;}
        public int Energy{get;set;}
        public int Points{get;set;}
        public User myuser{get;set;}
        public int UserId{get;set;}
    }

    public class Login{

        [EmailAddress]
        public string Email {get; set;}

        [DataType(DataType.Password)]
        public string Password { get; set; }

        }
    
}