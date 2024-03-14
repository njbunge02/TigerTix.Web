using Microsoft.AspNetCore.Mvc;
using TigerTix.Web.Data;
using TigerTix.Web.Models;
using TigerTix.Web.Data.Entities;


namespace TigerTix.Web.Controllers
{
    public class AppController : Controller
    {

        private readonly IUserRepository _userRepository;

        public AppController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();
            return View();

        }

        public IActionResult ShowUsers()
        {
            var results = from user in _userRepository.GetAllUsers()
                                        select user;
            return View(results.ToList());
        }

    }
}