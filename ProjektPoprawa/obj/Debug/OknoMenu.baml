   M S B A M L   `   `   `  ����  ProjektPoprawa    Projekt_Poprawa.OknoMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  OknoMenu��5   	   $	��341��6   $	��578��6'    � WindowStartupLocation$ CenterScreen=�63    � WindowState$ 	Maximized=�6X    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ Close��5      5        5
   
   -   5        $
 Open��5
      5        5   
   -   5        $ Delete��5      5      .��5      � ��5   
   �� 5       �� ImageSource$ Pictures\przystan.png��6   .+�5   
   ]� .+�5      o� $��Right=�6   $��	0,0,0,280q�6*   .@�5      m� $��Opcje��6   $��Center=�6*   $��73��6G   .@�5      m� $��
Kalkulator��6    m� Command$
 Open��63    m� InputGestureText$ CTRL+K��6B    m� Icon 5      �� 5      $��Pictures/calcIcon.png��6$   $��15��6C   5      �� 5      m� 5       $��Zamknij aplikacje��6   $ Close��6:    5!      �� 5"      $��Pictures/exitIcon.png��6$   $��21��6C   5$      �� 5%      m� 5&      $��Cofnij��6   $ Delete��6/    5'      �� 5(      $��Pictures/arrow.png��6$   $��21��6@   5*      5+      5,      5-      �� 5.   
   -   5        $��listaDan��5.      $��0,28,0,0q�6#   $��Script MT Bold)�65   $��SemiBold"�6Q   $��20(�6g   &   System.Windows.Media.TextOptions	   TextHintingMode$	 Animated=�6u   ��5/      �� 50      $ Pictures/przystan.png��6   
 �� View
 52      �� 53       �� AllowsColumnReorder . P�54      �� 55      $��ID��6)    �� Width$ 50��65    �� DisplayMemberBinding 56      �� *ID+�� 57      $��Danie��6)   $
  200��68    58      �� *Nazwa+�� 59      $
��Cena��6)   $ 50��67    5:      �� *Cena+�� 5;      $��Rodzaj��6)   $	 140��69    5<      �� *Rodzaj+5>       �� 
GroupStyle 5@      (  "System.Windows.Controls.GroupStyle  5A         HeaderTemplate 5B      �� 5C      .R�5D      �� $
��Bold"�6(   $��15(�6:   ��6H   �� *Danie+5E      5G      5J      � 5K   
   5M      5N      5O      