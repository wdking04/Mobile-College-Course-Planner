using C971.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssessment : ContentPage
    {
        public Course _course;
        public MainPage _main;
        public AddAssessment(Course course, MainPage main)
        {
            _course = course;
            _main = main;
            InitializeComponent();
        }

       

        async private void btnAddAssessment_Clicked(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                Assessment newAssessment = new Assessment();
                newAssessment.AssessmentName = txtAssessmentName.Text;
                newAssessment.AssessmentType = pickerAssessmentType.SelectedItem.ToString();
                newAssessment.End = dpDueDate.Date;
                newAssessment.Notifications = pickerNotifications.SelectedIndex;
                newAssessment.Course = _course.Id;

                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    var objectiveCount = con.Query<Assessment>($"SELECT * FROM Assessments WHERE Course = '{_course.Id}' AND AssessmentType = 'Objective'");
                    var performanceCount = con.Query<Assessment>($"SELECT * FROM Assessments WHERE Course = '{_course.Id}' AND AssessmentType = 'Performance'");
                    if (newAssessment.AssessmentType.ToString() == "Objective" && objectiveCount.Count == 0)
                    {
                        con.Insert(newAssessment);
                        _main.assessments.Add(newAssessment);
                        await Navigation.PopModalAsync();
                    }
                    else if (newAssessment.AssessmentType.ToString() == "Performance" && performanceCount.Count == 0)
                    {
                        con.Insert(newAssessment);
                        _main.assessments.Add(newAssessment);
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await Navigation.PushModalAsync(new AssessmentError());
                    }
                }
            }
            else
            {
                await Navigation.PushModalAsync(new InputError());
            }
        }

        private bool ValidateUserInput()
        {
            bool valid = true;

            if (txtAssessmentName == null ||
                pickerAssessmentType.SelectedItem == null ||
                dpDueDate.Date == null ||
                pickerNotifications.SelectedItem == null
                )

            {
                return false;


            }
            return valid;
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}