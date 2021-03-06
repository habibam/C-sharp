using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

namespace RandomPasscode
{

    public class Passcode : Controller
    {
        
        private static Random rand = new Random();

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            // HttpContext.Session.Clear();    //<-- uncomment this if ajax works
            ViewBag.Passcode = genPasscode();
            int? attempts = HttpContext.Session.GetInt32("attempts");
            ViewBag.Attempts = (int)attempts;
            return View();
        }

        public string genPasscode(){
            System.Console.WriteLine("got here");
            int? attempts = HttpContext.Session.GetInt32("attempts");
            if(attempts == null)
            {
                attempts = 1;
            }
            HttpContext.Session.SetInt32("attempts", (int)attempts+1);

            const string chars = "ABCDEFGHIJKLMONPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 14).Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }
}