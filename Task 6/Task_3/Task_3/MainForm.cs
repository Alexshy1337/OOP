using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using ClassLibrary;

namespace Task_3
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            Student = new HomeLearningStudent();

        }

        HomeLearningStudent Student;

        private void RndActionButton_Click(object sender, EventArgs e)
        {
            string[] a = { "School marks", "Recomendation", "Passport" }, s = { "Math", "Progs", "History" };
            Student.Documents = a;
            Student.Schedule = s;
            Student.Speciality = "Toilet cleaner";
            string b = "VSU";
            Random r = new Random();
            Student.CostOfEducation = r.Next(70000, 480000);
            Student.ExamQuantity = r.Next(1, 6);

            switch (r.Next(1, 10))
            {
                case 1:
                    {
                        if (Student.AttendToUniversity(Student.Documents, b))
                            label2.Text = "Successfully attended to " + b;
                        else
                            label2.Text = "Failed to attend to " + b;
                        label1.Text = "";
                        label3.Text = "";
                        break;
                    }
                case 2:
                    {
                        label2.Text = "";
                        label1.Text = "Student's cost of education is " + Student.CostOfEducation.ToString();
                        label3.Text = "";
                        break;
                    }
                case 3:
                    {

                        label3.Text = "";
                        label1.Text = "";
                        label2.Text = "Student's docs are weird: ";
                        for (int i = 0; i < Student.Documents.Length - 1; i++)
                            label2.Text += Student.Documents[i] + ", ";
                        label2.Text += Student.Documents[Student.Documents.Length - 1];
                        break;
                    }
                case 4:
                    {
                        label2.Text = "";
                        label1.Text = "";
                        label3.Text = "Amount of exams: " + Student.ExamQuantity.ToString();
                        break;
                    }
                case 5:
                    {

                        label2.Text = "";
                        label1.Text = "";
                        label3.Text = "Internal exam result: " + Student.PassInternalExam();
                        break;
                    }
                case 6:
                    {
                        label2.Text = "Session exam result: ";
                        if (Student.PassSessionExams())
                            label2.Text += "success";
                        else
                            label2.Text += "fail";
                        label1.Text = "";
                        label3.Text = "";
                        break;
                    }
                case 7:
                    {
                        label2.Text = "Monday schedule: ";
                        for (int i = 0; i < Student.Schedule.Length - 1; i++)
                            label2.Text += Student.Schedule[i] + ", ";
                        label2.Text += Student.Schedule[Student.Schedule.Length - 1];
                        label1.Text = "";
                        label3.Text = "";
                        break;
                    }
                case 8:
                    {
                        Student.Scholarship = 0;
                        label2.Text = "";
                        label1.Text = "";
                        label3.Text = "Scholarship = " + Student.Scholarship.ToString() + " (it's a home-learning student)";
                        break;
                    }
                case 9:
                    {
                        label2.Text = "";
                        label1.Text = "Speciality is " + Student.Speciality;
                        label3.Text = "";
                        break;
                    }
                case 10:
                    {
                        string[] coursework = Student.WriteCoursework();
                        label2.Text = "result: ";
                        for (int i = 0; i < coursework.Length - 1; i++)
                            label2.Text += coursework[i] + " and ";
                        label2.Text += coursework[coursework.Length - 1];
                        label1.Text = "Writing course work...";
                        label3.Text = "";
                        break;
                    }
                default:
                    {
                        label2.Text = "";
                        label1.Text = "";
                        label3.Text = "something's wrong";
                        break;
                    }
            }
        }
    }
}



