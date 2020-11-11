using IndividualProject.DataRelations;
using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.BusinessLogic
{
    class CommandPromptPrintUtils
    {
        public void PrintCourses(List<Course> courses, string message = null)
        {
            if (message != null) Console.WriteLine(message);
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i+1}: {courses[i].ToString()} ");
            }
        }
        public void PrintTrainers(List<Trainer> trainers, string message = null)
        {
            if (message != null) Console.WriteLine(message);
            for (int i = 0; i < trainers.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {trainers[i].ToString()} ");
            }
        }
        public void PrintStudents(List<Student> students, string message = null)
        {
            if (message != null) Console.WriteLine(message);
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {students[i].ToString()} ");
            }
        }
        public void PrintAssignments(List<Assignment> assignments, string message = null)
        {
            if (message != null) Console.WriteLine(message);
            for (int i = 0; i < assignments.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {assignments[i].ToString()} ");
            }
        }



        public void PrintTrainersInCourses(List<Course> courses, List<Trainer> trainers, List<CourseTrainersRelation> ctr) 
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"\nThe trainers in course {courses[i].Title} are:" );
                for (int j = 0; j < ctr[i].RelationID.Count; j++)
                {
                    Console.WriteLine(trainers[ctr[i].RelationID[j]].ToString());
                }
            }
        }

        public void PrintStudentsInCourses(List<Course> courses, List<Student> students, List<CourseStudentRelation> ctr)
        {
            if (courses.Count == 0) Console.WriteLine("No courses available");
            else if (students.Count == 0) Console.WriteLine("No students available");
            else
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"\nThe students in course {courses[i].Title} are:");
                    for (int j = 0; j < ctr[i].RelationID.Count; j++)
                    {
                        Console.WriteLine(students[ctr[i].RelationID[j]].ToString());
                    }
                }
            }
        }

        public void PrintAssignmentsInCourses(List<Course> courses, List<Assignment> assignments, List<CourseAssignmentRelation> car)
        {
            if (courses.Count == 0) Console.WriteLine("No courses available");
            else if (assignments.Count == 0) Console.WriteLine("No assignments available");
            else
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"\nThe assignments in course {courses[i].Title} are:");
                    for (int j = 0; j < car[i].RelationID.Count; j++)
                    {
                        Console.WriteLine(assignments[car[i].RelationID[j]].ToString());
                    }
                }
            }
        }

        public void PrintAssignmentsInSingleCourse(List<CourseAssignmentRelation> car, List<Assignment> assignments, int index) 
        {
            for (int i = 0; i < car[index].RelationID.Count; i++)
            {
                Console.WriteLine($"\t\t>>{assignments[car[index].RelationID[i]].Title}<< due to {assignments[car[index].RelationID[i]].SubDateTime.ToShortDateString()}");
                
            }
        }

        public void PrintAssignmentsPerStudent(List<Student> students, List<Assignment> assignments, List<StudentAssignmentsRelation> sar) // need to fix print
        {
            for (int studentID = 0; studentID < students.Count; studentID++)
            {
                Console.WriteLine($"Student {students[studentID].FirstName + " " + students[studentID].LastName} has the following assignments");

                foreach (int assignmentID in sar[studentID].RelationID)
                {
                    Console.WriteLine(assignments[assignmentID].ToString());
                }

            }
        }

        public void PrintStudentsWithPendingAssignments(List<Student> students, List<Assignment> assignments, List<StudentAssignmentsRelation> sar, DateTime dateRequested) 
        {
            DateTime monday = new DateTime();
            DateTime friday = new DateTime();
            FindMondayAndFriday(out monday, out friday, dateRequested);

            Console.WriteLine("Date requested is: " + dateRequested.ToShortDateString());
            Console.WriteLine("Monday is: " + monday.ToShortDateString());
            Console.WriteLine("Friday is: " + friday.ToShortDateString());
            Console.WriteLine("Here are the students that have assignments for the above week:");

            bool atLeastOne = false;

            for (int studentID = 0; studentID < students.Count; studentID++)
            {
                bool hasAssignment = false;
                foreach (int assignmentID in sar[studentID].RelationID)
                {
                    if (assignments[assignmentID].SubDateTime >= monday && assignments[assignmentID].SubDateTime <= friday) hasAssignment = true;atLeastOne = true;
                }
                if (hasAssignment)
                {
                    Console.WriteLine($"{students[studentID].FirstName} {students[studentID].LastName}");
                    hasAssignment = false;
                }
            }

            if (!atLeastOne) Console.WriteLine("No student has an assignment for the above week\n");

        }

        private void FindMondayAndFriday(out DateTime monday, out DateTime friday, DateTime date) 
        {
            if (date.DayOfWeek.ToString().Equals("Monday"))
            {
                monday = date;
                friday = date.AddDays(4);
            }
            else if (date.DayOfWeek.ToString().Equals("Tuesday"))
            {
                monday = date.AddDays(-1);
                friday = date.AddDays(3);
            }
            else if (date.DayOfWeek.ToString().Equals("Wednesday"))
            {
                monday = date.AddDays(-2);
                friday = date.AddDays(2);
            }
            else if (date.DayOfWeek.ToString().Equals("Thursday"))
            {
                monday = date.AddDays(-3);
                friday = date.AddDays(1);
            }
            else if (date.DayOfWeek.ToString().Equals("Friday"))
            {
                monday = date.AddDays(-4);
                friday = date;
            }
            else if (date.DayOfWeek.ToString().Equals("Saturday"))
            {
                monday = date.AddDays(-5);
                friday = date.AddDays(-1);
            }
            else //(date.DayOfWeek.ToString().Equals("Sunday"))
            {
                monday = date.AddDays(-6);
                friday = date.AddDays(-2);
            }


        }

    }
}
