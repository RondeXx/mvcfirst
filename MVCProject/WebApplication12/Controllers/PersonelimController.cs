using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var deger = c.Personels.Include(x => x.Birim).ToList();
            return View(deger);
        }
        [HttpGet]
        [Authorize]
        public IActionResult YeniPersonel()
        {

            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAD,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            //per adında degişken oluşturduk veri tabanında birim adındaki tablomuzun where (nerede) her bir satır iç yap
            //BirimID eşit eşit İse Personelden gelen "p" parametresine 
            //İlk olanı al diyoruz "(FisrtOrDefault())"
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
        return RedirectToAction("Index");
        }


    }


}