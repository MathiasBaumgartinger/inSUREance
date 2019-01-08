﻿using System;
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

#if DEBUG
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
                            //int usertype = reader.GetBoolean(0);

                            //der spass is nur, solange die stored procedure nur true/false returned
                            bool isuser = reader.GetBoolean(0);
                            if (isuser)
                            {
                                GlobalVariables.User.Name = username;
                                GlobalVariables.User.Birthday = new DateTime(1997, 11, 22);
                                GlobalVariables.User.Address = "1150 Wien";

                                this.Frame.Navigate(typeof(ChooseOption));
                            }
                            else
                            {
                                allertMessage.Text = "Wrong Username or Password";
                            }

                            //switch (usertype)
                            //{
                            //    case 0:
                            //        allertmessage.text = "wrong username or password";
                            //        break;
                            //    case 1:
                            //        //todo: get data
                            //        this.frame.navigate(typeof(ChooseOption));
                            //        break;
                            //    case 2:
                            //        //todo: get data
                            //        this.frame.navigate(typeof(ChooseOptionAdv));
                            //        break;
                            //    case 3:
                            //        //todo: get data
                            //        this.frame.navigate(typeof(ChooseOptionAdv));
                            //        break;
                            //    default:
                            //        //todo: get data
                            //        allertmessage.text = "wrong username or password";
                            //        break;
                            //}
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
