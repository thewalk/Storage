   M S B A M L   `   `   `  ����  Storage!    Storage.View.ConfigKindView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ConfigKindView��5      .��5
      � .+�5   
   �� -   5         ��Name$ 	mainPanel��5      $��0q�6(   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ addBtn��5      $��增加��6)   66   �� 5      -   5        $ delBtn��5      $��删除��6)   66   �� 5      -   5        $ modBtn��5      $��修改��6)   66   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ kindDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . ��6I   ��  �� Path$ KindList�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 品种名称��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $
 Name�  5      $
 备注��6)    65   �� $
 Note�5      5      5      5      