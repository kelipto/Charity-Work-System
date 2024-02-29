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
using System.Windows.Shapes;

namespace CharityWorkSystem
{
    /// <summary>
    /// Interaction logic for VacantDetails.xaml
    /// </summary>
    public partial class VacantDetails : Window
    {
        public VacantDetails(Vacant v)
        {
            InitializeComponent();

            lblName.Content = v.Title;
            lblField.Content = v.Field;
            lblDate.Content = v.StartDate;
            lblSalary.Content = v.Salary;
            lblQualification.Content = v.Qualification;
            lblExperience.Content = v.Experience;


            lblDriving.Content = v.Driving;
            if (v.Driving == true)
            {
                lblDriving.Content = "Yes";
            }
            else
            {
                lblDriving.Content = "No";
            }


            lblCriminal.Content = v.Criminal;
            if (v.Criminal == true)
            {
                lblCriminal.Content = "Yes";
            }
            else
            {
                lblCriminal.Content = "No";
            }
        }
    }
}
