using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.ViewModels;
using yueqin.Views;

namespace yueqin.Services
{
    public class RootNavigationService: IRootNavigationService
    {
        public void NavigateTo(string view)
        {
            if (view == RootNavigationConstant.MainView)
            {
                var mainVm = ServiceLocator.Current.ServiceProvider.GetRequiredService<MainViewModel>();
                ServiceLocator.Current.MainWindowViewModel.Content = mainVm;
            }
        }
    }
    public static class RootNavigationConstant
    {
        public const string MainView = nameof(MainView);
    }
}
