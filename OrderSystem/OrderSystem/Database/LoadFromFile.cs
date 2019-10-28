using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Database
{
    public class LoadFromFile
    {
        private string _csvFilePath;
        public string ErrorCode { get; set; }
        public List<Order> Orders { get; set; }

        public LoadFromFile()
        {
           _csvFilePath = "H:\\Visual Studio 2015\\Projects\\Orders.csv";
            ErrorCode = string.Empty;
            Orders = new List<Order>();
        }

        public bool FromCsv()
        {
            try
            {
                var info = File.ReadAllLines(_csvFilePath);
                foreach (string value in info)
                {
                    var line = value.Split(',');
                    Orders.Add(new Order()
                    {
                        Name = line[0],
                        Price = Convert.ToDecimal(line[1]),
                        IsPaid = Convert.ToBoolean(line[2])
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
    }
}
