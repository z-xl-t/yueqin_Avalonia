using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using yueqin.Models;

namespace yueqin.Services
{
    public class JsonSourceDataService : IJsonSourceDataService
    {
        public List<PianoKey> PianoKeys { get; set; }
        public List<JianPuKey> JianPuKeys { get; set; }
        public List<PianoKeyWithJianPuKeyBase> PianoKeyWithJianPuKeyBases { get; set; }
        public JsonSourceDataService()
        {
            PianoKeys = GetEmbeddedResourcesToList<List<PianoKey>>($"{nameof(PianoKeys)}.json");

            JianPuKeys = GetEmbeddedResourcesToList<List<JianPuKey>>($"{nameof(JianPuKeys)}.json");

            PianoKeyWithJianPuKeyBases = GetEmbeddedResourcesToList<List<PianoKeyWithJianPuKeyBase>>($"{nameof(PianoKeyWithJianPuKeyBases)}.json");

        }

        public static T GetEmbeddedResourcesToList<T>(string resourceName)
        {
            // 读取嵌入的JSON资源
            var assembly = typeof(App).GetTypeInfo().Assembly;
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                return default;
            }
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }

        public IList<JianPuKey> GetJianPuKeys()
        {
            return JianPuKeys;
        }
        public IList<PianoKey> GetPianoKeys()
        {
            return PianoKeys;
        }

        public IList<PianoKeyWithJianPuKeyBase> GetPianoKeyWithJianPuKeyBase()
        {
            return PianoKeyWithJianPuKeyBases;
        }
    }
}
