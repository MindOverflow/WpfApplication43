using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace SharedModules.Common.UI.Behaviors
{
    public class ClipboardManager : DependencyObject
    {
        #region Text

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(ClipboardManager),
                new PropertyMetadata(default(string)));

        public static void SetText(UIElement element, string value)
        {
            element.SetValue(TextProperty, value);
        }

        public static string GetText(UIElement element)
        {
            return (string)element.GetValue(TextProperty);
        }

        #endregion

        /// <summary>
        /// TODO: Чтобы обобщить поведение можно вместо IsEnabled сделать свойство типа CopyAction = None | MouseLeftButton | MouseRightButton.
        /// </summary>
        #region IsEnabled

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ClipboardManager),
                new PropertyMetadata(OnIsEnabledChanged));

        public static void SetIsEnabled(UIElement element, bool value)
        {
            element.SetValue(IsEnabledProperty, value);
        }

        public static bool GetIsEnabled(UIElement element)
        {
            return (bool)element.GetValue(IsEnabledProperty);
        }

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var elt = d as UIElement;
            if (elt == null)
                return;

            var oldVal = (bool)e.OldValue;
            var newVal = (bool)e.NewValue;

            elt.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            elt.MouseLeftButtonDown -= OnMouseLeftButtonDown;

            if (newVal)
            {
                elt.MouseLeftButtonUp += OnMouseLeftButtonUp;
                elt.MouseLeftButtonDown += OnMouseLeftButtonDown;
            }
        }

        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var elt = sender as UIElement;
            if (elt == null)
                return;

            e.Handled = true;
        }

        private static void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var elt = sender as UIElement;
            if (elt == null)
                return;

            e.Handled = true;

            try
            {
                var data = GetText(elt);
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

        #endregion

    }
}

