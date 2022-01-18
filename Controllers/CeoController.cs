using Hotel_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_App.Controllers
{
    public class CeoController : Controller
    {
        List<Ceo> ceoList=new List<Ceo>();
        Ceo[] ceoArray = new Ceo[]
        {
            new Ceo(1,"Shlomo Wassa",30,15000),
            new Ceo(2,"Shmuel Taka",31,10000),
            new Ceo(3,"Takele Mekonen",50,20000),
            new Ceo(4,"Eli Gotman",60,14000),
            new Ceo(5,"Jacob Shahar",70,150000)
        };
        // GET: Ceo
        public ActionResult CeoName()
        {
            ceoList.AddRange(ceoArray);
            ViewBag.Name = ceoList[ceoList.Count - 1];
            return View();
        }
        public ActionResult ShowCeo(int id)
        {
            ceoList.AddRange(ceoArray);
            Ceo ceo = ceoList.Find(item => item.Id == id);
            return View(ceo);
        }
        public ActionResult ShowCeoViewBage(int id)
        {
            ceoList.AddRange(ceoArray);
            ViewBag.Manager = ceoList.Find(item => item.Id == id);
            return View();
        }
    }
}