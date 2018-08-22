using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Roy.Wpf
{
    /// <summary>
    /// 默认ScrollViewer滚动条在内部内容填充超过高度时，不会自动滚动到底部
    /// </summary>
    public class ScrollViewerExtensions
    {
        public static readonly DependencyProperty AlwaysScrollToEndProperty =
            DependencyProperty.RegisterAttached("AlwaysScrollToEnd", typeof(bool), typeof(ScrollViewerExtensions), new PropertyMetadata(false, AlwaysScrollToEndChanged));

        private static bool _autoScroll;
        private static void AlwaysScrollToEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScrollViewer scroll = d as ScrollViewer;
            if(scroll != null)
            {
                bool alwaysScollToEnd = (e.NewValue != null) && (bool)e.NewValue;
                if(alwaysScollToEnd)
                {
                    scroll.ScrollToEnd();
                    scroll.ScrollChanged += Scroll_ScrollChanged;
                }
                else
                {
                    scroll.ScrollChanged -= Scroll_ScrollChanged;
                }
            }
            else
            {
                throw new InvalidOperationException("The attached AlwaysScrollToEnd property can only be applied to ScrollViewer instances");
            }
        }

        public static bool GetAlwaysScrollToEnd(ScrollViewer scroll)
        {
            if (scroll == null) throw new ArgumentNullException(nameof(scroll));
            return (bool)scroll.GetValue(AlwaysScrollToEndProperty);
        }
        public static void SetAlwaysScrollToEnd(ScrollViewer scroll, bool alwaysScrollToEnd)
        {
            if (scroll == null) throw new ArgumentNullException(nameof(scroll));
            scroll.SetValue(AlwaysScrollToEndProperty, alwaysScrollToEnd);
        }

        private static void Scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            if(scroll == null) 
                throw new InvalidOperationException("The attached AlwaysScrollToEnd property can only be applied to ScrollViewer instances");
            if(e.ExtentHeightChange == 0) { _autoScroll = scroll.VerticalOffset == scroll.ScrollableHeight; }
            if(_autoScroll && e.ExtentHeightChange != 0) { scroll.ScrollToVerticalOffset(scroll.ExtentHeight); }
        }
    }
}
