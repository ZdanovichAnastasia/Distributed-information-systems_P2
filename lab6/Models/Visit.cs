using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    [Table("visit")]
    public class Visit
    {
        [Key]
        public int visitId { get; set; }

        public int studentId { get; set; }
        public int lectureId { get; set; }
        public virtual Student student { get; set; }
        public virtual Lecture lecture { get; set; }
        public DateTime date { get; set; }
        public bool is_visit { get; set; }
    }
}