using CommunityToolkit.Mvvm.ComponentModel;
using LiveSim.Core.Entities;
using LiveSim.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace LiveSim.Wpf.Simple.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly int TRAINING_ID = 12345;
        private readonly PeriodicTimer timer = new PeriodicTimer(new TimeSpan(0, 0, 0, 0, 500));
        private readonly IEntityLocationService service;

        public MainWindowViewModel(IEntityLocationService service)
        {
            this.service = service;
        }

        public ObservableCollection<EntityLocation> Locations { get; private set; } = new();

        public async Task StartRefreshAsync(Dispatcher dispatcher, CancellationToken token = default)
        {
            while (!token.IsCancellationRequested && await timer.WaitForNextTickAsync(token))
            {
                foreach (var location in await service.GetLiveLocationsAsync(TRAINING_ID))
                {
                    AddOrUpdate(dispatcher, location);
                }
            }
        }

        private void AddOrUpdate(Dispatcher dispatcher, EntityLocation location)
        {
            var index = Locations.IndexOf(Locations.FirstOrDefault(x => x.Id == location.Id));
            if (index >= 0)
            {
                dispatcher.Invoke(() => Locations[index] = location);
            }
            else
            {
                dispatcher.Invoke(() => Locations.Add(location));
            }
        }
    }
}
