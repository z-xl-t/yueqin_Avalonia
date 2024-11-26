using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yueqin.Models;

namespace yueqin.Services
{
    public interface IYueqinOptionsService
    {
        YueqinOptions GetYueqinOptions();
        Task SaveYueqinOptions();
    }
}
