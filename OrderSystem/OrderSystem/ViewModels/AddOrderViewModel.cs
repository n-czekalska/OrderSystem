using OrderSystem.Commands;
using OrderSystem.Database;
using OrderSystem.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace OrderSystem.ViewModels
{
    public class AddOrderViewModel : BaseViewModel
    {
        #region TextBlock Content
        public string ItemNameTextBlock { get; private set; }
        public string ItemPriceTextBlock { get; private set; }
        public string ItemPaidTextBlock { get; private set; }
        #endregion

        public string ItemNameTextBox { get; private set; }
        public string ItemPriceTextBox { get; private set; }

        #region Paid Checkbox
        public bool IsPaid { get; set; }
        #endregion

        public string AddButtonText { get; private set; }
        public ICommand AddButtonCommand { get; set; }


        #region Constructor

        public AddOrderViewModel()
        {
            ItemNameTextBlock = "Item Name:";
            ItemPriceTextBlock = "Item Price:";
            ItemPaidTextBlock = "Paid";

            ItemNameTextBox = string.Empty;
            ItemPriceTextBox = string.Empty;

            IsPaid = false;

            AddButtonText = "Add Order";
            AddButtonCommand = new RelayCommand(AddButtonClick);
        }
        #endregion

        private void AddButtonClick()
        {
            if (string.IsNullOrWhiteSpace(ItemNameTextBox) || string.IsNullOrWhiteSpace(ItemPriceTextBox))
            {
                MessageBox.Show("Please enter all values");
                return;
            }

            Order order = new Order()
            {
                Name = ItemNameTextBox,
                Price = Convert.ToDecimal(ItemPriceTextBox),
                IsPaid = IsPaid
            };

            SaveToFile save = new SaveToFile();

            if (!save.ToCsv(order))
            {
                MessageBox.Show("Error while saving\n" + save.ErrorCode);
            }
            else
            {
                MessageBox.Show("Order saved");
                save = null;
            }

        }
    }
}
