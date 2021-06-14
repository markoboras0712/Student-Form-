using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_2_Task_1
{
    public class Course
    {
        private string name;
        private double midtermScore;
        private double finalScore;

        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double MidtermScore
        {
            get
            {
                return midtermScore;
            }
            set
            {
                midtermScore = value;
            }
        }

        public double FinalScore
        {
            get
            {
                return finalScore;
            }
            set
            {
                finalScore = value;
            }
        }


        public double AverageScore
        {
            get
            {
                return ((midtermScore + finalScore) / 2);
            }
        }




    }
}
