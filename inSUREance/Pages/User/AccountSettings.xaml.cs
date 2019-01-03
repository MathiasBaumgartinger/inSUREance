using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using inSUREance.Classes;
using System.ComponentModel;
using System.Runtime.CompilerServices;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountSettings : INotifyPropertyChanged
    {
        string name;
        string date;
        string address;

        public string NameDisplay { get { return name; } set { name = value; OnPropertyChanged(); } }
        public string Date { get { return date; } set { date = value; OnPropertyChanged(); } }
        public string Address { get { return address; } set { address = value; OnPropertyChanged(); } }

        public AccountSettings()
        {
            this.InitializeComponent();
            this.DataContext = this;

            // Get Data
            NameDisplay = GlobalVariables.User.Name;
            Date = GlobalVariables.User.Birthday.ToString();
            Address = GlobalVariables.User.Address;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button clicked user: " + name + " updated!");

            GlobalVariables.User.Name = UsernameBox.Text;
            string date = BirthdayBox.Text;
            try
            {
                GlobalVariables.User.Birthday = Convert.ToDateTime(date);
            }
            catch(InvalidDataException exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.StackTrace);
            }
            GlobalVariables.User.Address = AddressBox.Text;
            
            // TODO: Update database

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChooseOption));
        }
    }
}
