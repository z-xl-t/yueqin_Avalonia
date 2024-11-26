using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using yueqin.Models;
using yueqin.Services;
using yueqin.ViewModels;
using yueqin.Views;

namespace yueqin
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {

            // 注册应用程序运行所需的所有服务
            var serviceLocator = new ServiceLocator();
            ServiceLocator.Current = serviceLocator;

            var vm = serviceLocator.ServiceProvider.GetRequiredService<MainWindowViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = vm
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = vm
                };
            }

            var rootNavigationService = serviceLocator.ServiceProvider.GetRequiredService<IRootNavigationService>();
            rootNavigationService.NavigateTo(nameof(MainView));

            var options = Helpers.Helpers.GetYueqinOptionsFromFile();

            base.OnFrameworkInitializationCompleted();
        }
    }
}