using Butter.Entities;
using Butter.Models;
using Butter.Repositories;
using Butter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Butter.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            //1- mon repo
            UserRepository monRepo = new UserRepository();
            //2- Appel du Get
            IEnumerable<UserModel> users = monRepo.Get();         
            //3- je renvoie
            return View(users);
        }

        public IActionResult Details(int Id) 
        {
            //1- mon repo
            UserRepository monRepo = new UserRepository();
            //2 je récup le model
            UserModel lol = monRepo.GetById(Id);
            return View(lol);
        }
    }
}
