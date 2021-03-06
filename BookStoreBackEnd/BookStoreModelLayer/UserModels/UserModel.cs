﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreModelLayer
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }
      
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public long Mobile { get; set; }
    }
}
