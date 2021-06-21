using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutliersDetection.Interface;
using OutliersDetection.Model;

namespace OutliersDetection.BL
{
    //Algo for detection of outliers from csvfile
    public class CSVDetectionAlgo : IDetection
    {
        //Method to detect outliers from data from csv
        public List<OutlierModel> Detect(List<OutlierModel> allData)
        {
            List<OutlierModel> clearData = new List<OutlierModel>();
            try
            {
                //variable Declaration
                Stack<OutlierModel> outliers = new Stack<OutlierModel>();
                List<OutlierModel> temp = new List<OutlierModel>();
                int previouscount = 0, currentIndex = 0;
                //looping only if more than one record
                if (allData.Count > 1)
                {
                    foreach (OutlierModel data in allData)
                    {
                        //calculating statndard deviation
                        temp.Add(data);
                        Double average = temp.Average(u => u.Price);
                        Double sum = temp.Sum(d => Math.Pow(d.Price - average, 2));
                        Double standardDeviation = Math.Sqrt((sum) / (temp.Count() - 1));
                        //push to stack if condition is satisfied
                        if ((Math.Abs(data.Price - average)) > (3 * standardDeviation))
                        {
                            //finding if there is any change in the trend by checking if two
                            //consecutive items from the data are added,  even if they are not outliers
                            currentIndex = allData.IndexOf(allData.Find(u => u.Price == data.Price && u.Date == data.Date));
                            //checking current index and previous index
                            if (previouscount == currentIndex - 1)
                            {
                                //intiating the temp list to start the avg from this index
                                temp = new List<OutlierModel>();
                                //adding previous item to the templist
                                temp.Add(allData[previouscount]);
                                //adding current item to the templist
                                temp.Add(allData[currentIndex]);
                                //adding two items to the notoutliers list
                                clearData.Add(outliers.Pop());
                                clearData.Add(data);
                            }
                            else
                            {
                                outliers.Push(data);
                            }
                            //capturing previous index
                            previouscount = allData.IndexOf(allData.Find(u => u == data));

                        }
                        else
                            clearData.Add(data);
                    }
                    //return normalNumbers;
                    if (outliers.Count() > 1)
                    {
                        //Displaying Data
                        Console.WriteLine("NO: of Outliers are:{0}", outliers.Count());
                        Display(outliers);
                    }
                    if (clearData.Count() > 1)
                    {
                        //Displaying Data
                        Console.WriteLine("NO: of ClearData are:{0}", clearData.Count());
                        //uncomment if want to print clear data to console 
                        //Display(notOutliers);
                    }
                    //Console.Read();
                }
            }
            catch (Exception ex)
            {

            }

            return clearData;
        }
        //method to diplay data based on the input
        private static void Display(IEnumerable<OutlierModel> Data)
        {
            Console.WriteLine("Date,Price");
            foreach (OutlierModel model in Data)
            {
                //formating datetime before displaying
                Console.WriteLine("{0},{1}", model.Date.ToString("dd/MM/yyyy"), model.Price);
            }
            Console.Write("\n");

        }
    }
}
