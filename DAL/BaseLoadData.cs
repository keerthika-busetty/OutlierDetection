using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection.DAL
{
    //Base class to load data from any source
    public class BaseLoadData
    {
        public ILoadAndGetData loadSource;
        //Injecting dependcy through constructor
        public BaseLoadData(ILoadAndGetData fromSource )
        {
            this.loadSource = fromSource;
        }
        //Toload data from source and get data
        public List<OutlierModel> GetData()
        {
            loadSource.LoadData();
            return loadSource.GetData();
            
        }
    }
}
