using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Programming_Language_2_Task_1
{
    public partial class Form2 : Form
    {

        public Student ivica;
        public Form2(Student gradingStudent) 
        {
            InitializeComponent();
            ivica = gradingStudent;
            Console.WriteLine(ivica.firstName);
            fName.Text = gradingStudent.firstName;
            lName.Text = gradingStudent.lastName;
            foreach(Course a in gradingStudent.courseList)
            {
                lesson.Items.Add(a.Name);
            }
            
            
        }

        private void ok_Click(object sender, EventArgs e)
        {
            string currentCourse = lesson.SelectedItem.ToString();
            foreach (Course a in ivica.courseList)
            {
                if (a.Name == currentCourse)
                {
                    a.MidtermScore = Convert.ToDouble(midterm.Text);
                    a.FinalScore = Convert.ToDouble(final.Text);
                    average.Text = Convert.ToString(a.AverageScore);
                    Console.WriteLine(a.AverageScore + "," + a.MidtermScore);
                }
            }

        }

        private void lesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentCourse = lesson.SelectedItem.ToString();
            foreach(Course a in ivica.courseList)
            {
                if(a.Name == currentCourse)
                {
                    if(Convert.ToString(a.MidtermScore) == "0")
                    {
                        midterm.Text = "-1";
                    }
                    else
                    {
                        midterm.Text = Convert.ToString(a.MidtermScore);
                    }
                    if (Convert.ToString(a.FinalScore) == "0")
                    {
                        final.Text = "-1";
                    }
                    else
                    {
                        final.Text = Convert.ToString(a.FinalScore);
                    }
                    if(midterm.Text == "-1" || final.Text == "-1")
                    {
                        average.Text = "-1";
                        
                    }
                    else
                    {
                        
                        average.Text = Convert.ToString(a.AverageScore);
                    }

                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
