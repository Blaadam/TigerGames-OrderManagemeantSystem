using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using System.Timers;
using Timer = System.Timers.Timer;

namespace TigerGames_OrderManagementSystemSS
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Window
    {
        private Timer progressBarTimer;
        public LoadingScreen()
        {
            InitializeComponent();

            BeginTimer();
        }

        public void BeginTimer()
        {
            // Create the new time with the tick interval of 16 milliseconds
            progressBarTimer = new Timer(16);

            // Subscribe to the Elapsed Event

            progressBarTimer.Elapsed += new ElapsedEventHandler(Timer_Tick);

            // Start the Timer
            progressBarTimer.Start();
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            // Invoke the Update on the UI THread
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)(() =>
            {

                if (LoadingProgressBar.Value < 100)
                {
#if DEBUG
                    LoadingProgressBar.Value += 1;
#else
                    LoadingProgressBar.Value += 0.4;
#endif
                }
                else
                {
                    progressBarTimer.Stop();
                    // Create a new Login Window
                    LoginScreen window = new LoginScreen();
                    // Close the Loading Screen Window
                    this.Close();
                    // Show the Login Window
                    window.ShowDialog();
                }
            }));

            //throw new NotImplementedException();
        }
    }
}
