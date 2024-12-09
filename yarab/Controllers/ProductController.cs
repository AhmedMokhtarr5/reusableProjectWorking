
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace yarab.Controllers
{
	public class ProductController : Controller
	{
          	ApplicationDbContext _context;
			IWebHostEnvironment _webHostEnvironment;

			public ProductController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
			{

				_webHostEnvironment = webHostEnvironment;
				_context = context;
			}

        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Json(products);
        }







        [HttpGet]
		public IActionResult GetIndexView()
		{
			return View("Index", _context.Products.ToList());
		}
		[HttpGet]
		public IActionResult GetDetailsView(int id)
		{
           Product product = _context.Products.SingleOrDefault(e => e.ProductId == id);


            return View("Details", product);
		}
		[HttpGet]
		public IActionResult GetCreateView()
		{
			
			return View("Create");
		}



		[HttpPost]
		public IActionResult AddNew(Product product) 
		{
			

			

			if (ModelState.IsValid == true)
			{
				_context.Products.Add(product);
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
		Product product= _context.Products.FirstOrDefault(e => e.ProductId == id);

			if (product == null)
			{
				return NotFound();
			}
			else
			{

				return View("Edit", product);
			}

			
        }



		[HttpPost]
		public IActionResult EditCurrent(Product product)
		{





            if (ModelState.IsValid == true)
            {
                _context.Products.Update(product);
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
			Product product = _context.Products.FirstOrDefault(e => e.ProductId== id);
         
           

            if (product == null)
			{
				return NotFound();
			}
			else
			{
				return View("Delete", product);
			}
		}

		

		[HttpPost]
		public IActionResult DeleteCurrent(Product product)
		{
           
            if (product == null)
            {
                return NotFound();
            }
            else
            {
              


                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
        }





		public string GreetVisitor()
		{
			return "Welcome to Managment Website!";
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
