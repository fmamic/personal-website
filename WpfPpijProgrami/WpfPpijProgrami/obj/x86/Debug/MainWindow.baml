   M S B A M L   `   `   `  ����  WpfPpijProgrami     WpfPpijProgrami.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  PpijProgrami��5   	   $	��490��6   $	��525��6+    � Icon$ Image/ikona.png��67    � 	Resources 5      ��%    5      .��5      �  � RowDefinitions 5   
   �� 5	      $
��0.3* �6   6,   �� 5
      $��3* �6   6*   �� 5      $��* �6   6)   �� 5      $
��0.2* �6   6,   .+�5   
   o� -   5         o�Name$
 menu��5      $	��Top=�5      $��0��5      .@�5      m� $
��File��6   .@�5      m� -   5        $
��Exit��5      5   9   5      m� 5      $
��Load��6   .@�5      m� -   5        $��Load Tokens��5      5   >   5      m� 5      $��Browser��6   .@�5      m� $��Browser��6   6.   5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $��* �6#   6/   �� 5!      $��2* �6#   60   .+�5$      � $��0��6    5%      �� 5&      $��0.18* �6$   65   �� 5'      $
��0.2* �6$   64   �� 5(      $��* �6$   61   .+�5*      �� -   5         ��Name$ search��5*      $��0��5+      $��11(�5,      $��5q�5-       �� TextAlignment$ Center=�5.       � ToolTip$ Unesite kontakt��5/      .��50   ;   51      �� 52      -   5        	 ��Name$	 kontakti��53      $��1��52      
 �� Padding$
 15 8 0 0q�54      
����ح�$��5q�56      
Contacts :59      � 5:      $��2��6   .+�5;      �� -   5         ��Name$ listBox��5;      $��Stretch=�5<   !   $��8q�5=   !   $ Lista kontakta��5>   !   5@      5A      5B      � 5C      $��1��6    5D      �� 5E      $��2* �6$   62   �� 5F      $��* �6$   61   .+�5H      �� -   5        $ poruka��5H      $��0��5I      $��Stretch=�5J       �� TextWrapping$
 Wrap=�5K      $ Napisite poruku��5L      $��5q�5M      ��5N      �� *TekstPoruke+ �� Mode$ TwoWay=�.��6D   5O      � 5P      $��1��6    5Q      �� 5R      $��* �6+   67   �� 5S      $
��0.5* �6+   6:   �� 5T      $��* �6+   67   .+�5V      � $��1��6    5W      �� 5X      $��* �6,   69   �� 5Y      $��* �6,   69   �� 5Z      $��* �6,   69   .+�5\      �� $��1��6"   $��5q�5]   "   $ Twitter Pin��5^   "   ��5_   "   �� *Pin+$ TwoWay=�.��6D   5`      �� 5a      $��2��6"   $��5q�5b   "   $ PpijBoard Replay Broj��5c   "   ��5d   "   �� *PpijReplayNumber+$ TwoWay=�.��6Q   5e      5f      	� 5g      $��0��6"   $��Facebook��5h   "    	� 	GroupName$ network��5i   "   $ Facebook��5j   "   $��	50 10 0 0q�5k   "    d� 	IsChecked 5l   "   �� *
IsFacebook+$ TwoWay=�5m   %   	� 5n      $��0��6"   $��Twitter��5o   "   $ network��5p   "   $��	50 40 0 0q�5q   "   $ Twitter��5r   "    5s   "   �� *	IsTwitter+$ TwoWay=�5t   %   	� 5u      $��0��6"   $��	PPIJboard��5v   "   $ network��5w   "   $ 	PPIJboard��5x   "   $��	50 70 0 0q�5y   "    5z   "   �� *IsPpijBoard+$ TwoWay=�5{   %   � 5|      $��2��6    5}      �� 5~      $��2* �6,   6:   �� 5      $��* �6,   69   .+�5�      �� -   5        $��0��5�      $
��auto��5�      $
��auto��5�      $��
15 10 15 0q�5�      $	��Top=�5�      $
��Send��5�      5�      �� 5�      -	   5        $��0��5�      $
��auto��5�      $
��auto��5�      $��	15 0 15 5q�5�      $��Bottom=�5�      $��Browser��5�      5�      �� 5�      -
   5        $	 pin��5�      $��1��5�      $��11(�5�      $��	10 5 10 5q�5�      $ PpijBoard ime Autora��5�      ��5�      �� *	ImeAutora+$ TwoWay=�.��5�      5�      5�      5�      5�      5�      � 5�   
   $��2��6    5�      �� 5�      $
��0.4* �6#   5�      �� 5�      $��* �6#   6/   .+�5�      �� $��0��6   $��16(�5�      $��Stretch=�5�      $��Stretch=�5�      $ Contact details��5�      $��	30 40 0 0q�5�      Contact details :5�      �� 5�      $��1��6    �� CornerRadius$ 5��5�      
�������$��20 7 7 7q�5�      ._�5�      � $��1��6    5�      �� 5�      6-   �� 5�      6-   �� 5�      6-    5�      �� 5�      6*   �� 5�      6*   .+�5�      �� -   5        $		 tb1��5�       $��0��5�       $��0��5�       $��5 5 0 5q�5�       $
��Wrap=�5�        5�       ��  �� ElementName$	 tb1�� �� Path$
 Text��� 5�      -   5        $		 tb2��5�       $��0��5�       $��1��5�       $��5 5 0 5q�5�       $
��Wrap=�5�        5�       �� $	 tb2��$
 Text��� 5�      -   5        $		 tb3��5�       $��1��5�       $��0��5�       $��5 5 0 5q�5�       $
��Wrap=�5�        5�       �� $	 tb3��$
 Text��� 5�      -   5        $		 tb4��5�       $��1��5�       $��1��5�       $��5 5 0 5q�5�       $
��Wrap=�5�        5�       �� $	 tb4��$
 Text��� 5�      -   5        $		 tb5��5�       $��2��5�       $��0��5�       $��5 5 4 5q�5�       $
��Wrap=�5�        5�       �� $	 tb5��$
 Text�5�      �� 5�      -   5        $		 tb6��5�       $��2��5�       $��1��5�       $��5 5 4 5q�5�       $
��Wrap=�5�        5�       �� $	 tb6��$
 Text�5�      5�      5�      �� 5�   
   -   5         ��Name$ border��5�      $��3��5�      $��Stretch=�5�      $��Stretch=�5�      ._�5�      �� -   5        $	 lastBox��5�      $��10(�5�      $��10 2 2 2q�5�      $J DLoad Token (AllReady -> Green, NotAllReady-> Yellow, NotReady-> Red)��5�      FDLoad Token (AllReady -> Green, NotAllReady-> Yellow, NotReady-> Red)5�      5�      5�      5�      