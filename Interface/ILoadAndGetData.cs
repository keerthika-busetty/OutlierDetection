using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Model;

namespace OutliersDetection.Interface
{
    //Interface for loading and getting data
    public interface ILoadAndGetData
    {
        void LoadData();
        List<OutlierModel> GetData();

    }
}
