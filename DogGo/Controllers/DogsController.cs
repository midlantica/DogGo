using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogGo.Controllers
{
    [Authorize]
    public class DogsController : Controller
    {
        private readonly IDogRepository _dogRepository;
        private readonly IOwnerRepository _ownerRepository;

        public DogsController(IDogRepository dogRepository, IOwnerRepository ownerRepository)
        {
            _dogRepository = dogRepository;
            _ownerRepository = ownerRepository;
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

        // GET: DogsController
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            List<Dog> dogs = _dogRepository.GetDogsByOwnerId(ownerId);
            return View(dogs);
        }

        // GET: DogController/Details/1
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepository.GetDogById(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }


        // LOOK AT THIS
        //[Authorize]
        public ActionResult Create()
        {
            // We use a view model because we need the list of Owners in the Create view
            DogFormViewModel vm = new DogFormViewModel()
            {
                Dog = new Dog(),
                Owners = _ownerRepository.GetAllOwners(),
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                // update the dogs OwnerId to the current user's Id 
                dog.OwnerId = GetCurrentUserId();

                _dogRepository.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }


        // GET: DogController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepository.GetDogById(id);
            int ownerId = GetCurrentUserId();

            if (dog == null || dog.OwnerId != ownerId)
            {
                return NotFound();
            }

            DogFormViewModel vm = new DogFormViewModel()
            {
                Dog = dog,
                Owners = _ownerRepository.GetAllOwners()
            };
            return View(vm);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                _dogRepository.UpdateDog(dog);
                return RedirectToAction("Index");
            }
            catch
            {
                DogFormViewModel vm = new DogFormViewModel()
                {
                    Dog = dog,
                    Owners = _ownerRepository.GetAllOwners()
                };
                return View(vm);
            }
        }

        [Authorize]
        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepository.GetDogById(id);
            int ownerId = GetCurrentUserId();

            if (dog == null || dog.OwnerId != ownerId)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepository.DeleteDog(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dog);
            }
        }

    }
}