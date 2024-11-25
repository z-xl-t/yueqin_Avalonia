using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yueqin.Models
{
    public class PianoKey
    {
        public int KeyIndex { get; set; }
        public required string Name { get; set; }
        public int Octave { get; set; }
        public int PrevPianoKeyIndex { get; set; }
        public int NexPianoKeyKeyIndex { get; set; }
    }
}
