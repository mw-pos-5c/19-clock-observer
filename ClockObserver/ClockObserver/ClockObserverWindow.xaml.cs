using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClockObserver
{
    /// <summary>
    /// Interaktionslogik für ClockObserverWindow.xaml
    /// </summary>
    public partial class ClockObserverWindow : Window, INotifyPropertyChanged, IObserver
    {
        private ClockSubject clockSubject;

        public ClockObserverWindow(ClockSubject clockSubject)
        {
            InitializeComponent();
            DataContext = this;
            this.clockSubject = clockSubject;
            this.clockSubject.Attach(this);
        }

        private string time = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected void OnPropertyChanged(string e)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e));
        }

        public void Update()
        {
            if(!CheckAccess())
            {
                Dispatcher.Invoke(Update);
            }
            Time = clockSubject.Time;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            clockSubject.Detach(this);
        }
    }
}
