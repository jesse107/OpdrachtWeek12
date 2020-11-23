using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpdrachtWeek12.Controllers;
using OpdrachtWeek12.Data;
using OpdrachtWeek12.Models;
using Xunit;

namespace OpdrachtWeek12.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<MijnContext>()
                .UseInMemoryDatabase("Naam")
                .Options;
            var context = new MijnContext(options);
            context.Studenten.Add(new Student { Naam = "Bob" });
            context.Studenten.Add(new Student { Naam = "Bill" });
            context.Studenten.Add(new Student { Naam = "Jake" });
            context.Studenten.Add(new Student { Naam = "Alice" });
            context.Studenten.Add(new Student { Naam = "Joey" });

            context.SaveChanges();
            HomeController c = new HomeController(context);
            var result = Xunit.Assert.IsType<ViewResult>(c.Index());
            var model = Xunit.Assert.IsType<List<Student>>(result.Model);
            Xunit.Assert.True(model.Count == 5);

        }
    }
}
