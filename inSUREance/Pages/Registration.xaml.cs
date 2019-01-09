using inSUREance.db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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

namespace inSUREance.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {
        string username;
        string password;
        DateTime birthday;
        string residence;
                
        public Registration()
        {
            this.InitializeComponent();
        }

        // TODO: Update database
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            username = UsernameBox.Text;
            password = pwBox.Password;
            birthday = DateBox.Date.Date;
            residence = AddressBox.Text;

            using (var db = new InsuranceDataBaseAccess(GlobalVariables.DATABASE.SERVERNAME,
                GlobalVariables.DATABASE.USERNAME, GlobalVariables.DATABASE.PASSWORD))
            {
                if(db.Open())
                {
                    IPreparedStatement stmt = new CreateUserStatement(username, password, birthday, residence);
                    stmt.Prepare(db.connection);

                    db.ExecutePreparedStatementNonQuery(stmt);
                }
                else
                {

                }
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
