using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming_Language_2_Task_1
{
    public enum Gender : byte
    {
        Male,
        Female
    }
    public enum Area : byte
    {
        Formal,
        Informal,
        Nonformal,
    }
    public class Student
    {
        public string firstName;
        public string lastName;
        public int itsNumber;
        public DateTime dateOfBirth;
        public DateTime dateOfRegister;
        public int studentClass;
        public Gender gender;
        public Area area;
        public List<Course> courseList;

       
        

        public enum MaritalStatus : byte
        {
            Single,
            Married,
            Divorced,
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public int ItsNumber
        {
            get
            {
                return itsNumber;
            }
            set
            {
                itsNumber = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public DateTime DateOfRegister
        {
            get
            {
                return dateOfRegister;
            }
            set
            {
                dateOfRegister = value;
            }
        }

        public int StudentClass
        {
            get
            {
                return studentClass;
            }
            set
            {
                studentClass = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public Area Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }

        public List<Course> CourseList
        {
            get
            {
                return courseList;
            }
            set
            {
                courseList = value;
            }
        }

        public Student(string name, string surname, int number)
        {
            firstName = name;
            lastName = surname;
            itsNumber = number;
            courseList = new List<Course>();
        }

        public Student( )
        {
            
        }

        

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;
                return age;
            }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public void AddLecture(string lectureName)
        {
            Course newCourse = new Course();
            newCourse.Name = lectureName;
            courseList.Add(newCourse);
        }



    }
}
