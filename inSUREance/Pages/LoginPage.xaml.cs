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
using inSUREance.db;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using inSUREance.Pages.Admin;
using inSUREance.Pages.Adviser;

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

#if USR_MATHIAS
            if (username.Equals("user") && password.Equals("pw"))
            {
                GlobalVariables.User.Name = username;
                GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                GlobalVariables.User.Address = "1150 Wien";

                this.Frame.Navigate(typeof(ChooseOption));
            }
            else if (username.Equals("admin") && password.Equals("pw"))
            {
                GlobalVariables.User.Name = username;
                GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                GlobalVariables.User.Address = "1150 Wien";

                this.Frame.Navigate(typeof(ChooseOptionAdm));
            }
            else if (username.Equals("provider") && password.Equals("pw"))
            {
                GlobalVariables.User.Name = username;
                GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                GlobalVariables.User.Address = "1150 Wien";

                this.Frame.Navigate(typeof(ChooseOption));
            }
            else if (username.Equals("adviser") && password.Equals("pw"))
            {
                GlobalVariables.User.Name = username;
                GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                GlobalVariables.User.Address = "1150 Wien";

                this.Frame.Navigate(typeof(ChooseOptionAdv));
            }
            else
            {
                allertMessage.Text = "Wrong Username or Password";
            }
#else
            using (var db = new InsuranceDataBaseAccess(GlobalVariables.DATABASE.SERVERNAME,
                GlobalVariables.DATABASE.USERNAME, GlobalVariables.DATABASE.PASSWORD))
            {
                if (db.Open())
                {
                    IPreparedStatement stmt = new LoginUserStatement(username, password);
                    stmt.Prepare(db.connection);

                    using (var reader = db.ExecutePreparedStatementReader(stmt))
                    {
                        if (reader != null && reader.HasRows && reader.FieldCount == 1)
                        {
                            reader.Read();
                            int usertype = reader.GetInt32(0);

                            switch (usertype)
                            {
                                case 0:
                                    //TODO: invalid user
                                    break;
                                case 1:
                                    //TODO: valid user
                                    GlobalVariables.User.Name = username;
                                    GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                                    GlobalVariables.User.Address = "1150 Wien";

                                    this.Frame.Navigate(typeof(ChooseOption));
                                    break;
                                case 2:
                                    //TODO: consultant
                                    break;
                                case 3:
                                    //TODO: admin
                                    break;
                                default:
                                    //TODO: invalid user
                                    break;
                            }
                        }
                    }
                }
            }
#endif
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            LoadRegisterUI();

        }

        private async void LoadRegisterUI()
        {
            CoreApplicationView newCoreView = CoreApplication.CreateNewView();

            ApplicationView newAppView = null;
            int mainViewId = ApplicationView.GetApplicationViewIdForWindow(
              CoreApplication.MainView.CoreWindow);

            await newCoreView.Dispatcher.RunAsync(
              CoreDispatcherPriority.Normal,
              () =>
              {
                  newAppView = ApplicationView.GetForCurrentView();
                  Window.Current.Content = new Registration();
                  Window.Current.Activate();
              });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
              newAppView.Id,
              ViewSizePreference.UseHalf,
              mainViewId,
              ViewSizePreference.UseHalf);
        }
    }
}
