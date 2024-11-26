using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yueqin.Models
{
    public class PianoKey
    {
        public int PianoKeyIndex { get; set; }
        public required string Name { get; set; }

        // 八度 ,从 0 计数
        public int Octave { get; set; }

        public static PianoKey GetDefaultPianoKey() => new()
        { 
            PianoKeyIndex = 40,
            Name = "C",
            Octave = 4,
        };
    }
}
