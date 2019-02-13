using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class HomeLearningStudent : Student
    {
        public int CostOfEducation { get; set; }
        public int ExamQuantity { get; set; }


        public override bool AttendToUniversity(string[] Docs, string UnivName)
        {
            Random r = new Random();
            if (r.Next(1, 100) > 50)
                return true;
            return false;
        }

        public override int PassInternalExam()
        {
            Random r = new Random();
            return r.Next(2, 99);
        }

        public bool PassSessionExams()
        {
            Random r = new Random();
            if (r.Next(0, 1) == 1)
                return true;
            return false;

        }

        public override string WasteTime(string action)
        {
            switch (action)
            {
                case "Eat pizza":
                    return "Your Heavy Armour increased";
                case "Play CSGO":
                    return "Your One Handed increased";
                case "Play Super Meat Boy":
                    return "Your Ass Destruction Magic increased";
                case "Sleep":
                    return "Your Health and Stamina replenished";
                case "Get food from the store":
                    return "Your Agility increased";
                default:
                    return "You achieve nothing";
            }
        }

        public string[] WriteCoursework()
        {
            string[] Coursework = { "ice","water","water steam" };
            return Coursework;
        }
    }
}
