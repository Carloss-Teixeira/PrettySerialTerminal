   M S B A M L   `   `   `  ����N  JPrettySerialMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PrettySerialMonitorPrettySerialMonitor  5   	   $    PrettySerialMonitor.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   -local!clr-namespace:PrettySerialMonitor  5   	     � Title$  Pretty Serial Monitor��5   	   $	��693��6'   $
��1000��64   $	��500��5   	   $	��500��5   	   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF303030��6    � Offset$ 0Q�6-   � 5      $ 	#FF363232��6   $ 1Q�6-   5      .��5      � $	��687��6   $	��Top=�6   .+�5   
   �� -   5        $%��ComboBoxComPortSelectorTerminal��5   %   |�.  $
��Left=�6L   $��
10,109,0,0q�6g   $	��Top=�6{   $	��152��6�   �� 5    
   -   5        $��ConnectButtonTerminal��5    #   |�.  $��Connect��6@   $
��Left=�6R   $��
10,142,0,0q�6m   $	��Top=�6�   $	��152��6�   �� 5#   
   -   5        $��TextBoxTerminal��5#   f   $ �� HorizontalScrollBarVisibility$ Visible=�6   " �� VerticalScrollBarVisibility$ Visible=�6?   $
��Left=�6~   $��
10,184,0,0q�6�   $	��Top=�6�   $	��440��6�   $	��972��6�    J� RenderTransformOrigin$ 0.461,0.505&�6�   �� 5&   
   -   5        $��ComboBoxBaudRateTerminal��5&       �� 
IsEditable . $
��Left=�6G   $��	10,78,0,0q�6b   $	��Top=�6u   $	��152��6�   �� 5(   
   -   5        $��StateTextBlockTerminal��5(      
�������$
��Left=�6K   $��	10,19,0,0q�6f   $
��Wrap=�6y   $��Disconnected��6�   $	��Top=�6�   $	��152��6�   $��61��6�   $��Arial)�6�   $��14(�6�   	 �� TextAlignment$	 Center=�6�   �� 5)   
   -   5        |�.  $��Refresh ports��5)   D   $
��Left=�6\   $��167,112,0,0q�6w   $	��Top=�6�   $	��119��6�   $��24��6�   �� 5+   
   -   5        $��TerminalSendTextBox��5+   (   
 �� TextWrapping$
 NoWrap=�6   $
��Left=�6D   $��23��6_   $��
10,629,0,0q�6k   $	��Top=�6�   $	��947��6�   $��3��6�   �� 5-   
   -   5        $��TerminalSendButton��5-   #   |�.  $
��Left=�6=   $��483,629,0,0q�6X   $	��Top=�6m   $��20��6�   $��26��6�   $��2��6�   .��5.      �� $��resources/sendicon.png��6   $��10��64   $��10��6@   z�5/      V� 50      .~�51      �� �� 52       �� AngleX$ -0.382Q�6(   �� 53      T� 54       T� X$ -0.08Q�6-   55      57      58      �� 59   
   -	   5        
������� d� 	IsChecked$
 TrueY�59   +   $��
AutoScroll��6<   $
��Left=�6Q   $��291,112,0,0q�6l   $	��Top=�6�   $��27��6�   $	��108��6�   �� 5:   
   -
   5        
�������$ FalseY�5:   +   $��Show senders��6=   $
��Left=�6T   $��291,141,0,0q�6o   $	��Top=�6�   $��27��6�   $	��108��6�   6�   �� 5;   
   -   5        |�.  $��Clear��5;   #   $
��Left=�63   $��167,142,0,0q�6N   $	��Top=�6c   $	��119��6{   6�   5=      5?      