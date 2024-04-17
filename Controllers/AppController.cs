using Microsoft.AspNetCore.Mvc;
using TigerTix.Web.Data;
using TigerTix.Web.Data.Entities;
using TigerTix.Web.Models;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;


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
        [Route("")]
        public IActionResult Index() { return View(); }

        /*Provides the site code for the 'Index' default page after the user
         * has signed in
         *
         *@return...The Index_Auth view
         */
        [Route("Home")]
        public IActionResult Index_Auth(int userID) { return View(userID);  }

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
        [Route("ViewEvents")]
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

        [Route("ViewEvents/Auth")]
        public IActionResult View_Events_Auth(int userID)
        {

            var results = from events in _eventRepository.GetAllEvents()
                          select events;
            var userEventPair = new KeyValuePair<int, IEnumerable<Event>>( userID, results.ToList() );

            return View(userEventPair);
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        /*Provides the site code for the 'Event Info' page, which takes payment info
         *  and purchases a ticket for the user
         *
         *@param EventName...Represents the name of the event being purchased for
         *
         *@return...The CheckEvent view
         */
        [HttpGet]
        [Route("ViewEvents/CheckEvent")]

        public IActionResult CheckEvent(string EventName, int userID)
        {
            //Search the controller's event repository for an event with a
            //  matching name to the one passed in, store it and pass it to
            //  the model of the CheckEvent.cshtml view
            var user = _userRepository.GetUserId(userID);
            var result = _eventRepository.GetEventByName(EventName);

            var userEventPair = new KeyValuePair<User, Event>(user, result);

            return View(userEventPair);
        }

        /*Provides the site code for the 'Add Users' page, which takes account
         *  information and creates a new User object for the site user
         *
         *@param user...represents the User object being added to the repository
         *
         *@return...The AddUser view
         */
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(userModel user)
        {

            if (ModelState.IsValid)
        {
        // Retrieve user from database based on username
        var existingUser = _userRepository.GetUserByUsername(user.userName);

                if (existingUser != null)
                {
                    // Validate password
                    if (ValidatePassword(user.passWord, existingUser.PasswordHash, Convert.FromBase64String(existingUser.Salt)))
                    {
                        // Authentication successful, redirect to homepage
                        var authUser = _userRepository.GetUserByUsername(user.userName);
                        //return RedirectToAction("Index_Auth", new {userID = authUser.Id});
                        return RedirectToAction("Index_Auth", new { userID = authUser.Id });
                    }
                    else
                    {
                        // Password incorrect
                        ModelState.AddModelError("", "Invalid username or password");
                    }
                }
                else
                {
                    // User not found
                    ModelState.AddModelError("", "Account does not exist");
                }
            }
            else
            {
                // ModelState is invalid, meaning there are validation errors
                // This block is executed if the provided username or password doesn't meet the validation requirements
                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(user);

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
        [Route("CreateEvent")]
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

        [HttpGet]
        [Route("Signup")]
        public IActionResult SignUp()
        {
            var model = new userModel(); // Create a new instance of the model
            return View(model);
        }

        [HttpPost]
        [Route("Signup")]
        public IActionResult SignUp(userModel model)
        {
            // Validate user input
            if (ModelState.IsValid)
            {
                 // Generate a salt
                byte[] salt = GenerateSalt();

                // Hash the password with the salt
                string hashedPassword = HashPassword(model.passWord, salt);

                
                var newUser = new User {
                    UserName = model.userName,
                    PasswordHash = hashedPassword,
                    Salt = Convert.ToBase64String(salt)
                };

                _userRepository.SaveUser(newUser);
                
                // Redirect user to login page after successful signup
                return RedirectToAction("Login");
            }

            // If ModelState is not valid, redisplay the signup form with validation errors
            return View(model);
        }

    // Method to generate a random salt
        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Method to hash the password with the salt
        private string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 256-bit hash
                return Convert.ToBase64String(hash);
            }
        }

        // Method to validate password
        private bool ValidatePassword(string inputPassword, string hashedPassword, byte[] salt)
{
        string hashedInputPassword = HashPassword(inputPassword, salt);
        return hashedPassword == hashedInputPassword;
}   


    }
}
