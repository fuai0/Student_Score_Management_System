   M S B A M L   `   `   `  ����?  ;SSMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SSMS.Views
SSMS.Views  5   	   1clr-namespace:SSMS.ViewModelsSSMS.ViewModels  5   	       SSMS.Views.RegisterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SSMS.Views     5   	   ,vmclr-namespace:SSMS.ViewModels     5   	     � Title$  用户注册��5	   	   $	��450��6   $	��800��6#    � DataContext 5
      '   !SSMS.ViewModels.RegisterViewModel  5   
   .��5      ��    BGBrush#��[  6   .+�5   
   �� $��用户注册��6   $��36(�6    
 �� Top$	 100��6.    �� Left$	 350��6?   �� 5   
   $��
用户名:��6   $	 160��6   $	 300��60   �� 5   
   $	 160��60   $	 350��6A   $	��150��6S   $��30��6_   ��6   �� *Student.Name+6_   �� 5   
   $��密码:��6   $	 200��6   $	 310��6/   �� 5   
   $	 200��64   $	 350��6E   $	��150��6W   $��30��6c   ��6   �� *Student.Password+6c   �� 5   
   $��城市:��6   $	 240��6   $	 310��6/   �� 5   
   $	 240��60   $	 350��6A   $	��150��6S   $��30��6_   ��6   �� *Student.City+6_   �� 5   
   $��性别:��6   $	 280��6   $	 310��6/   	� 5   
   $	��男��6   $	 285��6"   $	 350��63   $	��150��6E   $��30��6Q    d� 	IsChecked 6]   �� *IsBoy+	� 5   
   $	��女��6   $	 285��6"   $	 400��63   $	��150��6E   $��30��6Q    6]   �� *IsGril+�� 5   
   $��确认注册��6   $	 320��5      $	 370��6   
�������$	��100��5      $��30��6+   ��5       �� *RegisterCommand+5   +   5      5      