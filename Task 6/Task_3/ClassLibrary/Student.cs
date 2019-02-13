using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Student : IAbiturient
    {
        public string[] Documents { get; set; }
        public int Scholarship { get; set; }
        public string[] Schedule { get; set; }
        public string Speciality { get; set; }

        public abstract bool AttendToUniversity(string[] Docs, string UnivName);
        public abstract int PassInternalExam();
        public abstract string WasteTime(string action);


        public bool ToBribe(int Summ)
        {
            Random r = new Random();
            if (r.Next() > 50)
                return true;
            else return false;
        }
    }
}
