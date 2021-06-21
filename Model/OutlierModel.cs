using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace OutliersDetection.Model
{
    //Defining Model for Data
    public class OutlierModel
    {
        public DateTime Date;
        public Double Price;
    }
    //creating Mapper class for CSVHelper Nuget
    public class OutlierModelMap : ClassMap<OutlierModel>
    {
        public OutlierModelMap()
        {
            //createing mapping between properties and column names in csv
            Map(m => m.Date).Index(0).Name("Date");
            Map(m => m.Price).Index(1).Name("Price");
        }
    }
}
