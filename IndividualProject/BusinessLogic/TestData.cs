using IndividualProject.DataRelations;
using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.BusinessLogic
{
    class TestData
    {
        // these methods do not validate data, only for testing!
        public Course SingleCourse(string title, string stream, string type, DateTime startDate,DateTime endDate)
        {
            Course course = new Course();

            course.Title = title;
            course.Stream = stream;
            course.Type = type;
            course.StartDate = startDate;
            course.EndDate = endDate;

            return (course);            
        }
        public Trainer SingleTrainer(string firstName, string lastName, string subject) 
        {
            Trainer trainer = new Trainer();
            trainer.FirstName = firstName;
            trainer.LastName = lastName;
            trainer.Subject = subject;
            return (trainer);
        }
        public Student SingleStudent(string firstName, string lastName, DateTime dateOfBirth, decimal tuition) 
        {
            Student student = new Student();

            student.FirstName = firstName;
            student.LastName = lastName;
            student.DateOfBirth = dateOfBirth;
            student.TuitionFees = tuition;

            return (student);
        }
        public Assignment SingleAssignment(string title, string description, DateTime submissionDate, double oral, double total) 
        {
            Assignment ag = new Assignment();

            ag.Title = title;
            ag.Description = description;
            ag.SubDateTime = submissionDate;
            ag.OralMark = oral;
            ag.TotalMark = total;

            return (ag);

        }

        public List<Course> TestCourseData()
        {
            List<Course> courses = new List<Course>();

            courses.Add(SingleCourse("Class 12 - C# - Full Time", "C#", "Full Time - Hybrid", new DateTime(2020, 10, 10), new DateTime(2021, 1, 31)));
            courses.Add(SingleCourse("Class 12 - C# - Part Time", "C#", "Part Time - Hybrid", new DateTime(2020, 10, 10), new DateTime(2021, 4, 30)));
            courses.Add(SingleCourse("Class 12 - Java - Full Time", "Java", "Full Time - Hybrid", new DateTime(2020, 10, 10), new DateTime(2021, 1, 31)));            
            courses.Add(SingleCourse("Class 12 - Java - Part Time", "Java", "Part Time - Hybrid", new DateTime(2020, 10, 10), new DateTime(2021, 4, 30)));
            courses.Add(SingleCourse("Class 12 - Python - Full Time", "Python", "Full Time - Hybrid", new DateTime(2020, 10, 10), new DateTime(2021, 1, 31)));
            courses.Add(SingleCourse("Class 12 - Python - Part Time", "Python", "Part Time - Hybrid", new DateTime(2020, 10, 10), new DateTime(2021, 4, 30)));

            return (courses);
        }
        public List<Trainer> TestTrainerData() 
        {
            List<Trainer> trainers = new List<Trainer>();
            trainers.Add(SingleTrainer("George","Pasparakis","C#"));
            trainers.Add(SingleTrainer("John", "Pasparakis", "Java"));
            trainers.Add(SingleTrainer("George", "Pasparakidis", "Python"));
            return (trainers);
        }
        public List<Student> TestStudentData()
        {
            List<Student> students = new List<Student>();
            students.Add(SingleStudent("George","Mammos",new DateTime(1993,12,11),2500));
            students.Add(SingleStudent("John", "Mammos", new DateTime(1993, 12, 11), 2500));
            students.Add(SingleStudent("Jimmmer", "Mammos", new DateTime(1993, 12, 11), 2500));
            students.Add(SingleStudent("Jake", "Mammos", new DateTime(1993, 12, 11), 2500));
            students.Add(SingleStudent("George", "Stalone", new DateTime(1994, 1, 11), 2250));
            students.Add(SingleStudent("John", "Stalone", new DateTime(1993, 12, 11), 2250));
            students.Add(SingleStudent("Jimmmer", "Stalone", new DateTime(1993, 12, 11), 2250));
            students.Add(SingleStudent("Jake", "Stalone", new DateTime(1993, 12, 11), 2250));
            students.Add(SingleStudent("George", "Malone", new DateTime(1994, 1, 11), 2250));
            students.Add(SingleStudent("John", "Malone", new DateTime(1993, 12, 11), 2250));
            students.Add(SingleStudent("Jimmmer", "Malone", new DateTime(1993, 12, 11), 2250));
            students.Add(SingleStudent("Jake", "Malone", new DateTime(1993, 12, 11), 2250));
            students.Add(SingleStudent("George", "Rocky", new DateTime(1996, 12, 11), 2500));
            students.Add(SingleStudent("John", "Rocky", new DateTime(1996, 12, 11), 2500));
            students.Add(SingleStudent("Jimmmer", "Rocky", new DateTime(1996, 12, 11), 2500));
            students.Add(SingleStudent("Jake", "Rocky", new DateTime(1996, 12, 11), 2500));
            students.Add(SingleStudent("George", "Wick", new DateTime(2000, 12, 11), 2500));
            students.Add(SingleStudent("John", "Wick", new DateTime(2000, 12, 11), 2500));
            students.Add(SingleStudent("Jimmmer", "Wick", new DateTime(2000, 12, 11), 2500));
            students.Add(SingleStudent("Jake", "Wick", new DateTime(2000, 12, 11), 2500)); //20 so far

            return (students);

        }
        public List<Assignment> TestAssignmentData() 
        {
            List<Assignment> assignments = new List<Assignment>();
            
            assignments.Add(SingleAssignment("AS01- Part A","The first part of the individual project",new DateTime(2020,11,12), 20,80));
            assignments.Add(SingleAssignment("AS01- Part B", "The second part of the individual project", new DateTime(2020, 11, 25), 20, 80));
            assignments.Add(SingleAssignment("AS01- Part C", "The third part of the individual project", new DateTime(2020, 12, 10), 20, 80));
            assignments.Add(SingleAssignment("AS01- Final", "The final part of the individual project", new DateTime(2020, 12, 23), 20, 80));
            
            assignments.Add(SingleAssignment("AS02 - Part A", "The first part of the individual project", new DateTime(2020, 11, 12), 20, 80));
            assignments.Add(SingleAssignment("AS02 - Part B", "The second part of the individual project", new DateTime(2020, 12, 12), 20, 80));
            assignments.Add(SingleAssignment("AS02 - Part C", "The third part of the individual project", new DateTime(2021, 1, 12), 20, 80));
            assignments.Add(SingleAssignment("AS02 - Final", "The final part of the individual project", new DateTime(2021, 1, 31), 20, 80));


            return (assignments);
        }
        public List<CourseTrainersRelation> TestCourseTrainerData( int courseCount) 
        {
            List<CourseTrainersRelation> cT = new List<CourseTrainersRelation>();
            // Make sure there are enough in case i edit the TestCourseData
            for (int i = 0; i < courseCount; i++)
            {
                cT.Add(new CourseTrainersRelation());
            }

            cT[0].RelationID.Add(0); //Pasparakis teaches all day every day
            cT[1].RelationID.Add(0);
            cT[1].RelationID.Add(2); // C - part time has 2 teachers
            cT[2].RelationID.Add(1);

            return (cT);
        }
        public List<CourseStudentRelation> TestCourseStudentData(int courseCount)
        {
            List<CourseStudentRelation> cS = new List<CourseStudentRelation>();
            // Make sure there are enough in case i edit the TestCourseData
            for (int i = 0; i < courseCount; i++)
            {
                cS.Add(new CourseStudentRelation());
            }

            for (int i = 0; i < 10; i++)
            {
                cS[0].RelationID.Add(i); // Add the first 10 students to C# FUll time
            }
            for (int i = 10; i < 20; i++)
            {
                cS[1].RelationID.Add(i); // Add the second 10 students to C# part time
            }
            cS[3].RelationID.Add(0); // George Mammos is enrolling in two classes


            return (cS);
        }
        public List<CourseAssignmentRelation> TestCourseAssignmentData(int courseCount) 
        {
            List<CourseAssignmentRelation> cA = new List<CourseAssignmentRelation>();
            // Make sure there are enough in case i edit the TestCourseData
            for (int i = 0; i < courseCount; i++)
            {
                cA.Add(new CourseAssignmentRelation());
            }
            
            for (int i = 0; i < 4; i++)
            {
                cA[0].RelationID.Add(i); // C# Full Time
                cA[1].RelationID.Add(i+4); //Part time C#
                cA[2].RelationID.Add(i);
                cA[3].RelationID.Add(i+4);// Java part time

            }

            


            return (cA);
        }

        

    }
}
