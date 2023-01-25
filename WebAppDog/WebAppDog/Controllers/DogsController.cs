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
            List<DogDetailsViewModel> dogs = context.Dogs
                .Select(dogFrpmDb => new DogDetailsViewModel

                {
                    Id = dogFrpmDb.Id,
                    Name = dogFrpmDb.Name,
                    Age = dogFrpmDb.Age,
                    Breed = dogFrpmDb.Breed,
                    Picture = dogFrpmDb.Picture

                }
                 ).ToList();

            return View(dogs);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }
        [HttpPost]

        public IActionResult Edit(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new Dog
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };
                context.Dogs.Update(dog);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return View(bindingModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);

        }
        [HttpPost]

        public IActionResult Delete(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new Dog
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };
                context.Dogs.Remove(dog);
                context.SaveChanges();
                return this.RedirectToAction("All", "Dogs");
            }
            return View(bindingModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsViewModels dog = new DogDetailsViewModels()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);

        }

    }
}



