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
        private readonly IEventRepository _eventRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        

        public AppController(IUserRepository userRepository, IEventRepository eventRepository, IWebHostEnvironment web)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            hostingEnvironment = web;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult EventsDB()
        {
            var results = from events in _eventRepository.GetAllEvents()
                                        select events;
            return View(results.ToList());
        }

        public IActionResult Event()
        {
           return View();
        }
        public IActionResult View_Events()
        {
             var results = from events in _eventRepository.GetAllEvents()
                                        select events;
            return View(results.ToList());
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();
            return View();

        }

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



        public IActionResult ShowUsers()
        {
            var results = from user in _userRepository.GetAllUsers()
                                        select user;
            return View(results.ToList());
        }

    }
}