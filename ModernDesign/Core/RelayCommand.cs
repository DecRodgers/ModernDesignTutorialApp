﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernDesign.Core
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<Object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        { 
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;  }        
        }

        public RelayCommand(Action<object> execute, Func<object, bool> callExecute = null)
        {
            _execute = execute;
            _canExecute = callExecute;
        }

        public bool CanExecute(object parameter)
        { 
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        { 
            _execute(parameter);
        }
    }
}
