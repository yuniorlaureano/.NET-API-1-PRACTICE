using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingCompany.Controllers
{
    public class CourseController : ApiController
    {


        public IEnumerable<Course> Get()
        {
            return courses;
        }

        public HttpResponseMessage Get(int id)
        {
            var course = (from c in courses
                          where c.Id == id
                          select c).FirstOrDefault();
            if (course == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Item found");
            }

            return Request.CreateResponse<Course>(HttpStatusCode.OK, course);
        }

        public HttpResponseMessage Post([FromBody]Course course)
        {
            
            if (course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Item found");
            }

            courses.Add(course);
            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(Request.RequestUri+ "/" + (courses.Count - 1).ToString());
            return message;
        }

        public HttpResponseMessage Put(int id, [FromBody]Course course)
        {
            var _course = (from c in courses
                          where c.Id == id
                          select c).FirstOrDefault();
            if (_course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Item found");
            }

            _course.Title = course.Title;
            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(Request.RequestUri + "/" + (courses.Count - 1).ToString());
            return message;
        }

        public HttpResponseMessage Delete(int id, [FromBody]Course course)
        {
            var _course = (from c in courses
                           where c.Id == id
                           select c).FirstOrDefault();
            if (_course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Item found");
            }

            courses.Remove(_course);
            var message = Request.CreateResponse(HttpStatusCode.OK, "Item deleted");
            return message;
        }



        public static List<Course> courses = InitCourses();

        private static List<Course> InitCourses()
        {
            return new List<Course> { 
                new Course { Id = 1, Title = "PHP"},
                new Course { Id = 2, Title = "C#"}
            };
        }
    }


    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
