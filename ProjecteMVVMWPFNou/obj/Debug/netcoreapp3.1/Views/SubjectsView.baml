   M S B A M L   `   `   `  ����M  IProjecteMVVMWPFNou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjecteMVVMWPFNou.ViewsProjecteMVVMWPFNou.Views  5      M+clr-namespace:ProjecteMVVMWPFNou.ViewModelsProjecteMVVMWPFNou.ViewModels  5      +    %ProjecteMVVMWPFNou.Views.SubjectsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProjecteMVVMWPFNou.Views     5      B
ViewModels+clr-namespace:ProjecteMVVMWPFNou.ViewModels     5      .��5      � ���	#FFE5E5E5  � DataContext  5   
   5   /ProjecteMVVMWPFNou.ViewModels.SubjectsViewModel  5       � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� $��30��6   $��Guardar Asignatura��6!    J� RenderTransformOrigin$ 2.496,0.667&�6f   $��250,110,440,10q�6�   ��6>   �� *SaveSubjectCommand+6�   �� 5      $��Nombre Asignatura��6   $
��Left=�60   $��	22,68,0,0q�6K   $	��Top=�6^   $	��118��6v   �� 5      -   5         ��Name$ SubjectNameText��5      $
��Left=�6/   $��23��6J   $��
165,68,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $	��Top=�6�   $	��195��6�   ��6~   �� *SubjectNameVM+6�   �� 5      $��MENÚ SUBJECTS��6   $
��Left=�6,   $��	22,25,0,0q�6G   $	��Top=�6Z   $	��338��6r   $
��Bold"�6~   $��18(�6�   � 5      $��480,24,10,10q�6   ���	#FFBDC0CB.+�5      &   System.Windows.Controls.DataGrid  ��6   �� *
ErrorsList+5      �� 5      $��Lista de Errores��6   $
��Left=�6/   $��	590,3,0,0q�6J   $	��Top=�6]   $	��130��6u   $��Normal"�6�   $��Italic$�6�   5      � 5    
   $��1��6    5!      �� 5"      $��* �6    �� 5#      $��40 �6    .+�5&      � $��0��6    � ColumnDefinitions 5'      �� 5(      $��* �6'   �� 5)      $
��Auto �6'   .+�5+        -   5          Name$ SubjectsDataGrid��5+      $��5,5,10,5q�6�   ��65   �� *SubjectList+ �� SelectedItem 6Y   �� *CurrentSubject+6�   �� 5,      $��1��6A   $��Editar��6Q   
�������$��
0,5,10,140q�6u   ��6   �� *EditSubjectCommand+6u   �� 5-      $��1��6?   $��Eliminar��6O   
�������$��
0,140,10,5q�6u   ��6   �� *DelSubjectCommand+6u   50      � 51      $��1��6   .+�52      �� $��Get Subjects��6   $	��100��6W   $��5q�6c   $��Right=�6n   ��60   �� *GetSubjectsCommand+6n   53      54      57      58      