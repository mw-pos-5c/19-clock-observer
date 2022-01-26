using System;
using System.Threading;
using System.Windows;

namespace ClockObserver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClockSubject subject = new();
        private bool running = true;
        public MainWindow()
        {
            InitializeComponent();
            new Thread(ClockThread).Start();
        }

        private void ClockThread(object? obj)
        {
            while (running)
            {
                subject.Time = DateTime.Now.ToString("G");
               
                Thread.Sleep(1000);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ClockObserverWindow(subject);
            window.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            running = false;
        }
    }
}
