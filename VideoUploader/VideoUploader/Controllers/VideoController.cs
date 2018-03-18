using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.IO;

namespace VideoUploader.Controllers
{
    public class VideoController : ApiController
    {
       
        public ActionResult Upload(HttpPostedFileBase file) 
        {

            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content"), Path.GetFileName(file.FileName));
            file.SaveAs(path);
            return new ContentResult { Content = "success" };
        }
    }
}
