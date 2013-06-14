﻿namespace ArchiMeter.UI.Support
{
	using System;
	using System.Windows.Input;

	internal class DelegateCommand : ICommand
	{
		private readonly Func<object, bool> _canExecute;
		private readonly Action<object> _execute;

		public event EventHandler CanExecuteChanged;

		public DelegateCommand(Func<object, bool> canExecute, Action<object> execute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			if (_canExecute(parameter))
			{
				_execute(parameter);
			}
		}

		public void UpdateCanExecute()
		{
			var handler = CanExecuteChanged;
			if (handler != null)
			{
				CanExecuteChanged(this, EventArgs.Empty);
			}
		}
	}
}