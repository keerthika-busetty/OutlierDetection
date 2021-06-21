using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.BL;
using OutliersDetection.DAL;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loading Data From csvalgorith
            ILoadAndGetData loadFromCSV = new LoadFromCSV();
            BaseLoadData baseLoad = new BaseLoadData(loadFromCSV);
            List<OutlierModel> baseData = baseLoad.GetData();

            //Detection of Outliers based on algorithm
            IDetection dectectionAlgo = new CSVDetectionAlgo();
            BaseDetection detection = new BaseDetection(dectectionAlgo);
            List<OutlierModel> clearData = detection.Detect(baseData);

            //writing Data to CSVFile
            //comment these lines if you dont want to write clear data to csv
            IOutPut outPut = new CSVOutPut();
            BaseOutPut baseOutPut = new BaseOutPut(outPut);
            baseOutPut.exposeOut(clearData, "OutPut.csv");
            Console.WriteLine("Clear Data  written to output file OutPut.csv in the project debug/bin/Data folder ");
            Console.Read();
        }
    }
}
