using u21544931__HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace u21544931__HW03.Controllers
{
    public class HomeController : Controller
    {

        //this will take you back to the home page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase file)
        {                     
            
               
            // check if a file has been uploaded
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                

                if( FileType == "Image")
                {
                    //if the file type is an image it will save the image file
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                } 
                else if( FileType == "Video")
                {
                    //if the file type is a video it will save the image file
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
                else if(FileType == "Document")
                {
                    //if the file type is a document it will save into the document file
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), Path.GetFileName(file.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
            }
            else
            {
                ViewBag.Message = "Please select a file";
             
            }
            // after successfully uploading redirect the user
            return View();
        }

        public ActionResult About()
        {
            return View();
        }



    }
}