﻿using Microsoft.AspNetCore.Mvc;
using PracticeAppWeb.Data;
using PracticeAppWeb.Models;

namespace PracticeAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the category name!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                TempData["success"] = "Category created successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(obj);
            
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null) 
            { 
                return NotFound(); 
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the category name!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                TempData["success"] = "Category updated successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.Categories.Find(id); 
            if(obj==null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
            TempData["success"] = "Category deleted successfully";
            _db.SaveChanges();
                return RedirectToAction("Index");
            
            

        }
    }
}
