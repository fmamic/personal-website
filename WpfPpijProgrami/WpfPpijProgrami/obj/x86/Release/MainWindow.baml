   M S B A M L   `   `   `  ���� J  FWpfPpijProgrami, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPpijProgramiWpfPpijProgrami       WpfPpijProgrami.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /localclr-namespace:WpfPpijProgrami       � Title$  PpijProgrami��$	��490��$	��525�� � Icon$ Image/ikona.png�� � 	Resources    WpfPpijProgrami.Podaci 
  podaci��%   &	          .���  � RowDefinitions �� $
��0.3* ��� $��3* ��� $��* ��� $
��0.2* �.+�o� -    o�Name$
 menu��$	��Top=�$��0��.@�m� $
��File��.@�m� -   $
��Exit��m� $
��Load��.@�m� -   $��Load Tokens��m� $��Browser��.@�m� $��Browser��� $��1�� � ColumnDefinitions �� $��* ��� $��2* �.+�� $��0�� �� $��0.18* ��� $
��0.2* ��� $��* �.+��� -    ��Name$ search��$��0��$��11(�$��5q� �� TextAlignment$ Center=� � ToolTip$ Unesite kontakt��.���� -   	 ��Name$	 kontakti��$��1��
 �� Padding$
 15 8 0 0q�
����ح�$��5q�
Contacts :� $��2��.+��� -    ��Name$ listBox��$��Stretch=�$��8q�$ Lista kontakta��� $��1�� �� $��2* ��� $��* �.+��� -   $ poruka��$��0��$��Stretch=� �� TextWrapping$
 Wrap=�$ Napisite poruku��$��5q����� *TekstPoruke+ �� Mode$ TwoWay=�.��� $��1�� �� $��* ��� $
��0.5* ��� $��* �.+�� $��1�� �� $��* ��� $��* ��� $��* �.+��� $��1��$��5q�$ Twitter Pin������ *Pin+$ TwoWay=�.���� $��2��$��5q�$ PpijBoard Replay Broj������ *PpijReplayNumber+$ TwoWay=�.��	� $��0��$��Facebook�� 	� 	GroupName$ network��$ Facebook��$��	50 10 0 0q� d� 	IsChecked �� *
IsFacebook+$ TwoWay=�	� $��0��$��Twitter��$ network��$��	50 40 0 0q�$ Twitter�� �� *	IsTwitter+$ TwoWay=�	� $��0��$��	PPIJboard��$ network��$ 	PPIJboard��$��	50 70 0 0q� �� *IsPpijBoard+$ TwoWay=�� $��2�� �� $��2* ��� $��* �.+��� -   $��0��$
��auto��$
��auto��$��
15 10 15 0q�$	��Top=�$
��Send���� -	   $��0��$
��auto��$
��auto��$��	15 0 15 5q�$��Bottom=�$��Browser���� -
   $	 pin��$��1��$��11(�$��	10 5 10 5q�$ PpijBoard ime Autora������ *	ImeAutora+$ TwoWay=�.��� $��2�� �� $
��0.4* ��� $��* �.+��� $��0��$��16(�$��Stretch=�$��Stretch=�$ Contact details��$��	30 40 0 0q�Contact details :�� $��1�� �� CornerRadius$ 5��
�������$��20 7 7 7q�._�� $��1�� �� �� ��  �� �� .+��� -   $		 tb1��$��0��$��0��$��5 5 0 5q�$
��Wrap=� ��  �� ElementName$	 tb1�� �� Path$
 Text��� -   $		 tb2��$��0��$��1��$��5 5 0 5q�$
��Wrap=� �� $	 tb2��$
 Text��� -   $		 tb3��$��1��$��0��$��5 5 0 5q�$
��Wrap=� �� $	 tb3��$
 Text��� -   $		 tb4��$��1��$��1��$��5 5 0 5q�$
��Wrap=� �� $	 tb4��$
 Text��� -   $		 tb5��$��2��$��0��$��5 5 4 5q�$
��Wrap=� �� $	 tb5��$
 Text��� -   $		 tb6��$��2��$��1��$��5 5 4 5q�$
��Wrap=� �� $	 tb6��$
 Text��� -    ��Name$ border��$��3��$��Stretch=�$��Stretch=�._��� -   $	 lastBox��$��10(�$��10 2 2 2q�$J DLoad Token (AllReady -> Green, NotAllReady-> Yellow, NotReady-> Red)��FDLoad Token (AllReady -> Green, NotAllReady-> Yellow, NotReady-> Red)