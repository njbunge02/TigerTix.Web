using Microsoft.AspNetCore.Mvc;
using TigerTix.Web.Data;
using TigerTix.Web.Models;
using TigerTix.Web.Data.Entities;
using System;
using System.Runtime.InteropServices;
using Azure.Identity;
using System.Security.Cryptography;
using System.Text;


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

         public IActionResult Login()
        {
            return View();
        }

        public IActionResult Event()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(userModel user)
        {
            //_userRepository.SaveUser(user);
            //_userRepository.SaveAll();
            //return View();

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
                return RedirectToAction("Index", "App");
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



        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new userModel(); // Create a new instance of the model
            return View(model);
        }

        [HttpPost]
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