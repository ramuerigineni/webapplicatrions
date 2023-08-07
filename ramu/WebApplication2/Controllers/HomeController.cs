using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        ////public ActionResult Index()
        ////{
        ////    ViewBag.LoginMessage = TempData.Peek("isLogin");//first time read
        ////    return View();
        ////}
        //for example of keep
        //public ActionResult Index()
        //{
        //    ViewBag.LoginMessage = TempData["isLogin"];
        //     TempData.Keep("isLogin");
        //    return View();
        //}

        ////public ActionResult checkLogin()
        ////{
        ////    TempData["isLogin"] = "Login Sucessfully";//tempdata is used to trnsfer data from actionmethod to another actionmethod
        ////    return RedirectToAction("Index");
        ////}



        ////public ActionResult About()
        ////{
        ////    ViewBag.LoginMessageABOUT = TempData["isLogin"];
        ////    //TempData.Keep("isLogin");

        ////    ViewBag.Message = "Your application description page.";
        ////    ViewBag.number1= 12;
        ////    ViewBag.number2 = 2;
        ////    ViewData["number1"] = 34;
        ////    TempData["number2"] = 3;
        ////    return View();
        ////}

        ////public ActionResult Contact()
        ////{
        ////    ViewBag.Message = "Your contact page.";

        ////    return View();
        ////}
        ////public ActionResult Login() {
        ////    return View();
        ////}
        ///


    }
}