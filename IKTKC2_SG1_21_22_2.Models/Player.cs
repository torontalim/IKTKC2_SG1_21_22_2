using System;
using System.ComponentModel.DataAnnotations;

namespace IKTKC2_SG1_21_22_2.Models
{
    public class Player
    {   
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }
    }
}