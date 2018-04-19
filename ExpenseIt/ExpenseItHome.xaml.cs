using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace ExpenseIt
{
    public partial class ExpenseItHome : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime lastChecked;

        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                    lastChecked = value;
                }
            }
        }

        public ExpenseItHome()
        {
            this.LastChecked = DateTime.Now;
            this.DataContext = this;

            InitializeComponent();
        }

        private void GreetingByName_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi, " + greetingMsg);
        }

        private void ViewInfo_Click(object sender, RoutedEventArgs e)
        {
            // ExpenseReportPage expenseReportPage = new ExpenseReportPage();
            // this.NavigationService.Navigate(expenseReportPage);

            ExpenseReportPage expenseReportPage = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(expenseReportPage);
        }

        private void peopleListBox_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            LastChecked = DateTime.Now; 
        }
    }
}
