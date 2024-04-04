using Microsoft.AspNetCore.Mvc;
using TigerTix.Web.Data;
using TigerTix.Web.Models;
using TigerTix.Web.Data.Entities;
using System.Runtime.InteropServices;


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

         public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult Event()
        {
<<<<<<< Updated upstream
            return View();
=======
           return View();
        }
        public IActionResult View_Events()
        {
            var results = from events in _eventRepository.GetAllEvents()
                                        select events;
            return View(results.ToList());
>>>>>>> Stashed changes
        }
        [HttpGet]
        public IActionResult CheckEvent(string EventName)
        {
            var result = _eventRepository.GetEventByName(EventName);
            return View(result);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();
            return View();

        }

<<<<<<< Updated upstream


=======
        [HttpPost]
        public IActionResult Event(Event eventInput, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, Path.GetFileName(imageFile.FileName));
                imageFile.CopyTo(new FileStream(fileName, FileMode.Create));
            }
            eventInput.imageName = "/" + Path.GetFileName(imageFile.FileName);

            _eventRepository.SaveEvent(eventInput);
            _eventRepository.SaveAll();
            return View();

        }
>>>>>>> Stashed changes
        public IActionResult ShowUsers()
        {
            var results = from user in _userRepository.GetAllUsers()
                                        select user;
            return View(results.ToList());
        }

    }
}