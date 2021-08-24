using MVC_CRUD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class HomeController: Controller
    {

        public ActionResult Index()
        {

            UserService us = new UserService();
            List<User>  userList  = us.getAllUserList();
            return View(userList);

        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page";
            return View();

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page";
            return View();

        }
        [HttpPost]
        public ActionResult NewUser (User user)
        {
            UserService us = new UserService();
            int status = us.insertuserservice(user);
            if (status > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            return null;

        }
        public ActionResult edit(string id)
        {

            UserService us = new UserService();
            List<User> editList = us.getUserByID(id);
            return View(editList);

        

        }
        public ActionResult Update(User user )
        {
            UserService us = new UserService();
            int status = us.updateuserservice(user);
            if (status > 0)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {

            }
            return null;

        }
        public ActionResult delete(string id)
        {
            UserService us = new UserService();
            int status = us.SoftDelete(id);
            if (status > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

            }

            return null;

        }
    }
}