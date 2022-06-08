using u21544931__HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21544931__HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(HttpContext.Server.MapPath("~/Media/Documents/"));
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                FileModel filemodel = new FileModel();
                filemodel.FileName = Path.GetFileName(filePath);
                fileList.Add(filemodel);
            }


            return View(fileList);
        }

        public ActionResult Download(string FileName)
        {

            //creating a file path
            string path = Server.MapPath("~/Media/Documents/") + FileName;


            //this line of code will read the file data into byte array
            byte[] bytes = System.IO.File.ReadAllBytes(path);


            //this will send the file to the download
            return File(bytes, "application/octet-stream", FileName);

        }

        public ActionResult Delete(string FileName)
        {

            //this will delete the file
            string fullPath = Request.MapPath("~/Media/Documents/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");

        } 
    }
}
