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
    [Authorize(Roles = "Professor")]
    public class ProfessorController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
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

        public IActionResult Categories(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
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

        public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }

        public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            ViewData["uid"] = uid;
            return View();
        }

        /*******Begin code to modify********/


        /// <summary>
        /// Returns a JSON array of all the students in a class.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "dob" - date of birth
        /// "grade" - the student's grade in this class
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
        {
            var queryCourse = (from c in db.Courses
                               where c.SubjectAbbreviation == subject
                               where c.Number == num
                               select new
                               {
                                   courseID = c.CId
                               }).FirstOrDefault();

            var queryClass = (from cl in db.Classes
                              where cl.CId == queryCourse.courseID
                              where cl.Season == season
                              where cl.Year == year
                              select new
                              {
                                  classID = cl.ClassId
                              }).FirstOrDefault();

            var queryES = from e in db.Enroll
                          join s in db.Students
                          on e.Id equals s.Id
                          where e.ClassId == queryClass.classID
                          select new
                          {
                              fname = s.FirstName,
                              lname = s.LastName,
                              uid = s.Id,
                              dob = s.Dob,
                              grade = e.Grade
                          };


            return Json(queryES.ToArray());
        }



        /// <summary>
        /// Returns a JSON array with all the assignments in an assignment category for a class.
        /// If the "category" parameter is null, return all assignments in the class.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The assignment category name.
        /// "due" - The due DateTime
        /// "submissions" - The number of submissions to the assignment
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class, 
        /// or null to return assignments from all categories</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
        {
            if (category == null)
            {
                var queryAASA = from c in db.Courses
                                join cl in db.Classes
                                on c.CId equals cl.CId
                                join ac in db.AssignmentCategories
                                on cl.ClassId equals ac.ClassId
                                join a in db.Assignments
                                on ac.AcId equals a.AcId
                                where c.SubjectAbbreviation == subject
                                where c.Number == (uint)num
                                where cl.Season == season
                                where cl.Year == year
                                select new
                                {
                                    aname = a.Name,
                                    cname = ac.Name,
                                    due = a.DueDate,
                                    submissions = a.Submission.Count
                                };

                return Json(queryAASA.ToArray());

            }

            var queryASA = from c in db.Courses
                           join cl in db.Classes
                           on c.CId equals cl.CId
                           join ac in db.AssignmentCategories
                           on cl.ClassId equals ac.ClassId
                           join a in db.Assignments
                           on ac.AcId equals a.AcId
                           where c.SubjectAbbreviation == subject
                           where c.Number == (uint)num
                           where cl.Season == season
                           where cl.Year == year
                           where ac.Name == category
                           select new
                           {
                               aname = a.Name,
                               cname = ac.Name,
                               due = a.DueDate,
                               submissions = a.Submission.Count
                           };

            return Json(queryASA.ToArray());
        }


        /// <summary>
        /// Returns a JSON array of the assignment categories for a certain class.
        /// Each object in the array should have the following fields:
        /// "name" - The category name
        /// "weight" - The category weight
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
        {
            var queryCourse = (from c in db.Courses
                               where c.SubjectAbbreviation == subject
                               where c.Number == num
                               select new
                               {
                                   courseID = c.CId
                               }).FirstOrDefault();

            var queryClass = (from cl in db.Classes
                              where cl.CId == queryCourse.courseID
                              where cl.Season == season
                              where cl.Year == year
                              select new
                              {
                                  classID = cl.ClassId
                              }).FirstOrDefault();

            var queryA = from ac in db.AssignmentCategories
                         where ac.ClassId == queryClass.classID
                         select new
                         {
                             name = ac.Name,
                             weight = ac.GradeWeight
                         };


            return Json(queryA.ToArray());
        }

        /// <summary>
        /// Creates a new assignment category for the specified class.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The new category name</param>
        /// <param name="catweight">The new category weight</param>
        /// <returns>A JSON object containing {success = true/false},
        ///	false if an assignment category with the same name already exists in the same class.</returns>
        public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
        {
            bool createSuccess = false;
            bool add = true;
            var queryCourse = (from c in db.Courses
                               where c.SubjectAbbreviation == subject
                               where c.Number == num
                               select new
                               {
                                   courseID = c.CId
                               }).FirstOrDefault();

            var queryClass = (from cl in db.Classes
                              where cl.CId == queryCourse.courseID
                              where cl.Season == season
                              where cl.Year == year
                              select new
                              {
                                  classID = cl.ClassId
                              }).FirstOrDefault();

            var queryA = from ac in db.AssignmentCategories
                         where ac.ClassId == queryClass.classID
                         select new
                         {
                             name = ac.Name,
                             weight = ac.GradeWeight
                         };

            foreach (var cat in queryA)
            {
                if (cat.name.Equals(category))
                {
                    add = false;
                }
            }

            if (add)
            {
                AssignmentCategories aCat = new AssignmentCategories();
                aCat.Name = category;
                aCat.ClassId = queryClass.classID;
                aCat.GradeWeight = (uint)catweight;
                db.AssignmentCategories.Add(aCat);
                createSuccess = true;
            }

            var queryE = from e in db.Enroll
                         where e.ClassId == queryClass.classID
                         select e.Id;

            db.SaveChanges();

            foreach (var s in queryE)
            {
                UpdateGrade(subject, num, season, year, s);
            }

            return Json(new { success = createSuccess });
        }

        /// <summary>
        /// Creates a new assignment for the given class and category.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="asgpoints">The max point value for the new assignment</param>
        /// <param name="asgdue">The due DateTime for the new assignment</param>
        /// <param name="asgcontents">The contents of the new assignment</param>
        /// <returns>A JSON object containing success = true/false,
        /// false if an assignment with the same name already exists in the same assignment category.</returns>
        public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
        {
            bool createSuccess = false;
            bool add = true;
            var queryCourse = (from c in db.Courses
                               where c.SubjectAbbreviation == subject
                               where c.Number == num
                               select new
                               {
                                   courseID = c.CId
                               }).FirstOrDefault();

            var queryClass = (from cl in db.Classes
                              where cl.CId == queryCourse.courseID
                              where cl.Season == season
                              where cl.Year == year
                              select new
                              {
                                  classID = cl.ClassId
                              }).FirstOrDefault();

            var queryAC = (from ac in db.AssignmentCategories
                           where ac.ClassId == queryClass.classID
                           where ac.Name == category
                           select new
                           {
                               acID = ac.AcId
                           }).FirstOrDefault();

            var queryA = from a in db.Assignments
                         where a.AcId == queryAC.acID
                         select a;

            foreach (var assignment in queryA)
            {
                if (assignment.Name.Equals(asgname))
                {
                    add = false;
                }
            }

            int qeuryAssignmentC = (from a in db.Assignments
                                    select a).Count();

            if (add)
            {
                Assignments asg = new Assignments();
                asg.Name = asgname;
                asg.AcId = queryAC.acID;
                asg.MaxPointVal = (uint)asgpoints;
                asg.Contents = asgcontents;
                asg.DueDate = asgdue;
                asg.AsId = (uint)(qeuryAssignmentC + 1);
                db.Assignments.Add(asg);
                createSuccess = true;
            }
            db.SaveChanges();

            return Json(new { success = createSuccess });
        }


        /// <summary>
        /// Gets a JSON array of all the submissions to a certain assignment.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "time" - DateTime of the submission
        /// "score" - The score given to the submission
        /// 
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
        {
            var queryCourse = (from c in db.Courses
                               where c.SubjectAbbreviation == subject
                               where c.Number == num
                               select new
                               {
                                   courseID = c.CId
                               }).FirstOrDefault();

            var queryClass = (from cl in db.Classes
                              where cl.CId == queryCourse.courseID
                              where cl.Season == season
                              where cl.Year == year
                              select new
                              {
                                  classID = cl.ClassId
                              }).FirstOrDefault();

            var queryAC = (from ac in db.AssignmentCategories
                           where ac.ClassId == queryClass.classID
                           where ac.Name == category
                           select new
                           {
                               acID = ac.AcId
                           }).FirstOrDefault();


            var queryA = from a in db.Assignments
                         join s in db.Submission
                         on a.AsId equals s.AsId
                         join st in db.Students
                         on s.Id equals st.Id
                         where a.AcId == queryAC.acID
                         where a.Name == asgname
                         select new
                         {
                             fname = st.FirstName,
                             lname = st.LastName,
                             uid = s.Id,
                             time = s.Time,
                             score = s.Score
                         };

            return Json(queryA.ToArray());
        }


        /// <summary>
        /// Set the score of an assignment submission
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <param name="uid">The uid of the student who's submission is being graded</param>
        /// <param name="score">The new score for the submission</param>
        /// <returns>A JSON object containing success = true/false</returns>
        public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
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
                        select s;

            foreach (var q in query)
            {
                q.Score = (uint)score;
            }

            db.SaveChanges();
            UpdateGrade(subject, num, season, year, uid);
            db.SaveChanges();
            return Json(new { success = true });
        }


        /// <summary>
        /// Returns a JSON array of the classes taught by the specified professor
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester in which the class is taught
        /// "year" - The year part of the semester in which the class is taught
        /// </summary>
        /// <param name="uid">The professor's uid</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {
            var query = from p in db.Professors
                        join c in db.Classes
                        on p.Id equals c.Id
                        join co in db.Courses
                        on c.CId equals co.CId
                        where p.Id == uid
                        select new
                        {
                            subject = co.SubjectAbbreviation,
                            number = co.Number,
                            name = co.Name,
                            season = c.Season,
                            year = c.Year
                        };

            return Json(query.ToArray());
        }

        /// <summary>
        /// A helper method to update a student's grade if a professor scores a student's submission
        /// or creates a new assignment.
        /// </summary>
        /// <param name="subject">The subject abbreviation of the class</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="uid">The uid of the student who's submission is being graded</param>
        private void UpdateGrade(string subject, int num, string season, int year, string uid)
        {
            var query = from c in db.Courses
                        join cl in db.Classes
                        on c.CId equals cl.CId
                        join ac in db.AssignmentCategories
                        on cl.ClassId equals ac.ClassId
                        where c.SubjectAbbreviation == subject
                        where cl.Season == season
                        where cl.Year == year
                        where c.Number == num
                        select new
                        {
                            acWeight = ac.GradeWeight,
                            assignments = from a in db.Assignments
                                          join s in db.Submission
                                          on a.AsId equals s.AsId
                                          where a.AcId == ac.AcId
                                          where s.Id == uid
                                          select new
                                          {
                                              aMaxpoint = a.MaxPointVal,
                                              score = s.Score
                                          }
                        };

            double percentage = 0;
            int totalWeight = 0;
            foreach (var asgC in query)
            {
                int totalPoints = 0;
                int totalMaxPoints = 0;
                foreach (var asg in asgC.assignments)
                {
                    totalPoints += (int)asg.score;
                    totalMaxPoints += (int)asg.aMaxpoint;
                }
                if (totalMaxPoints == 0)
                {
                    return;
                }
                percentage += ((double)totalPoints / totalMaxPoints) * asgC.acWeight;
                totalWeight += (int)asgC.acWeight;
            }


            double scalingFactor = 100 / (double)totalWeight;
            double totalPercentage = percentage * scalingFactor;

            String letterGrade = "";
            if (totalPercentage >= 93)
            {
                letterGrade = "A";
            }
            else if (totalPercentage >= 90)
            {
                letterGrade = "A-";
            }
            else if (totalPercentage >= 87)
            {
                letterGrade = "B+";
            }
            else if (totalPercentage >= 83)
            {
                letterGrade = "B";
            }
            else if (totalPercentage >= 80)
            {
                letterGrade = "B-";
            }
            else if (totalPercentage >= 77)
            {
                letterGrade = "C+";
            }
            else if (totalPercentage >= 73)
            {
                letterGrade = "C";
            }
            else if (totalPercentage >= 70)
            {
                letterGrade = "C-";
            }
            else if (totalPercentage >= 67)
            {
                letterGrade = "D+";
            }
            else if (totalPercentage >= 63)
            {
                letterGrade = "D";
            }
            else if (totalPercentage >= 60)
            {
                letterGrade = "D-";
            }
            else
            {
                letterGrade = "E";
            }

            var QueryE = from e in db.Enroll
                         join cl in db.Classes
                         on e.ClassId equals cl.ClassId
                         join c in db.Courses
                         on cl.CId equals c.CId
                         where c.SubjectAbbreviation == subject
                         where cl.Season == season
                         where cl.Year == year
                         where c.Number == num
                         where e.Id == uid
                         select e;

            foreach (var er in QueryE)
            {
                er.Grade = letterGrade;
            }
            db.SaveChanges();
        }

        /*******End code to modify********/

    }
}