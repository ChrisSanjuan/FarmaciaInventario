   M S B A M L   `   `   `  ����M  IProyectoFinalVista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProyectoFinal.GUIProyectoFinal.GUI  5   	        ProyectoFinal.GUI.Invitado   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProyectoFinal.GUI     5   	   J FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  Invitado��5	   	   $	��400��6   $	��400��6'    � WindowStartupLocation$ CenterScreen=�63   .��5
      � .+�5   
   �� .@�5      �� $��	Productos��6   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $��* �6(   .+�5      � $��0��6    .+�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� -   5         ��Name$ btnVerProducto��5   %   $��80��6=   .��6e   Ver6j   �� 5      -   5        $ btnLimpiarProducto��5   %   $��80��6A   .��6m   	Limpiar6v   5      5      �� 5      -   5         ��Name$ dtgInvitado��5   ,   $��2��6   ��5      �� 5      .R�5   "   �  � ColumnDefinitions 5   &   �� 5   *   $
��auto �6;   �� 5   *   $
��auto �6;    5!   &   �� 5"   *   $
��auto �68   �� 5#   *   $
��auto �68   �� 5$   *   $
��auto �68   �� 5%   *   $
��auto �68   .+�5'   &   �� $��0��6N   $��0��6^   $��2��6k   $��50��6|   $��50��6�   ��6,   �� *ImagenArticulo+6�   �� 5(   &   $��1��61   $��0��6A   $ 
Horizontal=�6N   .+�5)   *   �� $��|��64   $
��Bold"�6=   �� 5*   *   ��64   �� *NombreArticulo+�� 5+   *   $��|��64   $
��Bold"�6=   �� 5,   *   ��64   �� *	Categoria+�� 5-   *   $��|��64   $
��Bold"�6=   �� 5.   *   ��64   �� *Descripcion+5/   '   �� 50   &   $��1��6,   $��1��6<   ��6I   �� *PrecioArticulo+51   #   52      54      55      56      �� 57      $��	Empleados��6   .��58      �  59      �� 5:      $
��auto �6(   �� 5;      $
��auto �6(   �� 5<      $��* �6(   .+�5>      � $��0��6    .+�5?      �� $ 
Horizontal=�6%   .+�5@      �� -   5        $ btnVerEmpleado��5@   %   $��80��6=   .��6e   Ver6j   �� 5A      -   5        $ btnLimpiarEmpleados��5A   %   $��80��6B   .��6o   	Limpiar6x   5B      5C      �� 5D      -   5        $ dtgVerEmpleados��5D      $��2��68   ��5E      �� 5F      .R�5G   "   �  5H   &   �� 5I   *   $
��auto �6;   �� 5J   *   $
��auto �6;    5L   &   �� 5M   *   $
��auto �68   �� 5N   *   $
��auto �68   �� 5O   *   $
��auto �68   �� 5P   *   $
��auto �68   .+�5R   &   �� $��1��61   $��0��6A   $ 
Horizontal=�6N   .+�5S   *   �� $��|��64   $
��Bold"�6=   �� 5T   *   ��64   �� *NombreEmpleado+�� 5U   *   $��|��64   $
��Bold"�6=   �� 5V   *   ��64   �� *ApellidosEmpleado+5W   '   9� 5X   &   .��5Y   *   �� $��1��65   $��1��6E   .+�5Z   .   �� ��64   �� *Cargo+�� 5[   .   ��64   �� *DireccionEmpleado+�� 5\   .   ��64   �� *TelefonoEmpleado+�� 5]   .   ��64   �� *CorreoEmpleado+5^   +   5_   '   5`   #   5a      5c      5d      5e      �� 5f      $��Presentacion��6   .��5g      � .+�5h      � $��Center=�6    .+�5i      r�  r� Source$' !C:\MediaProject\ProyectoVideo.mp4?�6'   �� 5j      .+�5k      �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /Imagenes/dribbb.gif��6$   6^   5l      5m      5n      5o      5p      5q      5r      