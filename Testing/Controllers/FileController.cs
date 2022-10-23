using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Testing.Controllers
{
    public class FileController : Controller
    {
        private IHostingEnvironment _env;
        // GET: FilesController
        public ActionResult Index()
        {
            return View();
        }

        public FileController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult SingleFile(IFormFile file)
        {

            var dir = _env.ContentRootPath;

            using(var fileStream = new FileStream(Path.Combine(dir, "file.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return RedirectToAction("Index");
        }


    }
}
  