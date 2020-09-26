using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HotTots
{
    class StudentNames : ContentPage
    {
        private thsNamesDb _database;
        private ListView _nameList;

        public StudentNames(thsNamesDb database)
        {
            _database = database;
            Title = "Students";
            var names = _database.GetStudents();

            _nameList = new ListView();
            _nameList.ItemsSource = names;
            _nameList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _nameList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _nameList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Designation");

            Content = _nameList;
        }
        public void Refresh()
        {
            _nameList.ItemsSource = _database.GetStudents();
        }
    }
}
