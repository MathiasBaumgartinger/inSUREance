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
using inSUREance.Pages;
using inSUREance.Pages.User;
using inSUREance.Classes;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace inSUREance
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = userInput.Text;
            string password = pwInput.Text;

            // TODO: Database stuff
            if (username.Equals("user") && password.Equals("pw"))
            {
                GlobalVariables.User.Name = username;
                GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                GlobalVariables.User.Address = "1150 Wien";

                this.Frame.Navigate(typeof(ChooseOption));
            }
            else if (username.Equals("admin") && password.Equals("pw"))
            {
                //this.Frame
            }
            else if (username.Equals("provider") && password.Equals("pw"))
            {

            }
            else if (username.Equals("adviser") && password.Equals("pw"))
            {

            }
            else
            {
                allertMessage.Text = "Wrong Username or Password";
            }

        }
    }
}
