using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection.BL
{
    public class CSVOutPut : IOutPut
    {
        public void OutputData(List<OutlierModel> data,string fileName)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Data", fileName);
                using (var writer = new StreamWriter(path))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    csvWriter.Context.RegisterClassMap<OutlierModelMap>();
                    csvWriter.WriteRecords(data.Select(u => new
                    { Date = u.Date.ToString("dd/MM/yyyy"), u.Price }));
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
