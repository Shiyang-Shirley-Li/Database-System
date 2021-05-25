using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [Authorize(Roles = "Student")]
    public class StudentController : CommonController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult Class(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }


        public IActionResult ClassListings(string subject, string num)
        {
            System.Diagnostics.Debug.WriteLine(subject + num);
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            return View();
        }


        /*******Begin code to modify********/

        /// <summary>
        /// Returns a JSON array of the classes the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester
        /// "year" - The year part of the semester
        /// "grade" - The grade earned in the class, or "--" if one hasn't been assigned
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {
            var query = from s in db.Students
                        join e in db.Enroll
                        on s.Id equals e.Id
                        join cl in db.Classes
                        on e.ClassId equals cl.ClassId
                        join c in db.Courses
                        on cl.CId equals c.CId
                        where s.Id == uid
                        select new
                        {
                            subject = c.SubjectAbbreviation,
                            number = c.Number,
                            name = c.Name,
                            season = cl.Season,
                            year = cl.Year,
                            grade = e.Grade
                        };
            return Json(query.ToArray());
        }

        /// <summary>
        /// Returns a JSON array of all the assignments in the given class that the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The category name that the assignment belongs to
        /// "due" - The due Date/Time
        /// "score" - The score earned by the student, or null if the student has not submitted to this assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="uid"></param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInClass(string subject, int num, string season, int year, string uid)
        {
            var query = from cl in db.Classes
                        join ac in db.AssignmentCategories
                        on cl.ClassId equals ac.ClassId
                        join a in db.Assignments
                        on ac.AcId equals a.AcId
                        join c in db.Courses
                        on cl.CId equals c.CId
                        where c.SubjectAbbreviation == subject
                        where c.Number == num
                        where cl.Season == season
                        where cl.Year == year
                        select new
                        {
                            aname = a.Name,
                            cname = ac.Name,
                            due = a.DueDate,
                            score = from sc in db.Submission
                                    where sc.Id == uid
                                    where sc.AsId == a.AsId
                                    select sc.Score
                        };

            var result = new List<object>();
            foreach (var q in query)
            {
                result.Add(
                  new
                  {
                      q.aname,
                      q.cname,
                      q.due,
                      score = (q.score.Any()) ? q.score : null
                  }
                );
            }

            return Json(query.ToArray());
        }



        /// <summary>
        /// Adds a submission to the given assignment for the given student
        /// The submission should use the current time as its DateTime
        /// You can get the current time with DateTime.Now
        /// The score of the submission should start as 0 until a Professor grades it
        /// If a Student submits to an assignment again, it should replace the submission contents
        /// and the submission time (the score should remain the same).
        /// Does *not* automatically reject late submissions.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="uid">The student submitting the assignment</param>
        /// <param name="contents">The text contents of the student's submission</param>
        /// <returns>A JSON object containing {success = true/false}.</returns>
        public IActionResult SubmitAssignmentText(string subject, int num, string season, int year,
          string category, string asgname, string uid, string contents)
        {

            var query = (from cl in db.Classes
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
                         select a).FirstOrDefault();

            var queryS = (from s in db.Submission
                          where s.AsId == query.AsId
                          select s).FirstOrDefault();

            if (queryS == null)
            {
                Submission sb = new Submission();
                sb.Score = 0;
                sb.Contents = contents;
                sb.Time = DateTime.Now;
                sb.Id = uid;
                sb.AsId = query.AsId;
                db.Submission.Add(sb);
            }
            else
            {
                queryS.Contents = contents;
                queryS.Time = DateTime.Now;
            }

            db.SaveChanges();
            return Json(new { success = true });
        }


        /// <summary>
        /// Enrolls a student in a class.
        /// </summary>
        /// <param name="subject">The department subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester</param>
        /// <param name="year">The year part of the semester</param>
        /// <param name="uid">The uid of the student</param>
        /// <returns>A JSON object containing {success = {true/false},
        /// false if the student is already enrolled in the Class.</returns>
        public IActionResult Enroll(string subject, int num, string season, int year, string uid)
        {
            var query = (from c in db.Courses
                         join cl in db.Classes
                         on c.CId equals cl.CId
                         where cl.Season == season
                         where cl.Year == year
                         where c.SubjectAbbreviation == subject
                         where c.Number == num
                         select cl.ClassId).FirstOrDefault();

            try
            {
                Enroll enroll = new Enroll();
                enroll.Id = uid;
                enroll.ClassId = query;
                enroll.Grade = "--";
                db.Enroll.Add(enroll);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(new { success = false });
            }
            return Json(new { success = true });
        }



        /// <summary>
        /// Calculates a student's GPA
        /// A student's GPA is determined by the grade-point representation of the average grade in all their classes.
        /// Assume all classes are 4 credit hours.
        /// If a student does not have a grade in a class ("--"), that class is not counted in the average.
        /// If a student does not have any grades, they have a GPA of 0.0.
        /// Otherwise, the point-value of a letter grade is determined by the table on this page:
        /// https://advising.utah.edu/academic-standards/gpa-calculator-new.php
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>A JSON object containing a single field called "gpa" with the number value</returns>
        public IActionResult GetGPA(string uid)
        {
            var query = from e in db.Enroll
                        where e.Id == uid
                        select e.Grade;

            double total = 0;
            int count = 0;
            foreach (var grade in query)
            {
                if (grade != "--")
                {
                    switch (grade)
                    {
                        case "A":
                            total += 4.0;
                            count++;
                            break;
                        case "A-":
                            total += 3.7;
                            count++;
                            break;
                        case "B+":
                            total += 3.3;
                            count++;
                            break;
                        case "B":
                            total += 3.0;
                            count++;
                            break;
                        case "B-":
                            total += 2.7;
                            count++;
                            break;
                        case "C+":
                            total += 2.3;
                            count++;
                            break;
                        case "C":
                            total += 2.0;
                            count++;
                            break;
                        case "C-":
                            total += 1.7;
                            count++;
                            break;
                        case "D+":
                            total += 1.3;
                            count++;
                            break;
                        case "D":
                            total += 1.0;
                            count++;
                            break;
                        case "D-":
                            total += 0.7;
                            count++;
                            break;
                        case "E":
                            total += 0;
                            count++;
                            break;
                    }

                }
            }
            return Json(new { gpa = total / count });
        }

        /*******End code to modify********/

    }
}