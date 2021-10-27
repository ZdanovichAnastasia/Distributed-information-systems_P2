using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace lab6.Models
{
    public class VisitContext : DbContext
    {
        public VisitContext() : base("visitdb") { }
       
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}