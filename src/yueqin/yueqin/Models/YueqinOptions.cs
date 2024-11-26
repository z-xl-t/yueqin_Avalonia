using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.ViewModels;

namespace yueqin.Models
{
    public class YueqinOptions
    {
        public bool ShowSharp { get; set; }
        public bool ShowPiano { get; set; }
        public bool ShowJianPu { get; set; }
        public int XianMax { get; set; }
        public int PingMax { get; set; }
        public required PianoKeyWithJianPuKeyBase PianoKeyWithJianPuKeyBase {get;set;}
        public required List<PianoKey> XianEmptyPianoKey { get; set; }



        public static YueqinOptions GetDefaultYueqinOptions() =>
            new()
            {
                ShowSharp = true,
                ShowPiano = true,
                ShowJianPu = true,
                XianMax = 4,
                PingMax = 16,

                PianoKeyWithJianPuKeyBase =  PianoKeyWithJianPuKeyBase.GetDefaultPianoKeyWithJianPuKeyBase(),
                XianEmptyPianoKey =
                [
                    PianoKey.GetDefaultPianoKey(),
                    PianoKey.GetDefaultPianoKey(),
                    PianoKey.GetDefaultPianoKey(),
                    PianoKey.GetDefaultPianoKey(),
                ],
            };
    }
}
