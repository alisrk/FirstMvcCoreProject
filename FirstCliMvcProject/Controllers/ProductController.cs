using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstCliMvcProject.Models;
using FirstCliMvcProject.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstCliMvcProject.Controllers
{
    public class productController : Controller

    {
        private readonly IRepository<Product> _repository;
        private readonly IHostingEnvironment _environment;

        productViewModel modelYeni = new productViewModel();

        public productController(IHostingEnvironment enviroment, IRepository<Product> repository)
        {
            this._environment = enviroment;
            this._repository = repository;
        }
        public IActionResult Index()
        {
            return View();

        }

                
        [HttpGet]
        public IActionResult Addproduct()
        {
            List<SelectListItem> brands = new List<SelectListItem>()
            {
                new SelectListItem("reno","renault"),
                new SelectListItem("merc","merco")

            };

            productViewModel model = new productViewModel();
            model.brands = brands;


            return View(model);
        }

        [HttpPost]
     public async Task<IActionResult> Addproduct(productViewModel model1)
        {
              

            var wwwImages= Path.Combine(_environment.WebRootPath, @"Images");
            
            var filePath = Path.Combine(wwwImages, model1.File.FileName);

            if (model1.File.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model1.File.CopyToAsync(stream);
                        model1.product.imagePath = model1.File.FileName;
                    }

                    
                    
                }
           


            //if (model1.File.Length > 0)
            //{
            //    var filePath = Path.Combine(_environment.WebRootPath, @"Images");
            //   // var x = Path.Combine(Directory.GetCurrentDirectory(), @"Images");
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await model1.File.CopyToAsync(stream);
            //        model1.product.imagePath = model1.File.FileName;
            //    }
            //}

            modelYeni.addproductFunc(model1.product);

            _repository.addAction(model1.product);


            return RedirectToAction("listproduct");
        }
        
        [HttpGet]
        public IActionResult listproduct()
        {
            //return View(modelYeni.getAll());
            //return View(_repository.getAll());

            return View(_repository.getAll());
        }

        [HttpPost]
        public IActionResult listproduct(String UrunAdı)
        {
            //return View(modelYeni.getAll());
            //return View(_repository.getAll());
            if(UrunAdı == null)
            {
                return View(_repository.getAll());
            }
            else
            {
                return View(_repository.search(UrunAdı));
            }

           
        }
    }
}