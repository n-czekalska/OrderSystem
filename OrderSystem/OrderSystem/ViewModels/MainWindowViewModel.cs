using OrderSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using OrderSystem.Views;

namespace OrderSystem.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string AddOrderButtonContent { get; private set; }
        public string ViewOrderButtonContent { get; private set; }

        public ICommand AddOrderButtonCommand{ get; private set; }
        public ICommand ViewOrderButtonCommand { get; private set; }

        public UserControl ContentControlBinding { get; private set; }

        public MainWindowViewModel()
        {
            AddOrderButtonContent = "AddOrder";
            ViewOrderButtonContent = "View Orders";

            AddOrderButtonCommand = new RelayCommand(AddOrderButtonClick);
            ViewOrderButtonCommand = new RelayCommand(ViewOrderButtonClick);

            ContentControlBinding = new DefaultView();
        }

        private void AddOrderButtonClick()
        {
            ContentControlBinding = new AddOrderView();
            OnChanged(nameof(ContentControlBinding));
        }

        private void ViewOrderButtonClick()
        {
            ContentControlBinding = new ViewOrderView();
            OnChanged(nameof(ContentControlBinding));
        }
    }
}
