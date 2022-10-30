/*Controller class handles HTTP request from the client, which may be a desktop application, mobile device, and browser.
 * 
 The controller class inherits the System.Web.Http.ApiController class instead of the Controller class.

In this Controller class I am implementing methods to perform CRUD operations. Let us assume we want all student details and also details for some specific student.

Controller Method	   Route URI(Uniform Resource Identifier)
GetAllStudents---->    /api/ student
GetStudentDetails----> /api/ student /id
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiStudentsSample.Models;

namespace WebApiStudentsSample.Controllers
{
    public class StudentController : ApiController
    {
        IList<Students> Students = new List<Students>()
        {
            new Students()
                {
                    StudentId = 1, StudentName = "Ragini", Address = "Bangalore", Course = "EEE"
                },
                new Students()
                {
                    StudentId = 2, StudentName = "Ragini Ragini", Address = "Bhubaneswar", Course = "B.Tech"
                },
                new Students()
                {
                    StudentId = 3, StudentName = "R Singh", Address = "Buxar", Course = "Engineering"
                },
                new Students()
                {
                    StudentId = 4, StudentName = "Ragini Singh", Address = "Bihar", Course = "Software Development"
                },
                new Students()
                {
                    StudentId = 5, StudentName = "R R", Address = "Uttarahalli", Course = "Software Services"
                },
        };
        public IList<Students> GetAllStudents()
        {
            //Returning list of all employees    
            return Students;
        }
        public Students GetStudentDetails(int id)
        {
            //Returning a single employee detail    
            var Student = Students.FirstOrDefault(e => e.StudentId == id);
            if (Student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return Student;
        }
    }
}