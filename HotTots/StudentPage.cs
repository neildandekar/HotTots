using Xamarin.Forms;
using HotTots;

namespace HotTots.Droid
{
    class StudentPage : ContentPage
    {
        private thsNamesDb _database;
        private ListView _studentList;

        public StudentPage()
        {
            _database = new thsNamesDb();
            Title = "Student List";
            var names = _database.GetStudents();
            _studentList = new ListView();
            _studentList.ItemsSource = names ;
            _studentList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _studentList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _studentList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Designation");

            Content = _studentList;
        }
        public void Refresh()
        {
            _studentList.ItemsSource = _database.GetStudents();
        }
    }
}
