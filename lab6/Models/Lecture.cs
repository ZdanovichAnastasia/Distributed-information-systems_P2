using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab6.Models
{
    [Table("lecture")]
    public class Lecture
    {
        [Key]
        public int lectureId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string name { get; set; }
        public string lecturer { get; set; }
    }
}