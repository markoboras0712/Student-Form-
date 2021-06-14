using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Programming_Language_2_Task_1
{
    public partial class Form1 : Form
    {
        List<Student> newList = new List<Student>();

       
        public Form1()
        {
            InitializeComponent();
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            
            
            area.DataSource = Enum.GetValues(typeof(Area));
            

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            
            for(int i = 0; i < firstName.Text.Length; i++)
            {
                if (!char.IsLetter(firstName.Text[i]))
                {
                    MessageBox.Show("You must enter only letters for first name");
                    return;
                }
            }
            for (int i = 0; i < lastName.Text.Length; i++)
            {
                if (!char.IsLetter(lastName.Text[i]))
                {
                    MessageBox.Show("You must enter only letters for last name");
                    return;
                }
            }
            for (int i = 0; i < itsNumber.Text.Length; i++)
            {
                if (!char.IsDigit(itsNumber.Text[i]))
                {
                    MessageBox.Show("You must enter only numbers for its number");
                    return;
                }
            }
            if (String.IsNullOrEmpty(firstName.Text) || String.IsNullOrEmpty(lastName.Text) || String.IsNullOrEmpty(itsNumber.Text) || dateTimePicker1.Text.Length == 0 || dateTimePicker2.Text.Length == 0 || classNumber.Value == 0 || (!male.Checked == null && !female.Checked == null) || area.SelectedIndex == -1 )
            {
                MessageBox.Show("Please select all values");
                return;
            }
            else
            {
                //MessageBox.Show(firstName.Text + "," + lastName.Text + "," + Convert.ToInt32(itsNumber.Text) + "," + dateTimePicker1.Value + "," + Convert.ToInt32(classNumber.Value) + "," + Gender.Male + "," + Area.Formal);
                int number = int.Parse(itsNumber.Text);
                
                Student newStudent = new Student(firstName.Text, lastName.Text, number);
                
                newStudent.DateOfBirth = dateTimePicker1.Value;
                newStudent.DateOfRegister = dateTimePicker2.Value;
                newStudent.StudentClass = Convert.ToInt32(classNumber.Value);
                if (male.Checked)
                {
                    newStudent.Gender = Gender.Male;
                }
                else
                {
                    newStudent.Gender = Gender.Female;
                }
                if(area.SelectedItem.ToString() == "Formal")
                {
                    newStudent.Area = Area.Formal;
                }
                else if(area.SelectedItem.ToString() == "Informal")
                {
                    newStudent.Area = Area.Informal;
                }else
                {
                    newStudent.Area = Area.Nonformal;
                }
                newList.Add(newStudent);
                return;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            firstName.Text = "";
            lastName.Text = "";
            itsNumber.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            classNumber.Value = 0;
            male.Checked = false;
            female.Checked = false;
            area.SelectedIndex = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            foreach(Student i in newList)
            {
                if(studentList.Items.Contains(i.ToString()))
                {
                    continue;
                }else
                {
                   
                    studentList.Items.Add(i.ToString());
                }
                
            }
            
        }

        private void studentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(firstName.Text + "," + lastName.Text + "," + Convert.ToInt32(itsNumber.Text) + "," + dateTimePicker1.Value + "," + Convert.ToInt32(classNumber.Value) + "," + Gender.Male + "," + Area.Formal);
            string currentItem = studentList.SelectedItem.ToString();
            foreach(Student a in newList)
            {
                if(a.ToString() == currentItem)
                {
                    firstName.Text = a.firstName;
                    lastName.Text = a.lastName;
                    itsNumber.Text = Convert.ToString(a.itsNumber);
                    dateTimePicker1.Value = a.dateOfBirth;
                    dateTimePicker2.Value = a.dateOfRegister;
                    classNumber.Value = a.studentClass;
                    if(a.Gender == Gender.Male)
                    {
                        male.Checked = true;
                    }
                    else
                    {
                        female.Checked = true;
                    }
                    if(a.Area == Area.Formal)
                    {
                        area.SelectedIndex = 0;
                    }else if(a.Area == Area.Informal)
                    {
                        area.SelectedIndex = 1;
                    }else
                    {
                        area.SelectedIndex = 2;
                    }
                    int age = 0;
                    age = DateTime.Now.Year - a.dateOfBirth.Year;
                    studentAge.Text = Convert.ToString(age);

                }
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lessons = File.ReadAllLines("Lessons.txt");
            
            foreach(var line in lessons)
            {
                string[] lesson = line.Split(',');
               
                lessonsDropDown.Items.Add(lesson[0]);
                searchLessons.Items.Add(lesson[0]);
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentStudent = studentList.SelectedItem.ToString();
            string selectedLesson = lessonsDropDown.SelectedItem.ToString();
            foreach (Student a in newList)
            {
                if(a.ToString() == currentStudent)
                {
                    bool containsCourse = a.courseList.Any(item => item.Name == selectedLesson);
                    if (containsCourse)
                    {
                        Console.WriteLine("It exists already");
                        
                    }else
                    {
                        Console.WriteLine("Adding new course");
                        a.AddLecture(selectedLesson);
                        
                    }
                    foreach(Course x in a.courseList)
                    {
                        Console.WriteLine(x.Name);
                    }
                    
                    
                    
                }
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (studentList.SelectedItem == null)
            {
                MessageBox.Show("Select student");
            }else
            {
                string currentStudent = studentList.SelectedItem.ToString();

                foreach (Student a in newList)
                {
                    if (a.ToString() == currentStudent)
                    {
                        Form2 form2 = new Form2(a);



                        form2.Show();
                    }
                }

            }








        }

        private void button5_Click(object sender, EventArgs e)
        {
            studentList.Items.Clear();
            foreach(Student i in newList)
            {
                if(nameSearch.Text == i.ToString())
                {
                    studentList.Items.Add(i.ToString());
                }
            }
            MessageBox.Show("The transaction has completed sucesfully");
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            studentList.Items.Clear();
            string selectedLesson = searchLessons.SelectedItem.ToString();
            Console.WriteLine(selectedLesson);
            foreach (Student i in newList)
            {
                foreach(Course x in i.courseList)
                {
                    if(x.Name == selectedLesson)
                    {
                        studentList.Items.Add(i.ToString());
                    }
                }
            }
            MessageBox.Show("The transaction has completed sucesfully");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            studentList.Items.Clear();
            int selectedClass = Convert.ToInt32(studentClass.Value);
            foreach(Student i in newList)
            {
                if(i.StudentClass == selectedClass)
                {
                    studentList.Items.Add(i.ToString());
                }
            }
            MessageBox.Show("The transaction has completed sucesfully");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            studentList.Items.Clear();
            Gender gender;
            if (maleSearch.Checked)
            {
                gender = Gender.Male;
            }
            else
            {
                gender = Gender.Female;
            }
            foreach(Student i in newList)
            {
                if(i.Gender == gender)
                {
                    studentList.Items.Add(i.ToString());
                }
            }
            MessageBox.Show("The transaction has completed sucesfully");
        }
    }
}
