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
using inSUREance.Classes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Questions : Page
    {
        public List<Adviser> Advisers { get; set; }

        public Questions()
        {
            this.InitializeComponent();
            DataContext = this;

            //Get Data
            Advisers = Adviser.AdviserManager.GetTypes();
        }

        private void AdvisersListview_ItemClick(object sender, ItemClickEventArgs e)
        {
            Adviser clickedAdviser = (Adviser)e.ClickedItem;
            this.Frame.Navigate(typeof(QuestionMessenger), clickedAdviser);
        }
    }
}
