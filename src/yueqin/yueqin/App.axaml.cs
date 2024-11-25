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
using yueqin.Service;
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

            // ע��Ӧ�ó���������������з���
            var serviceLocator = new ServiceLocator();
            var vm = serviceLocator.ServiceProvider.GetRequiredService<MainViewModel>();

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


            // ... ������ʼ������ ...

            var pianoKeyService = serviceLocator.ServiceProvider.GetRequiredService<IPianoKeyService>();
            // ��ȡǶ���JSON��Դ
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var resourceName = "PianoKeys.json"; // �滻Ϊ���������ռ���ļ���
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            var pianoKeys = pianoKeyService.GetPianoKeys(json);
           


            base.OnFrameworkInitializationCompleted();
        }
    }
}