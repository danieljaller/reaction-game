using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GameTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            startPage.Visibility = Visibility.Visible;
            waitForIt.Visibility = Visibility.Hidden;
            go.Visibility = Visibility.Hidden;
            displayWinner.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startPage.Visibility = Visibility.Hidden;
            waitForIt.Visibility = Visibility.Visible;
            WaitForGo();
        }
        private async void WaitForGo()
        {
            var randomizer = new Random();
            int timeSpan = randomizer.Next(3000, 5000);
            await Task.Delay(timeSpan);
            waitForIt.Visibility = Visibility.Hidden;
            go.Visibility = Visibility.Visible;
            KeyDown += PressKeyOnGo;            
        }

        private void PressKeyOnGo(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                DisplayWinner("A");
            }
            if (e.Key == Key.L)
            {
                DisplayWinner("L");
            }
        }

        private void DisplayWinner(string winningPlayer)
        {
            go.Visibility = Visibility.Hidden;
            displayWinner.Visibility = Visibility.Visible;
            winner.Text = winningPlayer;
        }

        private void buttonRestart_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
