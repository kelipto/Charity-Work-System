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
    /// Interaction logic for ClientsDetail.xaml
    /// </summary>
    public partial class ClientsDetail : Window
    {
        public ClientsDetail(Client c)
        {
            InitializeComponent();
            lblName.Content = c.Name;
            lblAddress.Content = c.Address;
            lblEmail.Content = c.Email;
            lblField.Content = c.Status;
            lblRecords.Content = c.Criminal;
            if (c.Criminal == true)
            {
                lblRecords.Content = "Yes";
            }
            else
            {
                lblRecords.Content = "No";
            }


            lblLicense.Content = c.Driving;
            if (c.Driving == true)
            {
                lblLicense.Content = "Yes";
            }
            else
            {
                lblLicense.Content = "No";
            }



        }
    }
}
