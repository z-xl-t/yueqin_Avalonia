using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.Service;
using yueqin.ViewModels;

namespace yueqin
{
    public class JsonConvertWrapper
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
    public class ServiceLocator
    {
        public IServiceProvider ServiceProvider { get; }
        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();

            // 注入 ViewModels
            serviceCollection.AddSingleton<MainViewModel>();

            //

            serviceCollection.AddSingleton<JsonConvertWrapper>();

            // 注入 Services
            serviceCollection.AddSingleton<IPianoKeyService, PianoKeyService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

        }
    }
}
