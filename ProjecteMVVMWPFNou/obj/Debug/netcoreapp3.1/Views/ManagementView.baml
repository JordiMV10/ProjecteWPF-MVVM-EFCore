   M S B A M L   `   `   `  ����M  IProjecteMVVMWPFNou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjecteMVVMWPFNou.ViewsProjecteMVVMWPFNou.Views  5      M+clr-namespace:ProjecteMVVMWPFNou.ViewModelsProjecteMVVMWPFNou.ViewModels  5      -    'ProjecteMVVMWPFNou.Views.ManagementView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProjecteMVVMWPFNou.Views     5      B
ViewModels+clr-namespace:ProjecteMVVMWPFNou.ViewModels     5      .��5
      � ���	#FFE5E5E5  � DataContext  5   
   7   1ProjecteMVVMWPFNou.ViewModels.ManagementViewModel  5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��MENÚ GESTIÓN��6   $��0��6'   $��0��64   $��Center=�6F   $��0,0,0,0q�6c   $	��Top=�6t   $
��Bold"�6�   �� 5   
   $��
DNI Alumno��6   $��1��6%   $��0��62   $
��Left=�6B   $��15,0,0,0q�6]   $	��Top=�6o   $��10(�6�   �� 5   
   $��1��6-   $��0��6:   $
��Left=�6J   $��	140,0,0,0q�6e   $	��Top=�6y   $	��190��6�   $��25��6�   ��6   �� *	DniMGVM+6�   �� 5    
   $��Buscar Alumno��6<   $��1��6T   $��1��6a   $
��Left=�6q   $��0,0,0,0q�6�   $	��Top=�6�   $��25��6�   $
��Bold"�6�   ��6   �� *FindStudentCommand+6�   �� 5!   
   $��ALUMNO ENCONTRADO��6   $��2��6,   $��0��69   $��Center=�6I   $��30,5,0,0q�6f   $	��Top=�6x   $
��Bold"�6�   �� 5"   
   $��
DNI Alumno��6   $��3��6%   $��0��62   $
��Left=�6B   $��15,5,0,0q�6]   $	��Top=�6o   $��10(�6�   �� 5#   
   $��3��6,   $��0��69   $
��Left=�6I   $��	140,5,0,0q�6d   $	��Top=�6w   $	��190��6�   $��25��6�   ��6   �� *	DniMGVM+6�   �� 5$   
   $��Nombre Alumno��6   $��3��6(   $��1��65   $
��Left=�6E   $��10,5,0,0q�6`   $	��Top=�6r   $��10(�6�   �� 5%   
   $��3��6,   $��1��69   $
��Left=�6I   $��	110,5,0,0q�6d   $	��Top=�6w   $	��190��6�   $��25��6�   ��6   �� *
NameMGVM+6�   �� 5&   
   $��AÑADIR ASIGNATURAS��6   $��4��6-   $��0��6:   $��Center=�6J   $��30,5,0,0q�6g   $	��Top=�6y   $
��Bold"�6�   �� 5'   
   $��Asignaturas��6   $��5��6&   $��0��63   $
��Left=�6C   $��15,5,0,0q�6^   $	��Top=�6p   $��10(�6�   �� 5(   
   $��Asignaturas Añadidas��6   $��5��6/   $��1��6<   $
��Left=�6L   $��15,5,0,0q�6g   $	��Top=�6y   $��10(�6�   � 5)   
   ���	#FFE5E5E5$��6��6&   $��0��63   $��0,0,30,5q�6C   $��3��6U   .+�5*      &   System.Windows.Controls.DataGrid  -   5          Name$ SubjectsMGVMDataGrid��5*      $��5,5,5,20q�6�   ��65   �� *SubjectListMGVM+ �� SelectedItem 6]   �� *CurrentSubjectMVM+6�   �� 5+      $��Ver Asignaturas��6   $��6��60   $��0��6=   $
��Left=�6z   $��10,5,0,0q�6�   $��Bottom=�6�   $��10(�6�    J� RenderTransformOrigin$ 0.895,0.422&�6�   ��6M   �� *GetSubjectsMGVMCommand+6�   �� 5,      $��AñadirAsignatura��6   $��6��60   $��0��6=   $
��Left=�6{   $��	190,5,0,0q�6�   $��Bottom=�6�   $��10(�6�   $	��140��6�   ��6M   �� *AddSubjectToListVMCommand+6�   50      � 52   
   ���	#FFE5E5E5$��5��6&   $��1��63   $��	0,28,85,5q�6D   $��3��6W   .+�53        -   5        $# SubjectsToStudentMGVMDataGrid��53      $��	5,5,10,20q�6�      AutoGenerateColumns$ False��6�   ��6>   �� *SubjectsByStudentList+ 6l   �� *CurrentStudentSubjectMVM+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Asignaturas��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� *Subject.Name+6b   57      �� 58      $��Borrar Asignatura��6   $��7��6a   $��1��6n   $��Center=�6~   $��0,5,0,0q�6�   $��Bottom=�6�   $ 0.379,-0.251&�6�   $��10(�6�   $	��130��6�   ��61   �� *DelSubjectToListVMCommand+6�   59      �� 5<   
   $��LISTAR��6   $��Right=�6W   $	��Top=�6s   $
��Bold"�6�   $	��150��6�   $��62��6�   $��1��6�   $��
0,10,10,10q�6�   $��6��6�   ��6"   �� *GetSubjectsToStudentVMCommand+6�   �� 5=   
   $��Error��6   $��1��6    $
��Left=�60   $��	100,0,0,0q�6K   $��1��6^   $��Center=�6k   �� 5>   
   $��1��69   $
��Left=�6I   $��	150,5,0,0q�6d   $��1��6w   
 �� TextWrapping$

 Wrap=�6�   $	��Top=�6�   $	��150��6�   ��6   �� *ManagementErrorMGVM+6�   5A      5B      