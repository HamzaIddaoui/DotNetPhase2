
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WebApplication2Context _context;
        private readonly IMemoryCache _memoryCache;
        private readonly ILoggerFactory _loggerFactory;

        public ProductsController(WebApplication2Context context, IMemoryCache memoryCache, ILoggerFactory loggerFactory)
        {
            _context = context;
            _memoryCache = memoryCache;
            _loggerFactory = loggerFactory;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {

            //if (_context.Product == null)
            //{
            //    return Problem("Entity set 'WebApplication2Context.Product'  is null.");
            //}
            //var products = from p in _context.Product select p;
            //if (!String.IsNullOrEmpty(searchString) && Security.Security.IsValidInput_SQLInjection(searchString))
            //{
            //    products = products.Where(s => s.Title!.Contains(searchString));
            //}
            //return View(await products.ToListAsync());
            // Create a cache key based on the method name and the input parameters
            string cacheKey = $"GetProducts_{searchString}";

            // Try to get the result from the cache
            if (_memoryCache.TryGetValue(cacheKey, out List<Product> cachedProducts))
            {
                // Use the cached result
                return View(cachedProducts);
            }

            // If not in the cache, perform the database query
            if (_context.Product == null)
            {
                return Problem("Entity set 'WebApplication2Context.Product' is null.");
            }

            var products = from p in _context.Product select p;

            if (!String.IsNullOrEmpty(searchString) && Security.Security.IsValidInput_SQLInjection(searchString))
            {
                products = products.Where(s => s.Title!.Contains(searchString));
            }

            // Execute the query and convert to a list
            List<Product> result = await products.ToListAsync();

            // Use _loggerFactory to create an ILogger instance
            ILogger logger = _loggerFactory.CreateLogger<ProductsController>();

            // Now you can use the logger to log messages
            logger.LogInformation("[LOG MESSAGE : CACHE] This is a Logging Message : Products List is cached since it is fetched for the first time !");

            // Store the result in the cache with a specific expiration time (e.g., 10 minutes)
            _memoryCache.Set(cacheKey, result, TimeSpan.FromMinutes(10));

            return View(result);
    }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Use _loggerFactory to create an ILogger instance
            ILogger logger = _loggerFactory.CreateLogger<ProductsController>();

            // Now you can use the logger to log messages
            logger.LogInformation("This is a Logging Message : Method Details Controller : Products");
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // Use _loggerFactory to create an ILogger instance
            ILogger logger = _loggerFactory.CreateLogger<ProductsController>();

            // Now you can use the logger to log messages
            logger.LogInformation("This is a Logging Message : Method Create Controller : Products");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Product product, IFormFile imageFile)
        {
            // Use _loggerFactory to create an ILogger instance
            ILogger logger = _loggerFactory.CreateLogger<ProductsController>();

            // Now you can use the logger to log messages
            logger.LogInformation("This is a Logging Message : Method Create Controller : Products");
            if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);

                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    Directory.CreateDirectory(uploadsFolder);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    // Save the file path in your database
                    product.imagePath = "/images/" + fileName; // Update the path as per your project structure
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,imagePath")] Product product)
        {
            // Use _loggerFactory to create an ILogger instance
            ILogger logger = _loggerFactory.CreateLogger<ProductsController>();

            // Now you can use the logger to log messages
            logger.LogInformation("This is a Logging Message : Method Edit Controller : Products");
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'WebApplication2Context.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
