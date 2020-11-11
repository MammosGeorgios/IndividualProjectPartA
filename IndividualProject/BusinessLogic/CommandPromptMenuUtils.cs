using IndividualProject.DataRelations;
using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.BusinessLogic
{
    class CommandPromptMenuUtils
    {
        public CommandPromptMenuUtils()
        {
            menu();
        }

        public void menu()
        {
            // Initializing objects and Lists
            CommandPromptInputUtils cpUtils = new CommandPromptInputUtils();
            List<Course> courses = new List<Course>();
            List<Trainer> trainers = new List<Trainer>();
            List<Student> students = new List<Student>();
            List<Assignment> assignments = new List<Assignment>();

            CommandPromptPrintUtils printUtils = new CommandPromptPrintUtils();
            CommandPromptRelationsUtils relUtil = new CommandPromptRelationsUtils();

            List<CourseTrainersRelation> courseTrainers = new List<CourseTrainersRelation>();
            List<CourseStudentRelation> courseStudents = new List<CourseStudentRelation>();
            List<CourseAssignmentRelation> courseAssignments = new List<CourseAssignmentRelation>();

            List<string> menuOptions = new List<string>() { "Add new course", "Add new trainer", "Add new student", "Add new assigmnemt", 
                                                            "Add a student to a course", "Add a trainer to a course", "Add an assignment to a course",
                                                            "Print all students per course","Print all trainers per course", "Print all assignments per course","Print all assignments per student",
                                                            "Print students that belong in multiple classes","Print all students pending assignments by a scecific date", 
                                                            "Initialize sample data - (will delete any previous data)", "Exit\n" };


            GreetingMessage();
            //Menu loop
            bool exit = false;
            bool sameChoice = false;
            int menuChoice = 0;
            while (!exit)
            {
                if (!sameChoice)
                {
                    ShowOptions(menuOptions);
                    menuChoice = ReadMenuInput(menuOptions.Count);
                }

                switch (menuChoice) 
                {
                    case 1:
                        courses.Add(cpUtils.GetCourseDetails());
                        courseTrainers.Add(new CourseTrainersRelation());
                        courseAssignments.Add(new CourseAssignmentRelation());
                        courseStudents.Add(new CourseStudentRelation());
                        break;
                    case 2:
                        trainers.Add(cpUtils.GetTrainerDetails());
                        break;
                    case 3:
                        students.Add(cpUtils.GetStudentDetails());
                        break;
                    case 4:
                        assignments.Add(cpUtils.GetAssignmentDetails());
                        break;
                    case 5:
                        AddStudentInCourseOption(courses, students, courseStudents);
                        break;
                    case 6:                        
                        AddTrainerInCourseOption(courses, trainers, courseTrainers);
                        break;
                    case 7:
                        AddAssignmentInCourseOption(courses, assignments, courseAssignments);
                        break;
                    case 8:                        
                        printUtils.PrintStudentsInCourses(courses, students, courseStudents);
                        break;
                    case 9:
                        printUtils.PrintTrainersInCourses(courses, trainers, courseTrainers);
                        break;
                    case 10:                       
                        printUtils.PrintAssignmentsInCourses(courses, assignments, courseAssignments);
                        break;
                    case 11:
                        PrintAssignmentsPerStudent(courses, assignments, students, courseAssignments, courseStudents);
                        break;
                    case 12:
                        PrintStudentsInMultipleClasses(students, courseStudents);
                        break;
                    case 13:
                        PrintListOfStudentsWithAssignments(courses, assignments, students, courseAssignments, courseStudents);
                        break;
                    case 14:
                        InputTestData(out courses,out trainers,out assignments,out students,out courseTrainers,out courseStudents,out courseAssignments);
                        break;

                    default:
                        exit = true;
                        break;
                }
                if (!exit)
                {
                    sameChoice = SameChoiceQuestion();
                }



            }

            Console.WriteLine("Goodbye!!!");

        }

        private void GreetingMessage()
        {
            Console.WriteLine("Welcome to the C# Individual Project - Made by Mammos Georgios");
        }
        private void ShowOptions(List<string> menuOptions = null) 
        { 
            if (menuOptions == null )menuOptions = new List<string>() { "Add Course", "Add Trainer", "Add Student", "Add Assignment" };
            PrintListNumbered(menuOptions);
        }
        private void PrintListNumbered(List<string> list) 
        {
            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}: {list[i]}");
            }
        }
        private int ReadMenuInput(int optionsCount) 
        {
            CommandPromptInputUtils cpUtils = new CommandPromptInputUtils();
            int result = 0;
            result = cpUtils.AskValidNumber("Select one of the above options by writing its number", 1, optionsCount);
            return (result);          

        }
        private bool SameChoiceQuestion() 
        {
            bool result = false;
            Console.WriteLine("If you want to repeat the last option selected from the menu, type YES , otherwise press enter (or give any other input).");
            if (Console.ReadLine() == "YES") result = true;
            return (result);
        }
        private void AddTrainerInCourseOption(List<Course> courses, List<Trainer> trainers, List<CourseTrainersRelation> ctr) 
        {
            if (courses.Count == 0) Console.WriteLine("No courses available yet");
            else if (trainers.Count == 0) Console.WriteLine("No trainers available yet");
            else
            {
                int courseID, trainerID;
                CommandPromptPrintUtils printUtils = new CommandPromptPrintUtils();
                printUtils.PrintCourses(courses, "Here is the list of courses.");
                courseID = ReadMenuInput(courses.Count) - 1;
                printUtils.PrintTrainers(trainers, "Here is the list of trainers");
                trainerID = ReadMenuInput(trainers.Count) - 1;
                ctr[courseID].AddTrainerToCourse(trainerID, $"Trainer no. {trainerID + 1} added in course no. {courseID + 1}\n");
                //Console.WriteLine($"Trainer no. {trainerID+1} added in course no. {courseID+1}\n");

                
            }

        }
        private void AddStudentInCourseOption(List<Course> courses,List<Student> students, List<CourseStudentRelation> csr)
        {
            if (courses.Count == 0) Console.WriteLine("No courses available yet");
            else if (students.Count == 0) Console.WriteLine("No trainers available yet");
            else
            {
                int courseID, studentID;
                CommandPromptPrintUtils printUtils = new CommandPromptPrintUtils();
                printUtils.PrintCourses(courses, "Here is the list of courses.");
                courseID = ReadMenuInput(courses.Count) - 1;
                printUtils.PrintStudents(students, "Here is the list of students");
                studentID = ReadMenuInput(students.Count) - 1;
                csr[courseID].AddStudentToCourse(studentID, $"Student no.{studentID+1} added in course no.{courseID + 1}\n");
                //Console.WriteLine($"Student no. {studentID + 1} added in course no. {courseID + 1}\n");


            }

        }
        private void AddAssignmentInCourseOption(List<Course> courses, List<Assignment> assignments, List<CourseAssignmentRelation> car)
        {
            if (courses.Count == 0) Console.WriteLine("No courses available yet");
            else if (assignments.Count == 0) Console.WriteLine("No assignments available yet");
            else
            {
                int courseID, assignmentID;
                CommandPromptPrintUtils printUtils = new CommandPromptPrintUtils();
                printUtils.PrintCourses(courses, "Here is the list of courses.");
                courseID = ReadMenuInput(courses.Count) - 1;
                printUtils.PrintAssignments(assignments, "Here is the list of students");
                assignmentID = ReadMenuInput(assignments.Count) - 1;
                car[courseID].AddAssignmentToCourse(assignmentID, $"Assignment no.{assignmentID + 1} added in course no.{courseID + 1}\n");

            }
        }
        private void PrintAssignmentsPerStudent(List<Course> courses, List<Assignment> assignments, List<Student> students, List<CourseAssignmentRelation> car, List<CourseStudentRelation> csr) 
        {

            CommandPromptRelationsUtils cpru = new CommandPromptRelationsUtils();
            List<StudentAssignmentsRelation> sar = cpru.FindAssignmentsPerStudent(courses, assignments, students, car, csr);
            CommandPromptPrintUtils cppu = new CommandPromptPrintUtils();
            cppu.PrintAssignmentsPerStudent(students, assignments, sar);

        }
        private void PrintStudentsInMultipleClasses(List<Student> students, List<CourseStudentRelation> csr) 
        {
            bool anyStudentEnrolledInMultipleCourses = false;
            for (int i = 0; i < students.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < csr.Count; j++)
                {
                    if (csr[j].RelationID.Contains(i)) count++;

                }

                if (count >= 2)
                {
                    anyStudentEnrolledInMultipleCourses = true;
                    Console.WriteLine($"Student {students[i].FirstName + " " + students[i].LastName} is enrolled in {count} courses");
                }

                if (!anyStudentEnrolledInMultipleCourses) Console.WriteLine("No students are enrolled in multiple courses");
            }
        }
        private void PrintListOfStudentsWithAssignments(List<Course> courses, List<Assignment> assignments, 
                                List<Student> students, List<CourseAssignmentRelation> car, List<CourseStudentRelation> csr) 
        {
            
            CommandPromptRelationsUtils cpru = new CommandPromptRelationsUtils();
            CommandPromptPrintUtils cppu = new CommandPromptPrintUtils();
            CommandPromptInputUtils cpiu = new CommandPromptInputUtils();

            List<StudentAssignmentsRelation> sar = cpru.FindAssignmentsPerStudent(courses, assignments, students, car, csr);            
            DateTime askedDate = cpiu.AskDate("Give me the date you want to find students with assignments for");
            cppu.PrintStudentsWithPendingAssignments(students, assignments, sar, askedDate);


        }


        private void InputTestData(out List<Course> courses,out List<Trainer> trainers,out List<Assignment> assignments,
                                       out List<Student> students,out List<CourseTrainersRelation> courseTrainers,
                                       out List<CourseStudentRelation> courseStudents, out List<CourseAssignmentRelation> courseAssignments)
        {
            // Creating test data
            TestData tD = new TestData();
            courses = tD.TestCourseData();
            trainers = tD.TestTrainerData();
            courseTrainers = tD.TestCourseTrainerData(courses.Count);
            students = tD.TestStudentData();
            courseStudents = tD.TestCourseStudentData(courses.Count);
            assignments = tD.TestAssignmentData();
            courseAssignments = tD.TestCourseAssignmentData(courses.Count);




        }



    }
}
