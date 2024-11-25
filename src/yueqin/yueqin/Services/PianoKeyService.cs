using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.Models;

namespace yueqin.Service
{
    public class PianoKeyService : IPianoKeyService
    {
        private readonly JsonConvertWrapper _jsonConvertWrapper;

        public PianoKeyService(JsonConvertWrapper jsonConvertWrapper)
        {
            _jsonConvertWrapper = jsonConvertWrapper;
        }
        public IList<PianoKey> GetPianoKeys(string json)
        {
            var result = _jsonConvertWrapper.Deserialize<List<PianoKey>>(json);
            return result;
        }
    }
}
