using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoUploader.Controllers
{
    public class VideController : Controller
    {
        //
        // GET: /Vide/
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var path = Path.Combine(Server.MapPath("~/Content"), Path.GetFileName(file.FileName));
            file.SaveAs(path);
            return new ContentResult { Content = "success" };
        }
	}
}