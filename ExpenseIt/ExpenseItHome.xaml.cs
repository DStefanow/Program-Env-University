using System;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Page
    {
        public DateTime LastChecked { get; set; }

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
    }
}
