   M S B A M L   `   `   `  ����L  HProyectoFinal.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProyectoFinal.GUIProyectoFinal.GUI  5   	       ProyectoFinal.GUI.LogIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProyectoFinal.GUI     5   	   J FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  LogIn��5	   	   $	��400��6   $	��400��6$    � WindowStartupLocation$ CenterScreen=�60   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��200 �6   �� 5      $��30 �6   �� 5      $��50 �6   .+�5   
   �� $��15(�6   $��Center=�6   $��0��6;   $��1��6H   .��6X   	Usuario6a   �� 5   
   $��/Imagenes/usuario.jpg��6   $��1��6/   $��1��6<   $	��150��6L   6[   �� 5   
   $��2��6   $��1��6   $��20��6-   6;   �� 5    
   $��3��6   $��0��6   .��6-   
Usuario:67   �� 5!   
   -   5         ��Name$ cmbUsuarioLog��5!      $��3��6*   $��1��67   6I   �� 5"   
   $��4��6   $��1��6   $��20��6-   6;   �� 5#   
   $��5��6   $��0��6   .��6-   Contraseña:6:   G� 5$   
   -   5         G�Name$ txbContraseniaLog��5$      $��5��61   $��1��6>   6P   �� 5%   
   $��6��6   $��1��6   $��20��6-   6;   �� 5&   
   -   5         ��Name$ btnLogIn��5&      $��7��6#   $��1��60   $��40��6@   .��6c   	Iniciar6l   5'      5(      