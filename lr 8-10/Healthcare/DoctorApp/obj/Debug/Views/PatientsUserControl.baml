   M S B A M L   `   `   `  ����D  @DoctorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DoctorApp	DoctorApp  5      #    DoctorApp.PatientsUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DoctorApp     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6    �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid     
IsReadOnly . $��3��5         AutoGenerateColumns . ��5      �� *
Patients+ �� SelectedItem 5      �� *SelectedPatient+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��1��6   $	��Add��5      $	��Top=�5      $��5q�5      $��35��5       $��35��5!      ��5      �� *AddPatientCommand+5!      �� 5#   
   $��1��6   $
��Edit��5%      $��1��5&      $	��Top=�5'      $��5q�5(      $��35��5)      $��35��5*      ��5$      �� *EditPatientCommand+5*      5+      5,      