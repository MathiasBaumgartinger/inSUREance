using inSUREance.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static inSUREance.Classes.InsuranceType;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InsuranceOverview : INotifyPropertyChanged
    {
        private List<Insurance> insurances;
        private List<InsuranceType> InsuranceTypes;
        private InsuranceManager InsurManager;
        private InsuranceType clickedItem;
        private string displayType = "all";

        public List<Insurance> Insurances
        {
            get { return insurances; }
            set
            {
                if(insurances != value)
                {
                    insurances = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DisplayType
        {
            get { return displayType; }
            set
            {
                if (displayType != value)
                {
                    displayType = value;
                    OnPropertyChanged();
                }
            }
        }

        public InsuranceOverview()
        {
            this.InitializeComponent();
            this.DataContext = this;
            //this.contentControl.Content = new UserControl();

            // Get data
            InsurManager = new InsuranceManager();
            insurances = InsurManager.GetInsurances();
            InsuranceTypes = InsurTypeManager.GetTypes();
        }

        private void Insurance_ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Insurance clickedInsurance = (Insurance)e.ClickedItem;
            this.Frame.Navigate(typeof(DetailedInsurance), clickedInsurance);
        }

        private void Types_ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            clickedItem = (InsuranceType)e.ClickedItem;
            Insurances = InsurManager.GetInsurances(clickedItem.category);
            DisplayType = clickedItem.category;

           // this.contentControl.Content = new UserControl();
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
