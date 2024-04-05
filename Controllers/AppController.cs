using Microsoft.AspNetCore.Mvc;
using TigerTix.Web.Data;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Controllers
{
    public class AppController : Controller
    {

        private readonly IWebHostEnvironment hostingEnvironment;

        //Private repository objects to store all input users and events
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        /*Constructor for the App Controller
         *
         *@param userRepository...Represents a pool of User objects for storage, accessing, and altering
         *@param eventRepository...Represents a pool of Event objects for storage, accessing, and altering
         *@param web...Represents the environment that the application will be running in
         */
        public AppController(IUserRepository userRepository, IEventRepository eventRepository, IWebHostEnvironment web)
        {
            //Populate the private fields
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            hostingEnvironment = web;
        }

        /*Provides the site code for the 'Index' default page for display
         *
         *@return...The Index view
         */
        public IActionResult Index() { return View(); }

        /*Provides the site code for the 'Add a User' page for displaying and
         *  taking user input
         *
         *@return...The AddUser view
         */
        public IActionResult AddUser() { return View(); }

        /*Provides the site code for the 'See Created Events' page, which displays
         *  a comprehensive list of all user-created events
         *
         *@return...The EventsDB view
         */
        public IActionResult EventsDB()
        {
            //Create a 'results' variable that will store each event in the
            //  controller's repository
            var results = from events in _eventRepository.GetAllEvents()
                                        select events;
            //Convert the group of all events to a list and pass it to the
            //  model in the EventsDB view
            return View(results.ToList());
        }

        /*Provides the stie code for the 'Create Event' page, which
         *  takes user input and registers a new event in the repository
         *
         *@return...The Event view
         */
        public IActionResult Event() { return View(); }

        /*Provides the site code for the 'See Events' page, which displays a
         *  comprehensive list of all active events
         *
         *@return...The View_Events view
         */
        public IActionResult View_Events()
        {
            //Create a 'results' variable, and append each event in the controller's
            //  event repository to it
            var results = from events in _eventRepository.GetAllEvents()
                                        select events;
            //Convert the results into a list and pass it to the model of the
            //  View_Events.cshtml view
            return View(results.ToList());
        }

        /*Provides the site code for the 'Event Info' page, which takes payment info
         *  and purchases a ticket for the user
         *
         *@param EventName...Represents the name of the event being purchased for
         *
         *@return...The CheckEvent view
         */
        [HttpGet]
        public IActionResult CheckEvent(string EventName)
        {
            //Search the controller's event repository for an event with a
            //  matching name to the one passed in, store it and pass it to
            //  the model of the CheckEvent.cshtml view
            var result = _eventRepository.GetEventByName(EventName);
            return View(result);
        }

        /*Provides the site code for the 'Add Users' page, which takes account
         *  information and creates a new User object for the site user
         *
         *@param user...represents the User object being added to the repository
         *
         *@return...The AddUser view
         */
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            //Take in a User object and save it to the repository
            _userRepository.SaveUser(user);
            //Ensure that all users are saved to the repository
            _userRepository.SaveAll();
            //Return the AddUser.cshtml view
            return View();
        }

        /*Provides the site code for the 'Add Event' page, which posts a new
         *  event object to the controller's event repository
         *
         *@param eventInput...represents the event object being registered
         *@param imageFile...represents the image of the event being registered
         *
         *@return...The Event view
         */
        [HttpPost]
        public IActionResult Event(Event eventInput, IFormFile imageFile)
        {
            //If an image has been provided, store it in the site's data files
            if (imageFile != null)
            {
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, Path.GetFileName(imageFile.FileName));
                imageFile.CopyTo(new FileStream(fileName, FileMode.Create));
            }
            eventInput.imageName = "/" + Path.GetFileName(imageFile.FileName);

            //Store the event in the controller's event repository and return
            //  the Event.cshtml view
            _eventRepository.SaveEvent(eventInput);
            _eventRepository.SaveAll();
            return View();
        }

        /*Provides the site code for the 'Show Users' page, which provides
         *  a comprehensive list of all registered users
         *
         *@return...The ShowUsers view
         */
        public IActionResult ShowUsers()
        {
            //Store all users in a 'results' variable
            var results = from user in _userRepository.GetAllUsers()
                                        select user;
            //Convert the pool of users to a list and pass it to the
            //  model of the ShowUsers.cshtml view
            return View(results.ToList());
        }

    }
}
