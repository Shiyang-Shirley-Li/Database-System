using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Author: Shiyang(Shirley) Li, Lin Pan
/// Date: 04/23/2021
/// Course: CS 5530, University of Utah, School of Computing
/// Copyright: CS 5530 and Shiyang(Shirley) Li, Lin Pan - This work may not be copied for use in Academic Coursework
/// 
/// </summary>
/// 
namespace LMS.Controllers
{
    public class CommonController : Controller
    {

        /*******Begin code to modify********/
        protected Team2LMSContext db;

        public CommonController()
        {
            db = new Team2LMSContext();
        }


        /*
         * WARNING: This is the quick and easy way to make the controller
         *          use a different LibraryContext - good enough for our purposes.
         *          The "right" way is through Dependency Injection via the constructor 
         *          (look this up if interested).
        */
        public void UseLMSContext(Team2LMSContext ctx)
        {
            db = ctx;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Retreive a JSON array of all departments from the database.
        /// Each object in the array should have a field called "name" and "subject",
        /// where "name" is the department name and "subject" is the subject abbreviation.
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetDepartments()
        {
            // TODO: Do not return this hard-coded array.
            var query =
            from t in db.Departments
            select new
            {
                name = t.Name,
                subject = t.SubjectAbbreviation
            };

            return Json(query.ToArray());
        }



        /// <summary>
        /// Returns a JSON array representing the course catalog.
        /// Each object in the array should have the following fields:
        /// "subject": The subject abbreviation, (e.g. "CS")
        /// "dname": The department name, as in "Computer Science"
        /// "courses": An array of JSON objects representing the courses in the department.
        ///            Each field in this inner-array should have the following fields:
        ///            "number": The course number (e.g. 5530)
        ///            "cname": The course name (e.g. "Database Systems")
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetCatalog()
        {
            var query = from c in db.Courses
                        join d in db.Departments
                        on c.SubjectAbbreviation equals d.SubjectAbbreviation
                        select new
                        {
                            subject = d.SubjectAbbreviation,
                            dname = d.Name,
                            courses = d.Courses.Select((key, index) => new { number = key.Number, cname = key.Name })
                        };

            return Json(query.ToArray());
        }

        /// <summary>
        /// Returns a JSON array of all class offerings of a specific course.
        /// Each object in the array should have the following fields:
        /// "season": the season part of the semester, such as "Fall"
        /// "year": the year part of the semester
        /// "location": the location of the class
        /// "start": the start time in format "hh:mm:ss"
        /// "end": the end time in format "hh:mm:ss"
        /// "fname": the first name of the professor
        /// "lname": the last name of the professor
        /// </summary>
        /// <param name="subject">The subject abbreviation, as in "CS"</param>
        /// <param name="number">The course number, as in 5530</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetClassOfferings(string subject, int number)
        {
            var query = from c in db.Courses
                        join cl in db.Classes
                        on c.CId equals cl.CId
                        join p in db.Professors
                        on cl.Id equals p.Id
                        where c.SubjectAbbreviation == subject
                        where c.Number == number
                        select new
                        {
                            season = cl.Season,
                            year = cl.Year,
                            location = cl.Location,
                            start = cl.StartTime,
                            end = cl.EndTime,
                            fname = p.FirstName,
                            lname = p.LastName
                        };
            return Json(query.ToArray());
        }

        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <returns>The assignment contents</returns>
        public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category, string asgname)
        {
            var query = from cl in db.Classes
                        join c in db.Courses
                        on cl.CId equals c.CId
                        join ac in db.AssignmentCategories
                        on cl.ClassId equals ac.ClassId
                        join a in db.Assignments
                        on ac.AcId equals a.AcId
                        where c.SubjectAbbreviation == subject
                        where c.Number == num
                        where cl.Season == season
                        where cl.Year == year
                        where ac.Name == category
                        where a.Name == asgname
                        select a.Contents;
            return Content(query.FirstOrDefault());
        }


        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment submission.
        /// Returns the empty string ("") if there is no submission.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <param name="uid">The uid of the student who submitted it</param>
        /// <returns>The submission text</returns>
        public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category, string asgname, string uid)
        {
            var query = from cl in db.Classes
                        join c in db.Courses
                        on cl.CId equals c.CId
                        join ac in db.AssignmentCategories
                        on cl.ClassId equals ac.ClassId
                        join a in db.Assignments
                        on ac.AcId equals a.AcId
                        join s in db.Submission
                        on a.AsId equals s.AsId
                        where c.SubjectAbbreviation == subject
                        where c.Number == num
                        where cl.Season == season
                        where cl.Year == year
                        where ac.Name == category
                        where a.Name == asgname
                        where s.Id == uid
                        select s.Contents;
            return Content(query.FirstOrDefault());
        }


        /// <summary>
        /// Gets information about a user as a single JSON object.
        /// The object should have the following fields:
        /// "fname": the user's first name
        /// "lname": the user's last name
        /// "uid": the user's uid
        /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
        ///               If the user is a Professor, this is the department they work in.
        ///               If the user is a Student, this is the department they major in.    
        ///               If the user is an Administrator, this field is not present in the returned JSON
        /// </summary>
        /// <param name="uid">The ID of the user</param>
        /// <returns>
        /// The user JSON object 
        /// or an object containing {success: false} if the user doesn't exist
        /// </returns>
        public IActionResult GetUser(string uid)
        {
            var queryS = from s in db.Students
                         where s.Id == uid
                         select new
                         {
                             fname = s == null ? null : s.FirstName,
                             lname = s == null ? null : s.LastName,
                             uid = s == null ? null : s.Id,
                             department = s == null ? null : s.SubjectAbbreviation
                         };

            var queryP = from p in db.Professors
                         where p.Id == uid
                         select new
                         {
                             fname = p == null ? null : p.FirstName,
                             lname = p == null ? null : p.LastName,
                             uid = p == null ? null : p.Id,
                             department = p == null ? null : p.SubjectAbbreviation
                         };

            var queryA = from a in db.Administrators
                         where a.Id == uid
                         select new
                         {
                             fname = a == null ? null : a.FirstName,
                             lname = a == null ? null : a.LastName,
                             uid = a == null ? null : a.Id
                         };

            if (queryS != null)
            {
                return Json(queryS.FirstOrDefault());
            }

            if (queryP != null)
            {
                return Json(queryP.FirstOrDefault());
            }

            if (queryA != null)
            {
                return Json(queryA.FirstOrDefault());
            }

            return Json(new { success = false });
        }


        /*******End code to modify********/

    }
}