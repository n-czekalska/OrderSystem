using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Database
{
    public class SaveToFile
    {
        private string _csvFilePath;
        public string ErrorCode { get; set; }

        public SaveToFile()
        {
            _csvFilePath = "H:\\Visual Studio 2015\\Projects\\Orders.csv";
            ErrorCode = string.Empty;
        }

        public bool ToCsv(Order order)
        {
            try
            {
                string csv = $"{order.Name},{order.Price.ToString()}, {order.IsPaid.ToString()}";
                csv = csv + Environment.NewLine;
                File.AppendAllText(_csvFilePath, csv.ToString());
                return true;
            }
            catch(Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
    }
}
