using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChooseOption : Page
    {
        public ChooseOption()
        {
            this.InitializeComponent();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            StackPanel clickedItem = (StackPanel)e.ClickedItem;
            if(clickedItem.Tag != null)
            {
                if (clickedItem.Tag.ToString() == "InsuranceOverview")
                {
                    this.Frame.Navigate(typeof(InsuranceOverview));
                }
                if (clickedItem.Tag.ToString() == "AccountSettings")
                {
                    this.Frame.Navigate(typeof(AccountSettings));
                }
                if (clickedItem.Tag.ToString() == "Questions")
                {
                    this.Frame.Navigate(typeof(Questions));
                }
                if (clickedItem.Tag.ToString() == "Rating")
                {
                   // this.Frame.Navigate(typeof(AccountSettings));
                }
            } 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
