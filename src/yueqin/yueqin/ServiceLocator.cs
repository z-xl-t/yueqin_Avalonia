using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.Services;
using yueqin.ViewModels;

namespace yueqin
{
  
    public class ServiceLocator
    {

        public static ServiceLocator _current;
        public static ServiceLocator Current
        {
            get => _current ?? (_current = new ServiceLocator());
            set => _current = value;
        }
        public IServiceProvider ServiceProvider { get; }

        public MainWindowViewModel MainWindowViewModel =>
            ServiceProvider.GetRequiredService<MainWindowViewModel>();

        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();

            // 注入 ViewModels
            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddSingleton<MainViewModel>();

            // 注入 Services
            serviceCollection.AddSingleton<IRootNavigationService, RootNavigationService>();
            serviceCollection.AddSingleton<IJsonSourceDataService, JsonSourceDataService>();
            serviceCollection.AddSingleton<IYueqinOptionsService, YueqinOptionsService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

        }
    }
}
