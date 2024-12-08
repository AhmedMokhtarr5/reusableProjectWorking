
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace yarab.Controllers
{
	public class UserController : Controller
	{
          	ApplicationDbContext _context;
			IWebHostEnvironment _webHostEnvironment;

			public UserController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
			{

				_webHostEnvironment = webHostEnvironment;
				_context = context;
			}
		[HttpGet]
		public IActionResult GetIndexView()
		{
			return View("Index", _context.Users.ToList());
		}
		[HttpGet]
		public IActionResult GetDetailsView(int id)
		{
            User user = _context.Users.SingleOrDefault(e => e.UserId == id);


            return View("Details", user);
		}
		[HttpGet]
		public IActionResult GetCreateView()
		{
			
			return View("Create");
		}



		[HttpPost]
		public IActionResult AddNew(User user) 
		{
			

			

			if (ModelState.IsValid == true)
			{
				_context.Users.Add(user);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				return View("Create");
			}
		}



		[HttpGet]
		public IActionResult GetEditView(int id)
		{
			User user= _context.Users.FirstOrDefault(e => e.UserId == id);

			if (user == null)
			{
				return NotFound();
			}
			else
			{

				return View("Edit", user);
			}

			
        }



		[HttpPost]
		public IActionResult EditCurrent(User user )
		{





            if (ModelState.IsValid == true)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
               
                return View("Edit");
            }
        }


     

        [HttpGet]
		public IActionResult GetDeleteView(int id)
		{
			User user = _context.Users.FirstOrDefault(e => e.UserId == id);
         
           

            if (user == null)
			{
				return NotFound();
			}
			else
			{
				return View("Delete", user);
			}
		}

		

		[HttpPost]
		public IActionResult DeleteCurrent(User user)
		{
           
            if (user == null)
            {
                return NotFound();
            }
            else
            {
              


                _context.Users.Remove(user);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
        }





		public string GreetVisitor()
		{
			return "Welcome to Uber Managment Website!";
		}

		public string GreetUser(string name)
		{
			return $"Hi {name}\nHow are you?";
		}

		public string GetAge(string name, int birthYear)
		{
			return $"Hi {name}\nYou are {DateTime.Now.Year - birthYear} years old.";
		}
	}
}
