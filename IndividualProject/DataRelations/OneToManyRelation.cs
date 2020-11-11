using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.DataRelations
{
    class OneToManyRelation
    {
        private protected List<int> _relationIDs; // Position of relation in the main List<>

        

        public List<int> RelationID
        {
            get { return this._relationIDs; }
            private set { }
        }


        public OneToManyRelation()
        {
            this._relationIDs = new List<int>();
        }

        //public void AddRelationToCourse(int iD)
        //{

        //    if (this._relationIDs.Contains(iD)) Console.WriteLine("Already added in this course");
        //    else
        //    {
        //        this._relationIDs.Add(iD);
        //        this.RelationID.Sort();
                
        //    }

        //}

    }
}
