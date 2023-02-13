using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDog.Abstractions;
using WebAppDog.Data;
using WebAppDog.Domain;
using WebAppDog.Models;
using WebAppDog.Services;

namespace WebAppDog.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogService)
        {
            this._dogService = dogService;
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
                var created = _dogService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Picture);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }
        public IActionResult All(string searchStringBreed,string searchStringName)
        {
            List<DogDetailsViewModel> dogs = _dogService.GetDogs( searchStringBreed, searchStringName)
                .Select(dogFrpmDb => new DogDetailsViewModel

                {
                    Id = dogFrpmDb.Id,
                    Name = dogFrpmDb.Name,
                    Age = dogFrpmDb.Age,
                    Breed = dogFrpmDb.Breed,
                    Picture = dogFrpmDb.Picture

                }).ToList();
            

            return this.View(dogs);

        }
        public IActionResult Edit(int id)
        {
            Dog item =_dogService.GetDogById(id);
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

        public IActionResult Edit(int id,DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var update = _dogService.UpdateDog(id, bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Picture);
                    if (update)
                    {
                        return this.RedirectToAction("All");
                    }
                }
                return this.View();
            }
            return View(bindingModel);
        }
        public IActionResult Delete(int id)
        {

            Dog item = _dogService.GetDogById(id);
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

        public IActionResult Delete(int id, IFormCollection collection)
        {
           var deleted = _dogService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("All", "Dogs");

            }
            else
            {
                return View();
            }
        }
            
        public IActionResult Success()
        {
              return this.View();
       }
            
        public IActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (id == null)
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
        public IActionResult Sort()
        {
            List<DogDetailsViewModel> dogs = _dogService.GetDogs()
                .Select(dogFrpmDb => new DogDetailsViewModel

                {
                    Id = dogFrpmDb.Id,
                    Name = dogFrpmDb.Name,
                    Age = dogFrpmDb.Age,
                    Breed = dogFrpmDb.Breed,
                    Picture = dogFrpmDb.Picture

                }
                 ).OrderBy(x => x.Name ). ToList();
            

            return this.View(dogs);

        }

    }
}



