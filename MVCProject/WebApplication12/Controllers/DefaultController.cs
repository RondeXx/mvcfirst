using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var deger = c.Birims.ToList();
            return View(deger);
        }
        [HttpGet]
        [Authorize]
        public IActionResult YeniBirim()
        {


            return View();

        }
        [HttpPost]
        [Authorize]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id);
            c.Birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View("BirimGetir", depart);
        }
        [Authorize]
        public IActionResult BirimGuncelle(Birim b)
        {
            var dep = c.Birims.Find(b.BirimID);
            dep.BirimAD = b.BirimAD;
            c.SaveChanges();
            return RedirectToAction("Index");
      
       }
        [Authorize]  
        public IActionResult BirimDetay (int id)
        {
            var deger = c.Personels.Where(x => x.BirimID == id).ToList();
            var birmad = c.Personels.Where(x => x.BirimID == id).Select(y => y.Birim.BirimAD).FirstOrDefault();
            ViewBag.brmad = birmad;
            return View(deger);
        }
    }
}

    

