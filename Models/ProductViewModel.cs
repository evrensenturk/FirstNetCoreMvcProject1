using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCoreMvcProject.Models
{
    public class ProductViewModel
    {
        public Product MyProduct { get; set; }
        public List<SelectListItem> Markalar { get; } = new List<SelectListItem>()
        {
            new SelectListItem("Renault","Renault"),
            new SelectListItem("Mercedes", "Mercedes")
        };
        public IFormFile File { get; set; }
    }
}
