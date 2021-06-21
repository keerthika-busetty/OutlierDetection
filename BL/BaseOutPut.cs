using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection.BL
{
    public class BaseOutPut
    {
        public IOutPut outPut;
        //injecting parameter through constructor
        public BaseOutPut(IOutPut outPutParameter)
        {
            outPut = outPutParameter;
        }
        //calling actual method from the algorithm
        public void exposeOut(List<OutlierModel> allData,string path)
        {
            outPut.OutputData(allData,path);
        }
    }
}
