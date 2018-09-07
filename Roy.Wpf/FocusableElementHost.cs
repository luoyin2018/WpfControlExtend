using System.Windows;
using System.Windows.Controls;

namespace Roy.Wpf
{
    /// <summary>
    /// 解决点击界面空白部分，输入控件不丢失焦点问题
    /// </summary>
    // TODO: 可以为通过Panel类创建附加属性来完成这个功能，20180907
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
