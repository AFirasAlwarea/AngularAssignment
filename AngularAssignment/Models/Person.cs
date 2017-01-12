using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularAssignment.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Full Name")]
        public string Name { get; set; }

        [Display(Name ="Telephone No.")]
        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}