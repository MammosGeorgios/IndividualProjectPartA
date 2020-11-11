using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.DataRelations
{
    class CourseAssignmentRelation:OneToManyRelation
    {
        public void AddAssignmentToCourse(int iD, string message)
        {

            if (this._relationIDs.Contains(iD)) Console.WriteLine("This assignment is already added in this course");
            else
            {
                this._relationIDs.Add(iD);
                //this._relationIDs.Sort();
                Console.WriteLine(message);

            }

        }
    }
}
