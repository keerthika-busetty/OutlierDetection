using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Model;

namespace OutliersDetection.Interface
{
    //interface for outputData
    public interface IOutPut
    {
        void OutputData(List<OutlierModel> data, string fileName);
    }
}
