using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Model;

namespace OutliersDetection.Interface
{
    //Interface for Detection
    public interface IDetection
    {
        List<OutlierModel> Detect(List<OutlierModel> allData);
    }
}
