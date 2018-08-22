WpfControlExtend
------------------
在使用WPF的基础控件的过程中，有一些小的不完善的地方，本仓库记录这些问题，并在基础控件上做了一些增强，以解决这些问题

# 控件
## FocusableElementHost
解决问题：默认布局控件不具备捕获焦点的能力，所以点击界面空白处，Textbox等输入控件不会丢失焦点（也就不会更新数据）

方法：使用FocusableElementHost作为窗口的顶层子元素

# 附加属性
## ScrollViewerExtensions
解决问题：默认的ScrollViewer控件，在内部内容变化，超出容器范围时，滚动条默认不会滚动到底部，这里添加了一个附加属性，使得ScrollViewer控件可以指定滚动到底部的行为。

注： 本扩展非原创