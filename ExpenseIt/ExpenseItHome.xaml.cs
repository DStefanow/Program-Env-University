using System.Windows;
using System.Windows.Controls;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();

            // Add people from the code
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void GreetingByName_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi, " + greetingMsg);
        }

        private void ViewInfo_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReportPage expenseReportPage = new ExpenseReportPage();
            this.NavigationService.Navigate(expenseReportPage);
        }
    }
}
