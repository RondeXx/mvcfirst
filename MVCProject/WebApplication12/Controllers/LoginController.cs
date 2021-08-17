using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
       
        public async Task<IActionResult> LogIn(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                { 
                     new Claim(ClaimTypes.Name,p.Kullanici)
                 };
                var useridentity = new ClaimsIdentity(claims, "Login");
                     ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Personelim");
                

            }
            
                 return View();
        }
    }
}
