   M S B A M L   `   `   `  ����@  <GDCui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GDCui.View
GDCui.View  5      "    GDCui.View.GameBlueprintView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:GDCui.View     5      .��5	      � 
���`���  � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��
Blueprints��6    
���**��
������ $��18(�6`   $
��Left=�6o   $	��Top=�6�   $	��350��6�   $
��1000��6�   $��
104,60,0,0q�6�   .��5      &   System.Windows.Controls.DataGrid     CanUserResizeRows .     CanUserSortColumns .     CanUserReorderColumns . 
�������   	RowHeight$ 40Q�5   �      MaxColumnWidth$	 200Q�6�      AutoGenerateColumns .  $
��Left=�5   3   $	��top=�6N   $	��990��6f   $	��310��6r   $��0,10,0,0q�6      
IsReadOnly .  �� SelectedItem 5      �� *SelectedBlueprint+��6B   �� *
Blueprints+	 � 	Resources	 5      *  $System.Windows.Controls.DataGridCell
 �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value)  #System.Windows.Controls.DataGridRow�� 5      %4  '        '  #    �� 5      "
  6>   .�5      ��  � ��
 ���� 6;   �� 5       � ��
 ���� 6<   �� 5       � ��
 �   �6;    5      P� 5   "    �@ 
IsSelected . . �5   &   ��  � ��
 � ���6C   �� 5   &    � ��
 � ���6D   5   #   5!      �� 5#      "
  6    .�5$      ��  � ��
 ���� 6;   �� 5%       � ��
 ���� 6<    5&      P� 5'   "    �@ 
IsSelected . . �5(   &   ��  � ��
 � ���6C   �� 5)   &    � ��
 � ���6D   5*   #   5,      5-         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$ Blu_Id�   HeaderStyle 52      �� 53      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  6$   .�54   "   ��  � ��$ Center=�6H   55         ElementStyle 57      �� 58      "
 ��6$   .�59   "   ��  �@��TextAlignment$ Center=�6B   �� 5:   "    � ��$ Center=�6F   �� 5;   "    � ��$ CharacterEllipsis=�6A   �� 5<   "    �@�ToolTip 6<   �� *Text+ �� RelativeSource �� *Self+5=      5?        5A      $
 Name��6)   $	 300 67    6C   �� $
 Name� 5B      �� 5C      "
  6$   .�5D   "   ��  � ��$ Center=�6H   5E       5G      �� 5H      "
 ��6$   .�5I   "   ��  �@��TextAlignment$ Center=�6B   �� 5J   "    � ��$ Center=�6F   �� 5K   "    � ��$ CharacterEllipsis=�6A   �� 5L   "    �@�ToolTip 6<   �� *Text+ �� *Self+5M      5O      5R      5U      �� 5W   
   $��Add New��6   
���**��$
��Left=�67   $	��Top=�6R   $��18(�6j   $	��450��6x   $	��200��6�   $��104,454,0,0q�6�   .��5X      � $
��Left=�6   $	��Top=�6.   $	��450��6F   $	��200��6R   .+�5Y      �� $��Name:��6   $
��Left=�6(   $	��Top=�6C   $��18(�6[   $��30��6i   $��60��6u   $��	10,10,0,0q�6�   �� 5Z      -   5         ��Name$ tbName��5Z       � ToolTip$ 
Enter Name��6D   $��Right=�6Y   $��30��6u    �� TextWrapping$
 Wrap=�6�   $��18(�6�   $	��top=�6�   $	��273��6�   $��
0,10,101,0q�6�   ��6*   �� *
NameText+6�   �� 5[      -   5        $��btnAdd��5[      $ Adds item to the grid��6'   $	��Add��6f   $��20(�6t   $��332,117,28,43q�6�   $��40��6�   $��90��6�   ��6G   �� *
AddCommand+6�   5\      5]      �� 5_   
   $��Update/Delete��6   
���**��$��18(�6=   $
��Left=�6K   $	��Top=�6f   $	��200��6~   $	��450��6�   $��654,454,0,0q�6�   .��5`      � $
��Left=�6   $	��Top=�6.   $	��200��6F   $	��450��6S   .+�5a      �� $��Name:��6   $
��Left=�6(   $	��Top=�6C   $��18(�6[   $��30��6i   $��60��6u   $��	10,10,0,0q�6�   �� 5b      -   5        $ tbNameUpdate��5b      $ 
Enter Name��6W   $��Right=�6l   $��30��6�   $
 Wrap=�6�   $��18(�6�   $	��top=�6�   $	��273��6�   $��
0,10,102,0q�6�   ��60   �� *SelectedBlueprintName+6�   �� 5c      -   5        $��	btnUpdate��5c      $ Adds item to the grid��6*   $��Update��6l   $��20(�6}   $��10,114,350,42q�6�   $��40��6�   $��90��6�   ��6J   �� *UpdateCommand+6�   �� 5d      -   5         ��Name$ 	btnDelete��5d      $  Deletes item from the grid��6,   $��Delete��6s   $��20(�6�   $��333,116,27,44q�6�   $��40��6�   $��90��6�   ��6Q   �� *DeleteCommand+6�   5e      5f      5h      5i      