   M S B A M L   `   `   `  ���� N  JPrettySerialMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PrettySerialMonitorPrettySerialMonitor  $    PrettySerialMonitor.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  -local!clr-namespace:PrettySerialMonitor    � Title$  Pretty Serial Monitor��$	��749��$
��1000��$	��500��$	��500������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF303030�� � Offset$ 0Q�� $ 	#FF363232��$ 1Q�.��� $��0,0,0,0q�.+��� -   $%��ComboBoxComPortSelectorTerminal��|�.  $
��Left=�$��
10,155,0,0q�$	��Top=�$	��152��$��2���� -   $��ConnectButtonTerminal��|�.  $��Connect��$
��Left=�$��
10,218,0,0q�$	��Top=�$	��152��$��2���� -   $��TextBoxTerminal��$ �� HorizontalScrollBarVisibility$ Visible=�" �� VerticalScrollBarVisibility$ Visible=�$
��Left=�$��
10,278,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��346��$	��972�� J� RenderTransformOrigin$ 0.461,0.505&��� -   $��ComboBoxBaudRateTerminal��	 �� 
IsEditable	 . $
��Left=�$��
10,187,0,0q�$	��Top=�$	��152��$��2���� -   $��StateTextBlockTerminal��
�������$
��Left=�$��	10,89,0,0q�$
��Wrap=�$��Disconnected��$	��Top=�$	��152��$��61��$��Arial)�$��14(�
 �� TextAlignment$
 Center=�$��2���� -   |�.  $��Refresh ports��$
��Left=�$��	20,10,0,0q�$	��Top=�$	��116��$��24���� -   $��TerminalSendTextBox��$
��Left=�$��23��$��
10,629,0,0q�$
 Wrap=�$	��Top=�$	��947���� -   $��TerminalSendButton��$
��Left=�$��962,629,0,0q�$	��Top=�$��20��$��26��.���� $��resources/sendicon.png��$��10��$��10��z�V� .~��� ��  �� AngleX$ -0.382Q��� T�  T� X$ -0.08Q�