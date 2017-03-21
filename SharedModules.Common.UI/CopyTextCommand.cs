using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace SharedModules.Common.UI
{
    public class CopyTextCommand : ICommand
    {
        public void Execute(object param)
        {
            if (param == null)
                return;

            try
            {
                var data = param.ToString();
                if (!string.IsNullOrEmpty(data))
                {
                    Clipboard.Clear();
                    Clipboard.SetText(data);
                }
            }
            catch (COMException)
            {
                //Nothing to do
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}

