   M S B A M L   `   `   `  ����M  IProjecteMVVMWPFNou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjecteMVVMWPFNou.ViewsProjecteMVVMWPFNou.Views  5      M+clr-namespace:ProjecteMVVMWPFNou.ViewModelsProjecteMVVMWPFNou.ViewModels  5      +    %ProjecteMVVMWPFNou.Views.StudentsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProjecteMVVMWPFNou.Views     5      B
ViewModels+clr-namespace:ProjecteMVVMWPFNou.ViewModels     5      .��5      � ���	#FFE5E5E5  � DataContext  5   
   5   /ProjecteMVVMWPFNou.ViewModels.StudentsViewModel  5       � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   � $��0��6     6   ��  �� Mode$ OneWay=�.+�5      �� $��30��6   $��Guardar Estudiante��6!    J� RenderTransformOrigin$ 2.496,0.667&�6e   $��345,21,345,99q�6�   ��6>   �� *SaveStudentCommand+6�   �� 5      $	��Dni��6   $
��Left=�6"   $��	22,17,0,0q�6=   $	��Top=�6P   $ -0.771,-0.594&�6h   $��78��6�   �� 5      $��Nombre��6   $
��Left=�6%   $��	22,68,0,0q�6@   $	��Top=�6S   $��78��6k   �� 5      $��Silla��6   $
��Left=�6$   $��
22,107,0,0q�6?   $	��Top=�6S   $ 0.13,-0.391&�6k   $��78��6�   �� 5      -   5         ��Name$ DniText��5      $
��Left=�6'   $��23��6B   $��
125,21,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6�   $	��195��6�   $ 0.292,0.209&�6�   ��6v   �� *DniVM+6�   �� 5      -   5        $ NameText��5      $
��Left=�6(   $��23��6C   $��
125,68,0,0q�6O   $
 Wrap=�6c   $	��Top=�6�   $	��195��6�   ��6w   �� *NameVM+6�   �� 5      $
��Left=�6   $��23��61   $��125,107,0,0q�6=   $
 Wrap=�6R   $	��Top=�6�   $	��195��6�   $ 0.668,0.443&�6�   ��6f   �� *ChairNumberVM+6�   � 5      $��480,24,10,10q�6   ���	#FFBDC0CB.+�5      &   System.Windows.Controls.DataGrid  ��6   �� *
ErrorsList+5       �� 5!      $��Lista de Errores��6   $
��Left=�6/   $��	590,3,0,0q�6J   $	��Top=�6]   $	��130��6u   $��Normal"�6�   $��Italic$�6�   5$      � 5%   
   $��1��6    5&      �� 5'      $��* �6    �� 5(      $��40 �6    .+�5+      � $��0��6    � ColumnDefinitions 5,      �� 5-      $��* �6'   �� 5.      $
��Auto �6'   .+�51        $��5q�6k   ��6   �� *StudentsListNou+ �� SelectedItem 6C   �� *CurrentStudent+6k   �� 52      $��2��6A   $��Editar��6Q   
�������$��
0,5,10,140q�6u   ��6   �� *EditStudentCommand+6u   �� 53      $��2��6?   $��Eliminar��6O   
�������$��
0,140,10,5q�6u   ��6   �� *DelStudentCommand+6u   55      � 56      $��1��6   .+�57      �� $��Get Students��6   $	��100��6W   $��5q�6c   $��Right=�6n   ��60   �� *GetStudentsCommand+6n   58      59      5<      5=      