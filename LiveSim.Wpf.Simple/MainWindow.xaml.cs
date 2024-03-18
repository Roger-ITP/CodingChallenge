using LiveSim.Wpf.Simple.ViewModels;
using System.Windows;

namespace LiveSim.Wpf.Simple
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts = new();

        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _ = vm.StartRefreshAsync(App.Current.Dispatcher, cts.Token);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cts.Cancel();
        }
    }
}