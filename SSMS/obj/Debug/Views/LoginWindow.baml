   M S B A M L   `   `   `  ����?  ;SSMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SSMS.Views
SSMS.Views  5   	   1clr-namespace:SSMS.ViewModelsSSMS.ViewModels  5   	       SSMS.Views.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SSMS.Views     5   	   ,vmclr-namespace:SSMS.ViewModels     5   	   -   5          �Name$  _loginWindow��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $��14(�5   	    � Title$ 用户登录 ��5   	   $	��450��6   $	��800��6$    � DataContext 5      $   SSMS.ViewModels.LoginViewModel  5   
   .��5      ��    BGBrush#��[  6   .+�5   
   �� $��学生成绩管理系统��6   $��36(�6$   
 �� Top$	 100��62    �� Left$	 260��6C   �� 5   
   $��
用户名:��6   $	 180��6   $	 300��60   �� 5   
   $	 180��60   $	 350��6A   $	��150��6S   $��30��6_   ��6   �� *Student.Name+6_   �� 5   
   $��密码:��6   $	 220��6   $	 315��6/   �� 5   
   $	 220��64   $	 350��6E   $	��150��6W   $��30��6c   ��6   �� *Student.Password+6c   �� 5   
   $��登  录��6   $	 270��5      $	 300��6"   
�������$	��100��5   #   $��30��6/   ��5       �� *LoginCommand+��6A   ��  �� ElementName$ _loginWindow��5   /   �� 5   
   $��注  册��6   $	 270��5      $	 440��6"   
�������$	��100��5   #   $��30��6/   ��5       �� *RegisterCommand+5   /   5      5      