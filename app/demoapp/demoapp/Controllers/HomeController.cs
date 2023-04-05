using demoapp.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demoapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string[] fileEntries = { "error getting the files"};
            try
            {
                fileEntries = Directory.GetFiles("/mnt/demoappfiles");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return View(fileEntries);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult CreateFiles()
        {
            for (int i = 0; i < 10; i++)
            {
                CreateSingleFile($"/mnt/demoappfiles/file${i}.txt");
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteFiles()
        {
            foreach(string file in Directory.GetFiles("/mnt/demoappfiles"))
            {
                System.IO.File.Delete(file);
            }

            return RedirectToAction("Index");

        }
        //Create a method that creates a file in an specific path
        private void CreateSingleFile(string fullFilePath)
        {
            //Check if the file already exists. If it does, delete it. 
            if (System.IO.File.Exists(fullFilePath))
            {
                System.IO.File.Delete(fullFilePath);
            }

            //Create the file.
            using (StreamWriter outputFile = new StreamWriter(fullFilePath))
            {
                var content = "New file created: ${fullFilePath}";
                outputFile.WriteLine(content);
            }
        }
    }
}