   M S B A M L   `   `   `  ����  Storage$    Storage.View.ConfigContactView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      UserControl_1��.��5      � 
Grid_1��.+�5	   
   �� -   5          ��Name$  	mainPanel��5	   '   	mainPanel��$��0q�6:   .+�5
      �� StackPanel_1�� �� Orientation$ 
Horizontal=�6.   $��Right=�6G   .+�5      �� -   5         ��Name$ addBtn��5   (   
addBtn��$��增加��68   6E   �� 5      -   5        $ delBtn��5   (   
delBtn��$��删除��68   6E   �� 5      -   5        $ modBtn��5   (   
modBtn��$��修改��68   6E   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ contactDataGrid��5   /   contactDataGrid��   AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . ��6d   ��  �� Path$ ContactList�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      DataGridTextColumn_2��,  &System.Windows.Controls.DataGridColumn	   Header$	 姓名��6F   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6R   �� $
 Name�  5      DataGridTextColumn_3��$	 身份证号��6F   
 6T   �� $ Identity�  5      DataGridTextColumn_4��$	 电话��6F   
 6R   �� $ Phone�  5      DataGridTextColumn_5��$	 住址��6F   
 6R   �� $ Address�  5      DataGridTextColumn_6��$	 备注��6F   
 6R   �� $
 Note�5      5      5      5      