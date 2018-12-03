using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCoreMvcProject.Models;
using FirstNetCoreMvcProject.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstNetCoreMvcProject.Controllers
{
    public class UrunController : Controller
    {
        private IProductDal _dal;
        private readonly IHostingEnvironment _environment;

        public UrunController(IProductDal dal, IHostingEnvironment enviroment)
        {
            this._dal = dal;
            this._environment = enviroment;
        }
        public IActionResult Index()
        {
            
            return View(_dal.GetAll());
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            ProductViewModel pv = new ProductViewModel();

            return View(pv);
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(ProductViewModel p)
        {

            if (p.File.Length > 0)
            {
               var x = Path.Combine(_environment.WebRootPath, @"Images");
                //var x = Path.Combine(Directory.GetCurrentDirectory(), @"Images");
                var filePath = Path.Combine(x, p.File.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await p.File.CopyToAsync(stream);
                    p.MyProduct.ProductImg = p.File.FileName;
                }
            }
            _dal.AddProduct(p.MyProduct);
            return RedirectToAction("Index");
        }
     
    }
}