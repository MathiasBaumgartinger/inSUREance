using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inSUREance.Pages.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RateInsurance : INotifyPropertyChanged
    {
        private string ratingStarPicOne = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
        private string ratingStarPicTwo = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
        private string ratingStarPicThree = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
        private string ratingStarPicFour = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
        private string ratingStarPicFive = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
        private int chosenRating;

        public RateInsurance()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Window.Current.Close();
        }

        // TODO: Update database (rating)
        private void oneStar(object sender, RoutedEventArgs e)
        {
            RatingStarPicOne = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicTwo = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
            RatingStarPicThree = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
            RatingStarPicFour = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
            RatingStarPicFive = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";

            chosenRating = 1;
        }

        private void twoStars(object sender, RoutedEventArgs e)
        {
            RatingStarPicOne = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicTwo = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicThree = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
            RatingStarPicFour = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
            RatingStarPicFive = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";

            chosenRating = 2;
        }

        private void threeStars(object sender, RoutedEventArgs e)
        {
            RatingStarPicOne = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicTwo = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicThree = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicFour = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";
            RatingStarPicFive = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";

            chosenRating = 3;
        }

        private void fourStars(object sender, RoutedEventArgs e)
        {
            RatingStarPicOne = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicTwo = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicThree = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicFour = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicFive = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star.png";

            chosenRating = 4;
        }

        private void fiveStars(object sender, RoutedEventArgs e)
        {
            RatingStarPicOne = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicTwo = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicThree = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicFour = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";
            RatingStarPicFive = Directory.GetCurrentDirectory() + "\\Assets\\UI\\star_full.png";

            chosenRating = 5;
        }

        public string RatingStarPicOne
        {
            get { return ratingStarPicOne; }
            set { { ratingStarPicOne = value; OnPropertyChanged(); } }
        }

        public string RatingStarPicTwo
        {
            get { return ratingStarPicTwo; }
            set { { ratingStarPicTwo = value; OnPropertyChanged(); } }
        }

        public string RatingStarPicThree
        {
            get { return ratingStarPicThree; }
            set { { ratingStarPicThree = value; OnPropertyChanged(); } }
        }

        public string RatingStarPicFour
        {
            get { return ratingStarPicFour; }
            set { { ratingStarPicFour = value; OnPropertyChanged(); } }
        }

        public string RatingStarPicFive
        {
            get { return ratingStarPicFive; }
            set { { ratingStarPicFive = value; OnPropertyChanged(); } }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
