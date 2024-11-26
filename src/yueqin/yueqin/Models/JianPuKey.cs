using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yueqin.Models
{
    public class JianPuKey
    {
        public int JianPuKeyIndex { get; set; }
        public required string Name { get; set; }
        
        // 0 为基准 + 高音，- 低音 
        public int Dot { get; set; }
       

        public static JianPuKey GetDefaultJianPukey () => new()
        {
            JianPuKeyIndex = 61,
            Name = "1",
            Dot = 0,
        };
    }
}
