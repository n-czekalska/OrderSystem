using OrderSystem.Database;
using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.ViewModels
{
    public class ViewOrderViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public ViewOrderViewModel()
        {
            LoadFromFile load = new LoadFromFile();

            if (!load.FromCsv())
            {
                Orders = new ObservableCollection<Order>();
            }
            else
            {
                Orders = new ObservableCollection<Order>(load.Orders);
            }
        }
    }
}
