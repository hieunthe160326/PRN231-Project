   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   L HProject2023PRN231, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project2023PRN221Project2023PRN221 5   	   $   Project2023PRN221.WindowReport   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Project2023PRN221     5   	     � Title$  WindowReport��5
   	   $	��450��5   	   $	��800��5   	   .��5      ��  �� CornerRadius$ 20��6   ._�5   
   � 
����d� � RowDefinitions 5      �� 5      $��80 �6    �� 5      $��* �6    �� 5      $��50 �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�5      .+�5      �� $��
350 20 0 0q�6   $��Center=�5      $��30(�5      $
��Bold"�5      $	��400��5      $��REPORT��5      
����ح�5      �� 5      -   5        $��btnCloseMain��5      $��0 0 0 0q�5      $��50��5       $��50��5!      $��Right=�5"      $	��Top=�5#      .��5%      �� $��Images/shutdown_mo.png��6   5&      5'      � 5(      $��1��6   .+�52         LiveCharts.Wpf.PieChart  -   5        &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�52         	Hoverable$
 True��54      $��50q�55         DataTooltip 56      Z�    Series 5<         LiveCharts.Wpf.PieSeries     LiveCharts.Wpf.Series   Title$ Ban phim��6(   	   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$	 3 5=   (   
   
DataLabels$

 True��5>   (      
LabelPoint 5?   (   �� *
PointLabel+  5@      $ Chuot��6(   $	 4 5A   (   $

 True��5B   (    5C   (   �� *
PointLabel+  5D      $ Ban phim T1��6(   $	 6 5E   (   $

 True��5F   (    5G   (   �� *
PointLabel+5I      5J      �� 5K      $��2��6   $ 
Horizontal=�5L      .+�5M      �� -   5        $��btnBack��5O      $��
330 0 0 20q�5M      $��Center=�5N       !  MaterialDesignFlatMidBgButton#��[  5P      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5Q      $��50��5R      $	��120��5S      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5T      $��20(�5U      $
��BACK��5V      5W      5X      5Y      5Z      5[      