using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yueqin.Models
{
    public class PianoKeyWithJianPuKeyBase
    {
        public required string Name { get; set; }
        public required int JianPuKeyIndex { get; set; }
        public required int PianoKeyIndex { get; set; }

        public static PianoKeyWithJianPuKeyBase GetDefaultPianoKeyWithJianPuKeyBase() => new()
        {
            Name = "1=C4",
            JianPuKeyIndex = 61,
            PianoKeyIndex = 40
        };

    }
}
