   M S B A M L   `   `   `  ����B  >Trigger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TriggerTrigger  5   	       Trigger.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Trigger     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value �� Triggers ]� 
Conditions �� Property �� Value��%�  '��       �� 5
   
   " ��6   �5      �� 5       � ��
 �   �5      �� 5       � ��
 �����5      �� 5       � ��$ Verdana)�5      �� 5       � ��$ 10q�5       5      ]� 5       5      �� 5       �@J�IsMouseOver . 5      �� 5       � �� . 5      /�5      �� 5       � ��$ 14(�5   	   �� 5        � ��
 �  ��5!   	   5#      5%      5)      .��5*      � 	 � RowDefinitions	 5+   
   �� 5,      �� 5-      �� 5.      .+�50   
   �� $��MultiTrigger��6   $��30��51      $��80��52      $��0��53      �� 55   
   $��EventTrigger ��6   $��1��56      $��30��57      $��80��58      �� 59   
   $��DataTrigger ��6   $��2��5:      $��30��5;      $��80��5<      5=      5>      