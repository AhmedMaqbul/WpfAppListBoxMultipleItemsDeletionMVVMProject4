using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppListBoxMultipleItemsDeletionMVVMProject4.Commands;

namespace WpfAppListBoxMultipleItemsDeletionMVVMProject4.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() 
        {
            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5",
            };

            DeleteCommand = new BaseCommand(DeleteItems);
        }
        public ObservableCollection<string> SelectedItems = new ObservableCollection<string>();

        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        { 
            get { return _items; }
            set 
            { 
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        

        public ICommand DeleteCommand { get; private set; }

        //public ICommand

        public void DeleteItems(object items)
        {
                foreach (var item in SelectedItems)
                {
                    Items.Remove(item);
                }
        }

        public bool CanDeleteItems(object parameter)
        {
            // Implement your custom logic here to determine if the DeleteCommand can be executed or not.
            return SelectedItems.Count > 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
