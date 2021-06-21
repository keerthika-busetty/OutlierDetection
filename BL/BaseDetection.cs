using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection.BL
{
    //Base class for Detection Algorithm
    public class BaseDetection
    {
       public IDetection dectectionAlgo;
        //Injecting dependcy through constructor
        public  BaseDetection(IDetection alog)
        {
            dectectionAlgo = alog;
            
        }
        //method to call detect method of algorithm
        public List<OutlierModel> Detect(List<OutlierModel> allData)
        {
           return dectectionAlgo.Detect(allData);
        }
    }
}
