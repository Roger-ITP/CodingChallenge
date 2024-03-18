using LiveSim.Core.Interfaces;
using LiveSim.Wpf.Simple.Services;
using LiveSim.Wpf.Simple.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LiveSim.Wpf.Simple
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection services = new ServiceCollection();
            services.AddHttpClient();
            services.AddScoped<MainWindow>();
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<IEntityLocationService, EntityLocationService>();

            ServiceProvider provider = services.BuildServiceProvider();
            MainWindow mainWindow = provider.GetService<MainWindow>();
            mainWindow.Show();

        }
    }

}
