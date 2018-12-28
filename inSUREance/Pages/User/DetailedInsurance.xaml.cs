using inSUREance.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static inSUREance.Classes.Insurance;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailedInsurance : Page
    {
        public List<Insurance> displayInsurance = new List<Insurance>();

        public DetailedInsurance()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Insurance newInsurance = (Insurance)e.Parameter;
            Debug.WriteLine(newInsurance.Name);
            displayInsurance.Add(newInsurance);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InsuranceOverview));
        }
    }   
}
