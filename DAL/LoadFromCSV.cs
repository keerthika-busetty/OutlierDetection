using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection.DAL
{
    //This is used for loading the data from the csv file to the model
    //Implementing ILoadAndGetData
    class LoadFromCSV : ILoadAndGetData
    {
        public List<OutlierModel> listProduct = new List<OutlierModel>();

        //return loaded data
        public List<OutlierModel> GetData()
        {
            return listProduct;
        }

        //actual implementaion of loading data from csv
        public void LoadData()
        {
            try
            {
                //setting path for csv
                string path = Path.Combine(Environment.CurrentDirectory, "Data", "Outliers.csv");
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    NewLine = Environment.NewLine,
                };
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<OutlierModelMap>();
                    //get records from csv and load data to model
                    listProduct = csv.GetRecords<OutlierModel>().ToList<OutlierModel>();
                }
            }
            catch(Exception ex)
            {
               
            }
        }
    }
}
