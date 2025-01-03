﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.Models;


namespace yueqin.Services
{
    public interface IJsonSourceDataService
    {
        IList<PianoKey> GetPianoKeys();
        IList<JianPuKey> GetJianPuKeys();
        IList<PianoKeyWithJianPuKeyBase> GetPianoKeyWithJianPuKeyBase();
    }
}
