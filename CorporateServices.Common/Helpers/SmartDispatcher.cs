using System;
using System.Windows;
using System.Windows.Threading;

namespace CorporateServices.Common.Helpers
{
    public static class SmartDispatcher
    {
        private static Dispatcher _dispatcher;

        public static void Invoke(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            EnsureDispatcher();

            if (_dispatcher.CheckAccess())
                action();
            else
                _dispatcher.Invoke(action);
        }

        public static void InvokeAsync(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            EnsureDispatcher();

            if (_dispatcher.CheckAccess())
                action();
            else
                _dispatcher.BeginInvoke(action);
        }

        public static T Invoke<T>(Func<T> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            EnsureDispatcher();
            return _dispatcher.CheckAccess()
                ? func()
                : (T)_dispatcher.Invoke(func);
        }

        private static void EnsureDispatcher()
        {
            if (_dispatcher == null)
                _dispatcher = Application.Current.Dispatcher;
        }
    }
}
