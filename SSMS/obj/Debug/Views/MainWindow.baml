   M S B A M L   `   `   `  ����?  ;SSMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SSMS.Views
SSMS.Views  5   	   1clr-namespace:SSMS.ViewModelsSSMS.ViewModels  5   	       SSMS.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SSMS.Views     5   	   ,vmclr-namespace:SSMS.ViewModels     5   	     � WindowStyle$
  None=�5	   	    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�5   	    � Title$ 学生成绩管理系统��5   	   $	��900��6   $
��1600��6'   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 90Q�6    � DataContext 5      #   SSMS.ViewModels.MainViewModel  5   
   .��5      � .+�5   
   � -   5         �Name$ marker��5      $y�	Collapsed=�6   
���   � K� ZIndex$ 1��6I   	 J� Opacity$	 .5Q�6Z   � 5   
      BGBrush#��[  6   
 � RowDefinitions
 5   
   �� 5      $��90 �6   �� 5      .+�5   
   � ���#1488C6 � ColumnDefinitions 5      �� 5       �� 5!      .+�5#      ��  �� Orientation$ 
Horizontal=�6   .+�5$      �� $	����6   $��48(�6,   
�������$��/Fonts/#FontAwesome)�6M   $��Center=�6n   $��35 0 0 0q�6�   �� 5%      $��36(�6:   
�������$��Center=�6[   $��35 0 0 0q�6v   ��6   �� *AppDate.Name+6v   5&      �� 5'      $ 
Horizontal=�6   $��Right=�62   $��1��6N   .+�5(      �� $��36(�6F   
�������$��Center=�6g   $��0 0 10 0q�6�   ��6   �� *AppDate.CurrentUser.Name+6�   �� 5)      $��60��6   $��60��6$    �� CornerRadius$ 35��60   
�������$��0 0 15 0q�6V      IsHitTestVisibleInChrome . ._�5*      �� -   5        $	����5*       $��/Fonts/#FontAwesome)�60     TextBlockCloseStyle#��[ 5+       5,       5-      5.      5/      � 52   
   $��1��6   ���#F7F8F9 53      �� 54      $	��330 �6#   �� 55      .+�59      �� ���#273142._�5:      �� .+�5;      	� -   5          RadioButtonMenuStyle#��[ 5;   <   
 � Tag$	 ��6j   $��首页��6y   	� 5<      -   5        #��[ 5<   <   $	 ��6j   $��用户管理��6y   y�5=   "   �� *AppDate.CurrentUser.Role+  RoleToVisibleConverter �� 	Converter# [ 5>      5?      �� 5B      -   5         ��Name$ 	container��5B      $��1��60   5C      5E      5F      5G      5H      