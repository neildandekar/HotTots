using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotTots
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class studentPage : ContentPage
    {
        private thsNamesDb _database;
        private ListView _studentList;
        public studentPage()
        {
            _database = new thsNamesDb();
            Title = "Student List";
            var names = _database.GetStudents();
            _studentList = new ListView();
            _studentList.ItemsSource = names;
            _studentList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _studentList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _studentList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Designation");

            Content = _studentList;
            InitializeComponent();
        }
        public void Refresh()
        {
            _studentList.ItemsSource = _database.GetStudents();
        }
    }
}