﻿using System.Windows.Input;

namespace WpfHobbyList.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Func<object?, bool>? canExecute;
        
        public event EventHandler? CanExecuteChanged;
        
        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute=null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            } 
            else
                return canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
