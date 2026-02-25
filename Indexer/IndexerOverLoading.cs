

using System.Collections.Generic;

namespace master_csharp.App.Indexer
{
    class Student
    {
        private Dictionary<string, int> grades = new Dictionary<string, int>();

        public int this[string subject]
        {
            get { return grades[subject]; }
            set { grades[subject] = value; }
        }
    }
}
