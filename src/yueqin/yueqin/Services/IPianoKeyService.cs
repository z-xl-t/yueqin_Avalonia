using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.Models;


namespace yueqin.Service
{
    public interface IPianoKeyService
    {
        IList<PianoKey> GetPianoKeys(string json);
    }
}
