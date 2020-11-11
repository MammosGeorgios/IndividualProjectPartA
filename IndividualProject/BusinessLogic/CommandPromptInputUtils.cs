using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Models;

namespace IndividualProject.BusinessLogic
{
    class CommandPromptInputUtils
    {
        public Trainer GetTrainerDetails(List<string> subjects = null) // OK 
        {
            if(subjects == null) subjects = new List<string>() { "C#", "Java", "Python", "JavaScript", "PHP" };
            Trainer trainer = new Trainer();

            trainer.FirstName = AskDetail("Give me your first name");
            trainer.LastName  = AskDetail("Give me your last name");
            trainer.Subject   = AskDetail("Give me the subject you teach", subjects);
            return (trainer);
        }

        public Course GetCourseDetails(List<string> stream = null, List<string> type = null) // OK  
        {
            if (stream == null) stream = new List<string>() { "C#", "Java", "Python", "JavaScript", "PHP" };
            if (type == null) type = new List<string>() { "Full Time - Online", "Part Time - Online", "Full Time - InClass", "Part Time - InClass", "Full Time - Hybrid", "Part Time - Hybrid" };
            Course course = new Course();

            course.Title = AskDetail("Give me the course's title");
            course.Stream = AskDetail("Give me the course's stream", stream);
            course.Type = AskDetail("Give me the course's type", type);
            course.StartDate = AskDate("Give me the course's start date");
            course.EndDate = AskDate("Give me the course's end date");
            return (course);
        }

        public Student GetStudentDetails() // OK - datetime/tuition need check
        {
            Student student = new Student();

            student.FirstName = AskDetail("Give me the student's first name");
            student.LastName = AskDetail("Give me the student's last name");
            student.DateOfBirth = AskDate("Give me the student's date of birth");
            student.TuitionFees = AskTuitionFee("Give me the tuition fee"); 

            return (student);
        }

        public Assignment GetAssignmentDetails(List<string> subjects = null) // OK
        {
            Assignment assignment = new Assignment();
            assignment.Title = AskDetail("Give me the assignment's title");
            assignment.Description = AskDetail("Give me the assignment's description");
            assignment.SubDateTime = AskDate("Give me the assignment's submission date");
            assignment.OralMark = AskValidNumber("Give me the assignment's oral mark", 0, 20);
            assignment.TotalMark = AskValidNumber("Give me the assignment's total mark", 0, 80);

            



            return (assignment);
        }

        private string AskDetail(string message, List<string> subjects = null) // OK 
        {
            string result = "";
            Console.Write(message + ": ");
            if(subjects != null)
            {
                // ask for the subject the trainer teaches
                result = SelectFromListOfStrings(subjects);
            } 
            else
            {
                result = Console.ReadLine();
            }
            return (result);
        }


        
        private string SelectFromListOfStrings(List<string> elements) // OK 
        {
            string result = "";
            int counter = 1;
            Console.WriteLine();
            foreach (var item in elements)
            {
                Console.WriteLine($"{counter++}. {item}");
            }
            //int choice = Convert.ToInt32(Console.ReadLine());

            int choice = AskValidNumber("", 1, elements.Count);
            result = elements.ElementAt(choice - 1); //elements[choice - 1];
            return (result);
        }

        private void PrintTrainersList(List<Trainer> trainers) // NADA 
        {
            foreach (var item in trainers)
            {
                Console.WriteLine(item);
            }
        }       
        
        public DateTime AskDate(string message) // A
        {
            DateTime result;
            int day, month, year;

            Console.WriteLine(message + ": ");
            year = AskValidNumber("Give year number", 1900, 2021);
            month = AskValidNumber("Give month number", 1, 12);
            day = AskValidDay("Give day number", 1, 31);   

            result = new DateTime(year, month, day);
            return (result);
        }
        private int AskValidDay(string message, int month, int year) // OK 
        {
            int result;
            int maxNumberOfDays = DateTime.DaysInMonth(year, month);
            result = AskValidNumber(message, 1, maxNumberOfDays);
            return (result);
        }

        public int AskValidNumber(string message, int minValue , int maxValue) // OK
        {
            int result = 0;
            bool isValidFlag = false;
            string input;
            while (!isValidFlag) 
            {
                Console.WriteLine(message + ": ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) Console.WriteLine("INVALID INPUT, must not be an empty/white space input");
                else
                {
                    if (!Int32.TryParse(input, out result)) Console.WriteLine("INVALID INPUT, must be an interger");
                    else 
                    {
                        if (minValue <= result && result <= maxValue)isValidFlag = true;
                        else Console.WriteLine($"INVALID INPUT, number must be equal or between {minValue} and {maxValue}");
                    }
                }
            }
            return (result);
        }

        private decimal AskTuitionFee(string message) 
        {
            decimal result = 0;
            bool isValidFlag = false;
            decimal minValue = 0;


            while (!isValidFlag)
            {
                result = AskValidDecimal(message);
                if (minValue <= result)
                {
                    isValidFlag = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input, number must be bigger than {minValue}");
                }
            }
            return (result);
        }

        private decimal AskValidDecimal(string message) 
        {
            
                decimal result = 0;
                bool isValidFlag = false;
                string input;
                while (!isValidFlag)
                {
                    Console.WriteLine(message + ": ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) Console.WriteLine("INVALID INPUT, must not be an empty/white space input");
                    else
                    {
                        if (!decimal.TryParse(input, out result)) Console.WriteLine("INVALID INPUT, must be a number");
                        else isValidFlag = true;
                    }


                }
            return result;
            }
    }
}
