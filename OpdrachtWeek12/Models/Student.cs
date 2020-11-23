using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpdrachtWeek12.Models
{
    public class Student
    {
        public int StudentNummer { get; set; }
        [StringLength(10)]public string Voornaam { get; set; }
        public string  Email { get; set; }
    }
}
