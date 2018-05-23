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
    /// <summary>
    /// Interaction logic for Specializations.xaml
    /// </summary>
    public partial class SpecializationsPage : Page
    {
        public SpecializationsPage()
        {
            InitializeComponent();

            GetSpecializations();
        }

        private void GetSpecializations()
        {
            StudentInfoContext context = new StudentInfoContext();

            List<Specialization> specializations = context.Specializations.ToList();

            foreach (Specialization specialization in specializations)
            {
                this.specializationsList.Items.Add(specialization.Description);
            }
        }
    }
}
