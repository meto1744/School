using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDog.Data;
using WebAppDog.Domain;
using WebAppDog.Models;

namespace WebAppDog.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext context;

        public DogsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFromDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture,
                };

                context.Dogs.Add(dogFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }
        public IActionResult All()
        {
            List<DogAllViewModel> dogs = context.Dogs
                .Select(dogFrpmDb => new DogAllViewModel

                 {
                    Id = dogFrpmDb.Id,
                    Name = dogFrpmDb.Name,
                    Age= dogFrpmDb.Age,
                    Breed= dogFrpmDb.Breed,
                    Picture= dogFrpmDb.Picture

                 }
                 ).ToList();

            return View(dogs);
        }
        
    }
   
}



