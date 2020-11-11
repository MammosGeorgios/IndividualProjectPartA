using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.DataRelations
{
    class CourseTrainersRelation:OneToManyRelation
    {
        // private int _courseID; // Position of course in the main List<Course>
        // private List<int> _trainerIDs; // Position of trainers in the main List<Trainer>

        //public int CourseID
        //{ 
        //    get { return this._courseID; }
        //    set { this._courseID = value; }
        //}

        //public List<int> TrainerIDs
        //{
        //    get { return this._trainerIDs; }
        //    private set { }
        //}


        //public CourseTrainersRelation()
        //{
        //    this._trainerIDs = new List<int>();
        //}

        //public void AddTrainerToCourse(int trainerID, string message)
        //{

        //    if (this._trainerIDs.Contains(trainerID)) Console.WriteLine("This trainer is already added in this course");
        //    else
        //    {
        //        this._trainerIDs.Add(trainerID);
        //        //this.TrainerIDs.Sort();
        //        Console.WriteLine(message);
        //    }

        //}

        public void AddTrainerToCourse(int trainerID, string message)
        {

            if (this._relationIDs.Contains(trainerID)) Console.WriteLine("This trainer is already added in this course");
            else
            {
                this._relationIDs.Add(trainerID);
                //this.TrainerIDs.Sort();
                Console.WriteLine(message);
            }

        }

    }
}
