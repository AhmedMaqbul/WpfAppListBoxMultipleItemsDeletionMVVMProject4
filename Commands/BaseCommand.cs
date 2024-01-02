using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppListBoxMultipleItemsDeletionMVVMProject4.Commands
{
    public class BaseCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public BaseCommand(Action<object> execute) : this(execute, null)
        {
        }

        public BaseCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
