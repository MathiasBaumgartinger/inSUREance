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
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionMessenger : INotifyPropertyChanged
    {
        private Adviser clickedAdviser;
        public Adviser ClickedAdviser { get { return clickedAdviser; } }
        private string advName = "ERROR: could not be loaded";
        private List<Message> messages;
        private Message.MessageManager MesMan;
        private string picture;

        public string AdvName { get { return advName; } set { advName = value; OnPropertyChanged(); } }
        public string Picture { get { return picture; } set { picture = value; OnPropertyChanged(); } }

        public QuestionMessenger()
        {
            this.InitializeComponent();
            this.DataContext = this;

            // Get Data
            MesMan = new Message.MessageManager();
            messages = MesMan.GetMessages();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            clickedAdviser = (Adviser)e.Parameter;

            AdvName = clickedAdviser.Name;
            Picture = Directory.GetCurrentDirectory() + "\\Assets\\Pictures\\" + AdvName + ".jpg";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
