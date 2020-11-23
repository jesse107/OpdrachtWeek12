using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpdrachtWeek12.Models;

namespace OpdrachtWeek12.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> StaticStudents = new List<Student>()
        { new Student()
        {
            StudentNummer = 123, Email = "broodjekaas@live.nl", Voornaam = "Jan"
            },
            new Student()
        {
            StudentNummer = 124, Email = "smeerkaas@live.nl", Voornaam = "Jan"
            },
            new Student()
        {
            StudentNummer = 125, Email = "pindakaas@live.nl", Voornaam = "Yoruba"
            },
            new Student()
        {
            StudentNummer = 126, Email = "trump@live.nl", Voornaam = "Don"
            },
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aantal()
        {
            List<Student> Students = StaticStudents;
            int aantal = 0;
            foreach(Student s in Students) 
            {
                if(s.Voornaam == "Jan")
                {
                    aantal++;
                }
            }
            return View(aantal);
        }


        public IActionResult Email(int Studentnummer)
        {
            List<Student> Students = StaticStudents;
            Student GevondenStudent = null;
            foreach(Student s in Students)
            {

                if(s.StudentNummer == Studentnummer)
                {
                    GevondenStudent = s;
                    break; //neem aan dat er maar 1 student per uniek nummer is
                }
            }
                return View(GevondenStudent);
        }

        public IActionResult ZoekStudenten(char letter)
        {
            ViewData["Letter"] = letter;
            List<Student> Students = StaticStudents;
            List<Student> GevondenStudenten = new List<Student>();
            foreach (Student s in Students)
            {
                if (Char.ToLower(s.Voornaam[0]) == Char.ToLower(letter))
                {
                        GevondenStudenten.Add(s);
                }
            }
            return View(GevondenStudenten);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            Student student = new Student() { Email = s.Email, StudentNummer = s.StudentNummer, Voornaam = s.Voornaam };
            StaticStudents.Add(student);
            TempData["TempMessage"] = $"Student {s.Voornaam} met studentnummer {s.StudentNummer} is succesvol gecreerd.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            Student student = StaticStudents.Find(student => s.StudentNummer == student.StudentNummer);
            student.Voornaam = s.Voornaam;
            student.Email = s.Email;
            student.StudentNummer = s.StudentNummer;
            TempData["TempMessage"] = $"Student {s.Voornaam} met studentnummer {s.StudentNummer} en email {s.Email} is succesvol bewerkt.";
            return RedirectToAction("Index");
        }

        public IActionResult Creation()
        {
            return View();
        }
    }
}
