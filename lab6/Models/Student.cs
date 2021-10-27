using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab6.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter a surname")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Please enter a number of group")]
        public int Ngroup { get; set; }
    }
}