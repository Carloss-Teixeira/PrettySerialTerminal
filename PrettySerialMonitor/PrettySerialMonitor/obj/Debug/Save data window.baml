   M S B A M L   `   `   `  ����N  JPrettySerialMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PrettySerialMonitorPrettySerialMonitor  5   	   (    "PrettySerialMonitor.SaveDataWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PrettySerialMonitor     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  Save data Window��5
   	   $	��232��6"   $	��550��6/    � 
ResizeMode$ NoResize=�5      ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF303030��6    � Offset$ 0Q�6-   � 5      $ 	#FF363232��6   $ 1Q�6-   5      .��5      � $��0,0,-8,0q�6   $	��550��6   $	��192��6)   $	��Top=�66   .+�5   
   �� -   5         ��Name$ DirectoryTextBox��5      $
��Left=�6,   $��25��6G   $��	10,10,0,0q�6S   $��Save adress��6g   $	��Top=�6z   $��492.833��6�   
�������6�   �� 5   
   -   5         ��Name$" DirectorySelectTextBoxButton��5      $�� ��67   $
��Left=�6B   $��
507,10,0,0q�6]   $	��Top=�6q   $��28��6�   $��11��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   
�������z�5      V� 5      .~�5      �� 	 �� ScaleY$	 -1Q�6%   �� 5      �� 5      T� 5      5      5      �� 5    
   -   5        
 ��Name$
 PreviewSavedFile��5       
�������$
��Left=�6@   $	��142��6[   $��276.416,40,0,0q�6h   
���   �$	��Top=�6�   $��263.584��6�   �� 5!   
   -   5        $ FileNameTextBox��5!      $
��Left=�6+   $��23��6F   $��	75,40,0,0q�6R    �� TextWrapping$ NoWrap=�6e   $��FileName��6{   $	��Top=�6�   $��196.416��6�   
�������6�   �� 5"   
   $
��Left=�6   $��11.416,44,0,0q�6/   $
��Wrap=�6F   $	��Top=�6Z   
�������$��15��6�   $��60��6�    �� TextAlignment$ Center=�6�   �� 6�   $�Filename��6�   �� 6�   �� 6�   6�   �� 5#   
    d� 	IsChecked$
 TrueY�6   $��Computer��6$   $
��Left=�67   $��96.416,71,0,0q�6R   $	��Top=�6i   
�������$��19��6�   $��85��6�   
�������6�   �� 5$   
   $
 TrueY�6   $��
Terminal 1��6$   $
��Left=�69   $��186.416,71,0,0q�6T   $	��Top=�6l   
�������$��19��6�   $��85��6�   
�������6�   �� 5%   
   {�.  $��
Terminal 2��6%   $
��Left=�6:   $��96.416,95,0,0q�6U   $	��Top=�6l   
�������$��19��6�   $��85��6�   
�������6�   �� 5&   
   {�.  $��
Terminal 3��6%   $
��Left=�6:   $��186.416,95,0,0q�6U   $	��Top=�6m   
�������$��19��6�   $��85��6�   
�������6�   �� 5'   
   -   5        $��ShowSendersCheckBox��5'      $��Senders��6.   $
 TrueY�6@   $
��Left=�6Q   $��	11,71,0,0q�6l   $	��Top=�6   
�������$��19��6�   $��80��6�   
�������6�   �� 5(   
   -   5        $��
SaveButton��5(      $
��Save��6#   $
��Left=�62   $��11.416,152.7,0,0q�6M   $	��Top=�6g   $��248.584��6   6�   �� 5)   
   -   5         ��Name$ NewLinesCheckBox��5)      $��	New Lines��6-   $
 TrueY�6A   $
��Left=�6R   $��	10,95,0,0q�6m   $	��Top=�6�   
�������$��19��6�   $��81��6�   
�������6�   5*      5+      