using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace CharityWorkSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Our students and programme lists
        List<Organisation> OrganisationList = new List<Organisation>();
        List<Client> ClientList = new List<Client>();
        List<Vacant> VacantList = new List<Vacant>();

        // Private method to generate sample programme and modules
        private void createListProgramme()
        {
            OrganisationList.Clear();
            Organisation o1 = new Organisation("The Brick Break");
            Organisation o2 = new Organisation("Green Go");
            Organisation o3 = new Organisation("Easy Linen");
            Organisation o4 = new Organisation("House of Cards");


            OrganisationList.Add(o1);
            OrganisationList.Add(o2);
            OrganisationList.Add(o3);
            OrganisationList.Add(o4);


            //module (vacant name, type, date, hourly pay, qualification)
            Vacant v1 = new Vacant("Driver", "Deliver", "22/08/2022", "7.25", "Happy", "Yes");
            Vacant v2 = new Vacant("Kitchen Porter", "Kitchen", "01/12/2022", "8.00", "None", "No");
            Vacant v3 = new Vacant("Gardener", "Gardening", "04/06/2032", "9.15", "Driving License, Eye to a Detail, Good communication Skills", "Yes");
            Vacant v4 = new Vacant("Brickler", "Constrution", "15/08/2043", "4.50", "Eye for a detail, Healthy, Good Communication Skills", "No");
            Vacant v5 = new Vacant("Junior Painter", "Construction", "18/06/2024", "8.70", "Eye for a detail, steady hand", "Yes");
            Vacant v6 = new Vacant("Delivery Driver", "Delivery", "10/08/2022", "5.55", "Driving License, No criminal records", "Yes");
            Vacant v7 = new Vacant("Taxi Driver", "Driver", "04/08/2022", "10.50", "Driving License, No criminal records, perfect english, Healthy", "No");
            Vacant v8 = new Vacant("Shop Assistance", "Retail", "31/08/2032", "11.00", "None", "No");
            Vacant v9 = new Vacant("Housekeeper", "Accomodation", "31/08/2032", "11.00", "None", "Yes");

            o1.AddVacant(v1);
            o1.AddVacant(v4);
            o1.AddVacant(v5);

            o2.AddVacant(v3);
            o2.AddVacant(v6);

            o2.AddVacant(v2);
            o2.AddVacant(v8);

            o3.AddVacant(v9);
            o3.AddVacant(v3);

            o4.AddVacant(v7);


            Client s1 = new Client("Kamil Lipski", "140 Dinmont, Edinburgh", "kamil@mail.com", "Cleaning");
            Client s2 = new Client("Josh Josh", "10 Dinmont, Edinburgh", "josh@mail.com", "Construction");
            Client s3 = new Client("Bob Bobski", "40 Dinmont, Edinburgh", "bob@mail.com", "Gardening");
            Client s4 = new Client("Ace Ventura", "160 Dinmont, Edinburgh", "ace@mail.com", "Kitchen");
            Client s5 = new Client("Bruce Wayne", "1 Dinmont, Edinburgh", "brucy@mail.com", "Cleaning");
            Client s6 = new Client("Alfred Fred", "12 Dinmont, Edinburgh", "fred@mail.com", "Driver");
            Client s7 = new Client("Jimmy Jey", "164 Dinmont, Edinburgh", "jim@mail.com", "Construction");


            ClientList.Add(s1);
            ClientList.Add(s2);
            ClientList.Add(s3);
            ClientList.Add(s4);
            ClientList.Add(s5);
            ClientList.Add(s6);
            ClientList.Add(s7);





            lstOrganisations.ItemsSource = OrganisationList;
            lstClients.ItemsSource = ClientList;
        }

        // public main method
        // launches the main window
        public MainWindow()
        {
            InitializeComponent();
            createListProgramme();
        }

        // method to create a new vacant on click
        private void newVacant(object sender, RoutedEventArgs e)
        {
            Organisation o = lstOrganisations.SelectedItem as Organisation;
            Vacant v = new Vacant(boxVacantTitle.Text, boxField.Text, boxStartDate.Text, boxSalary.Text, boxQualification.Text, boxExperience.Text);
            boxVacantTitle.Clear();
            boxField.Clear();
            boxStartDate.Clear();
            boxSalary.Clear();
            boxQualification.Clear();
            boxExperience.Clear();



            if (btnDriving.IsChecked == true)
            {
                v.Driving = true;
            }
            else
            {
                v.Driving = false;
            }
            if (btnCriminal.IsChecked == true)
            {
                v.Criminal = true;
            }
            else
            {
                v.Criminal = false;
            }

            if (v != null)
            {
                o.AddVacant(v);
                lstVacants.ItemsSource = null;
                lstVacants.ItemsSource = o.Vacants;
            }
        }


        // method to show information connected to specific client like vacant for interview and date&time for this interview
        private void clientSelected(object sender, SelectionChangedEventArgs e)
        {
            Client c = lstClients.SelectedItem as Client;
            if (c != null && c.Recorded)
            {
                Organisation o = c.Organisation;
                lstOrganisations.SelectedItem = o;

                lstClientInterviews.ItemsSource = c.Vacants;
                lstDateTime.ItemsSource = c.Interviews;
            }
        }

        // method to display organisation available vacancies 
        private void organisationSelected(object sender, SelectionChangedEventArgs e)
        {
            Organisation o = lstOrganisations.SelectedItem as Organisation;
            if (o != null)
            {
                lstVacants.ItemsSource = o.Vacants;
                lblAvOrganisation.Content = o.ID + " | Vacancies";
            }
        }


        // method to assing selected client to specific organisation after their sucessful interview
        //instead of keeping their names at the end of organisation spreadsheet
        private void assign(object sender, RoutedEventArgs e)
        {
            Organisation o = lstOrganisations.SelectedItem as Organisation;
            Client c = lstClients.SelectedItem as Client;

            if (o != null && c != null)
            {
                c.Assign(o);
            }
            lstClients.ItemsSource = null;
            lstClients.ItemsSource = ClientList;
        }

        // method to add selected vacant to the list of client interviews
        private void addInterview(object sender, RoutedEventArgs e)
        {
            Client c = lstClients.SelectedItem as Client;
            Vacant v = lstVacants.SelectedItem as Vacant;

            if (v != null && c != null)
            {
                c.AddVacant(v);
                lstClientInterviews.ItemsSource = null;
                lstClientInterviews.ItemsSource = c.Vacants;

            }
        }

        // method to add date and time for specific client interview
        private void addDateTime(object sender, RoutedEventArgs e)
        {
            Client c = lstClients.SelectedItem as Client;
            Vacant v = lstClientInterviews.SelectedItem as Vacant;
            DateTime dt = Convert.ToDateTime(boxDateTime.Text);
            Organisation o = lstOrganisations.SelectedItem as Organisation;


            if (v != null && c != null && o != null)
            {
                c.AddInterview(v, dt, o);
                lstDateTime.ItemsSource = null;
                lstDateTime.ItemsSource = c.Interviews;
            }
            else if (o == null)
            {
                MessageBox.Show("If you have not selected the organisation\nPlease select correct organisation \n" + lblAvOrganisation.Content);
            }


        }

        // method to show details of selected client
        private void showClientDetails(object sender, RoutedEventArgs e)
        {
            Client c = lstClients.SelectedItem as Client;
            if (c != null)
            {
                ClientsDetail w = new ClientsDetail(c);
                w.Show();
            }
        }

        // method to show details of selected vacant
        private void showVacantDetails(object sender, RoutedEventArgs e)
        {
            Vacant v = lstVacants.SelectedItem as Vacant;
            if (v != null)
            {
                VacantDetails w = new VacantDetails(v);
                w.Show();
            }
        }
        //method to remove vacant
        private void RemoveVacant(object sender, RoutedEventArgs e)
        {
            Vacant v = lstVacants.SelectedItem as Vacant;
            Organisation o = lstOrganisations.SelectedItem as Organisation;

            if (v != null && o != null)
            {

                o.RemoveVacant(v);
                lstVacants.ItemsSource = null;
                lstVacants.ItemsSource = o.Vacants;



            }

        }
    }
}

