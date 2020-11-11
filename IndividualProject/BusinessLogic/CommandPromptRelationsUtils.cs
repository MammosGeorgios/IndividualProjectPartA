using IndividualProject.DataRelations;
using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.BusinessLogic
{
    class CommandPromptRelationsUtils
    {
        public void PrintTrainersInCourseTrainerRelation(CourseTrainersRelation ctr,List<Trainer> trainers)

        {
            if (ctr.RelationID == null) Console.WriteLine("No trainers in this course");
            else
            {
                Console.WriteLine("Trainers in this course");
                for (int i = 0; i < ctr.RelationID.Count; i++)
                {
                    Console.WriteLine($"{trainers[ctr.RelationID[i]]}");
                }
            }
        }

        public List<StudentAssignmentsRelation> FindAssignmentsPerStudent(List<Course> courses, List<Assignment> assignments, List<Student> students, List<CourseAssignmentRelation> car, List<CourseStudentRelation> csr)
        {

            List<StudentAssignmentsRelation> sar = new List<StudentAssignmentsRelation>();

            CommandPromptPrintUtils cp = new CommandPromptPrintUtils();
            for (int studentID = 0; studentID < students.Count; studentID++)
            {
                sar.Add(new StudentAssignmentsRelation());
                //Console.WriteLine($"Student {students[studentID].FirstName + " " + students[studentID].LastName} has the following assignments");
                for (int courseID = 0; courseID < csr.Count; courseID++)
                {
                    if (csr[courseID].RelationID.Contains(studentID))
                    {
                        //Console.WriteLine($"\tFor the {courses[courseID].Title} course: ");
                        ////i want to print the assignments here
                        //cp.PrintAssignmentsInSingleCourse(car, assignments, courseID);

                        for (int k = 0; k < car[courseID].RelationID.Count; k++)
                        {
                            sar[studentID].RelationID.Add(car[courseID].RelationID[k]);
                        }
                    }
                        
                    
                        
                }
            }

            return (sar);

        }


        public void PrintTrainersInCourse(List<Course> courses,List<CourseTrainersRelation> ctrList,List<Trainer> trainers) 
        {
            Console.WriteLine("Select a course from the following");
            //PrintListNumbered(courses);



         }

        


    }

    
}
