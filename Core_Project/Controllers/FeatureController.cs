﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            var values = _featureService.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature p)
        {

            _featureService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
