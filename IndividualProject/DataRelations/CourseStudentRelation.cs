using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.DataRelations
{
    class CourseStudentRelation:OneToManyRelation
    {
        public void AddStudentToCourse(int iD, string message)
        {

            if (this._relationIDs.Contains(iD)) Console.WriteLine("This student is already added in this course");
            else
            {
                this._relationIDs.Add(iD);
                //this._relationIDs.Sort();
                Console.WriteLine(message);
                
            }

        }

    }
}
