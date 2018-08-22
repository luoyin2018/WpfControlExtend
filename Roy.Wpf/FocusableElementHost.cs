using System.Windows;
using System.Windows.Controls;

namespace Roy.Wpf
{
    /// <summary>
    /// 解决焦点问题
    /// </summary>
    public class FocusableElementHost:ContentControl
    {
        static FocusableElementHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FocusableElementHost),
                new FrameworkPropertyMetadata(typeof(FocusableElementHost)));
        }
        public FocusableElementHost()
        {
            IsTabStop = false;
            this.MouseDown += (s, e) => this.Focus();
        }
    }
}
