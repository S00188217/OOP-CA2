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
using System.Collections.ObjectModel;
using System.IO;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Declaration of cost variable

        decimal total = 0;

        // Declaration of lists

        ObservableCollection<Activities> AllActivities;
        ObservableCollection<Activities> CertainActivities = new ObservableCollection<Activities>();
        ObservableCollection<Activities> FilteredActivities = new ObservableCollection<Activities>();
        public MainWindow()
        {
            InitializeComponent();

            //Declaration of Activities
            Activities a = new Activities("Kayaking", 100, Activities.ActivityType.Water, "Floating down the stream", new DateTime(2019, 11, 30));
            Activities b = new Activities("Treking", 100, Activities.ActivityType.Land, "A walk through the woods", new DateTime(2019, 11, 25));
            Activities c = new Activities("Surfing", 100, Activities.ActivityType.Water, "Riding the waves", new DateTime(2019, 12, 04));
            Activities d = new Activities("Parachuting", 100, Activities.ActivityType.Air, "Hang on tight", new DateTime(2019, 12, 07));
            Activities z = new Activities("Mountain Biking", 100, Activities.ActivityType.Land, "Riding up the mountain on our bikes", new DateTime(2019, 12, 12));
            Activities f = new Activities("Hang Gliding", 100, Activities.ActivityType.Air, "Across the beautiful views of the valley", new DateTime(2019, 12, 18));
            Activities g = new Activities("Abseiling", 100, Activities.ActivityType.Land, "I hope nobody is afraid of heights", new DateTime(2019, 12, 22));
            Activities h = new Activities("Sailing", 100, Activities.ActivityType.Water, "A nice and peaceful sport", new DateTime(2019, 12, 23));
            Activities i = new Activities("Helicopter Tour", 100, Activities.ActivityType.Air, "Up, up and away", new DateTime(2020, 01, 02));
            AllActivities = new ObservableCollection<Activities>();

            // Adding activities to listbox1 and removing them from listbox2

            AllActivities.Add(a);
            AllActivities.Add(b);
            AllActivities.Add(c);
            AllActivities.Add(d);
            AllActivities.Add(z);
            AllActivities.Add(f);
            AllActivities.Add(g);
            AllActivities.Add(h);
            AllActivities.Add(i);

            listbox1.ItemsSource = AllActivities;
            listbox2.ItemsSource = CertainActivities;

            listbox1.ItemsSource = AllActivities.OrderBy(act => act.Date);
        }

        /*private void Radio_All_Click(object sender, RoutedEventArgs e)
        {
            listbox1.ItemsSource = AllActivities;

        }*/

        /*private void Radio_Water_Click(object sender, RoutedEventArgs e)
        {
            FilteredActivities.Clear();
            Activities.ActivityType water = 0;
            foreach (var item in AllActivities)
            {
                water = item._ActivityType;
                if (water == Activities.ActivityType.Water)
                {
                    FilteredActivities.Add(item);
                }
                listbox1.ItemsSource = FilteredActivities;
            }
        }*/

        /*private void Radio_Air_Click(object sender, RoutedEventArgs e)
        {
            FilteredActivities.Clear();
            Activities.ActivityType air = 0;
            foreach (var item in AllActivities)
            {
                air = item._ActivityType;
                if (air == Activities.ActivityType.Air)
                {
                    FilteredActivities.Add(item);
                }
                listbox1.ItemsSource = FilteredActivities;
            }
        }*/

            // Removing items from listbox2

        private void Btn_unselectchosen_Click(object sender, RoutedEventArgs e)
        {

            Activities ChosenActivity = listbox2.SelectedItem as Activities;

            if (ChosenActivity != null)
            {
                CertainActivities.Remove(ChosenActivity);
                AllActivities.Add(ChosenActivity);
            }

            // Subtracts the total cost when an item is removed from listbox2

            total = total - ChosenActivity.Cost;
            cost.Text = total.ToString();
        }

        // Adding items to listbox2 and removing them from listbox1

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            listbox1.ItemsSource = AllActivities;

            bool interfere = false;
            Activities ChosenActivity = listbox1.SelectedItem as Activities;
            foreach (Activities activities in CertainActivities)
            {
                if (activities.Date == ChosenActivity.Date)
                {
                    interfere = true;
                    MessageBox.Show("You already have a full schedule for that day");
                }
            }
            if (interfere == false)
            {
                CertainActivities.Add(ChosenActivity);
                AllActivities.Remove(ChosenActivity);
            }

            if (Radio_All.IsChecked == true)
            {
                listbox1.ItemsSource = AllActivities;
            }
            else if (Radio_Land.IsChecked == true)
            {
                FilteredActivities.Clear();

                foreach (Activities act in AllActivities)
                {
                    if (act._ActivityType == Activities.ActivityType.Land)
                        FilteredActivities.Add(act);
                }

                listbox1.ItemsSource = FilteredActivities;
            }

            else if (Radio_Water.IsChecked == true)
            {
                FilteredActivities.Clear();

                foreach (Activities act in AllActivities)
                {
                    if (act._ActivityType == Activities.ActivityType.Water)
                        FilteredActivities.Add(act);
                }

                listbox1.ItemsSource = FilteredActivities;

            }

            else if (Radio_Air.IsChecked == true)
            {
                FilteredActivities.Clear();

                foreach (Activities act in AllActivities)
                {
                    if (act._ActivityType == Activities.ActivityType.Air)
                        FilteredActivities.Add(act);
                }

                listbox1.ItemsSource = FilteredActivities;
            }

            // Adds the total cost when items are added to listbox2

            total = total + ChosenActivity.Cost;
            cost.Text = total.ToString();

        }

        // Selects all the activities

        private void Radio_All_Click_1(object sender, RoutedEventArgs e)
        {
            listbox1.ItemsSource = AllActivities;
        }

        // Selects any activities that are land based

        private void Radio_Land_Click(object sender, RoutedEventArgs e)
        {
            FilteredActivities.Clear();
            Activities.ActivityType land = 0;
            foreach (var item in AllActivities)
            {
                land = item._ActivityType;
                if (land == Activities.ActivityType.Land)
                {
                    FilteredActivities.Add(item);
                }
                listbox1.ItemsSource = FilteredActivities;
            }
        }

        // Selects any activities that are water based

        private void Radio_Water_Click(object sender, RoutedEventArgs e)
        {
            FilteredActivities.Clear();
            Activities.ActivityType water = 0;
            foreach (var item in AllActivities)
            {
                water = item._ActivityType;
                if (water == Activities.ActivityType.Water)
                {
                    FilteredActivities.Add(item);
                }
                listbox1.ItemsSource = FilteredActivities;
            }
        }

        // Selects any activities that are air based

        private void Radio_Air_Click(object sender, RoutedEventArgs e)
        {
            FilteredActivities.Clear();
            Activities.ActivityType air = 0;
            foreach (var item in AllActivities)
            {
                air = item._ActivityType;
                if (air == Activities.ActivityType.Air)
                {
                    FilteredActivities.Add(item);
                }
                listbox1.ItemsSource = FilteredActivities;
            }
        }

        /*private void Listbox1_MouseMove(object sender, MouseEventArgs e)
        {
            Activities ChosenActivity = listbox1.SelectedItem as Activities;
            foreach (Activities activities in CertainActivities)
            {
                if (activities.Date == ChosenActivity.Date)
                {
                   // Description_Box
                }
            }
        }*/

        private void Description_Box_MouseMove(object sender, MouseEventArgs e)
        {

        }

            // Description Box

        private void Listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activities ChosenActivity = listbox1.SelectedItem as Activities;


            if (ChosenActivity != null)
            {
                Description_Box.Text = ChosenActivity.Description;
            }


        }

        /*try
        {
            using (StreamReader sr = File.OpenText(""))
            {
                Console.WriteLine("");
            }
}
        catch (Exception e)
        {
            Console.WriteLine("");
        }*/



    }
}

