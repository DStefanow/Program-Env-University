using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    public partial class SpecializationsPage : Page
    {
        private StudentInfoContext context = new StudentInfoContext();

        public SpecializationsPage()
        {
            InitializeComponent();

            GetSpecializations();
        }

        private void GetSpecializations()
        {
            List<Specialization> specializations = context.Specializations.ToList();

            foreach (Specialization specialization in specializations)
            {
                this.specializationsList.Items.Add(specialization.Description);
            }
        }
        public void clearListBox()
        {
            this.specializationsList.Items.Clear();
        }
        
        private void getSpecialization_Click(object sender, RoutedEventArgs e)
        {
            string specializationText = this.specializationBox.Text;
            
            int specializationId = int.Parse(specializationText);

            clearListBox();

            if (specializationId == 0)
            {
                GetSpecializations();
                return;
            }

            Specialization specialization = null;
            try
            {
                specialization = (from spec in context.Specializations
                                  where spec.SpecializationId == specializationId
                                  select spec).First();

                this.specializationsList.Items.Add(specialization.Description);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void addSpecialization_Click(object sender, RoutedEventArgs e)
        {
            string specializationText = this.specializationBox.Text;
            
            clearListBox();

            if (specializationText == "")
            {
                GetSpecializations();
                return;
            }

            Specialization newSpec = new Specialization(specializationText);

            context.Specializations.Add(newSpec);
            context.SaveChanges();

            this.specializationBox.Clear();
            clearListBox();
            GetSpecializations();
        }
    }
}
