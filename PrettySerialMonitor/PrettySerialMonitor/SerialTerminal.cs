using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
namespace PrettySerialMonitor
{
    class SerialTerminal
    {


        SerialPort port;
        Button connectDisconnectButton;
        TextBlock statusTextBlock;
        TextBox inputOutputTextBox;
        ComboBox baudRateComboBox;
        ComboBox selectSerialPortComboBox;



        public SerialTerminal(Button connectDisconnectButton, 
            TextBlock statusTextBlock,
            TextBox inputOutputTextBox,
            ComboBox baudRateComboBox,
            ComboBox selectSerialPortcomboBox)
        {

         

            
            


            port = new SerialPort();

            this.selectSerialPortComboBox = selectSerialPortcomboBox;
            this.baudRateComboBox = baudRateComboBox;
            this.inputOutputTextBox = inputOutputTextBox;
            this.statusTextBlock = statusTextBlock;
            this.connectDisconnectButton = connectDisconnectButton;

            //Insert some common baud rates on the comboBox

            baudRateComboBox.Items.Add("9600");
            baudRateComboBox.Items.Add("19200");
            baudRateComboBox.Items.Add("38400");
            baudRateComboBox.Items.Add("57600");
            baudRateComboBox.Items.Add("115200");

            ////////////////////////////////////////////////

            //add the serial ports to the select serial port combo box

            string[] portsList = SerialPort.GetPortNames();

            foreach (string port in portsList)
            {
                selectSerialPortComboBox.Items.Add(port);
            }
            ///////////////////////////////////////////////

            //Setup button

            //add the connect to serial port to the button clicked event
            connectDisconnectButton.Click += ConnectDisconnectButtonClick;
            ///////

            connectDisconnectButton.Content = "Connect";
            //////////////////////////////////////////////////

            //setup data received event and text box key pressed event
            
            inputOutputTextBox.PreviewKeyDown += TextBoxTerminal_KeyEvent;
            port.DataReceived += TerminalDataReceived;
            
        }

        /// <summary>
        /// 
        /// when the user presses a key while in focus of the textbox,if the port is open
        /// it sends the pressed keys
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxTerminal_KeyEvent(object sender, KeyEventArgs e)
        {
            //deletion or special keys are is not allowed
            if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.CapsLock || e.Key == Key.NumLock)
            {
                //when handled is true,it won´t show the key on the text box
                e.Handled = true;
                return;
            }


            if ( port.IsOpen == true)
            {
                //not to write "Return" on the text box
                if (e.Key == Key.Return)
                {
                    port.Write("\n");
                    inputOutputTextBox.AppendText("\n");

                }
               else if (Keyboard.IsKeyToggled(Key.CapsLock))
                {
                    port.Write(e.Key.ToString());
                    inputOutputTextBox.AppendText(e.Key.ToString());
                    
                }
                else
                {
                    port.Write(e.Key.ToString().ToLower());
                    inputOutputTextBox.AppendText(e.Key.ToString().ToLower());
                    
                }
                e.Handled = true;
                inputOutputTextBox.ScrollToEnd();
                inputOutputTextBox.CaretIndex = inputOutputTextBox.Text.Length;
            }
            else
            {
                //if the terminal isn´t open then,the letter wont know on the text box
                 e.Handled = true;
            }
                      
                    


            

        }


        private void ConnectDisconnectButtonClick(object sender, RoutedEventArgs e)
        {
            if (port.IsOpen == false)
            {
                if (selectSerialPortComboBox.SelectedItem is null)
                {
                    statusTextBlock.Text = "Serial port not selected";
                    return;
                }
                if (baudRateComboBox.SelectedItem is null || !(int.TryParse ((string)baudRateComboBox.SelectedItem,out _)))
                {
                    statusTextBlock.Text = "Invalid baud rate";
                    return;
                }
                int baudRate = int.Parse((string)baudRateComboBox.SelectedItem);
                string serialPortName = (string)selectSerialPortComboBox.SelectedItem;

                try
                {
                    port.PortName = serialPortName;
                    port.BaudRate = baudRate;

                    port.Open();
                }
                catch(Exception exc)
                {
                    statusTextBlock.Text = exc.Message;
                    return;
                }
                statusTextBlock.Text = "Connected \n" + port.PortName + "\n" + baudRate.ToString();

                connectDisconnectButton.Content = "Disconnect";
                baudRateComboBox.IsEnabled = false;
                selectSerialPortComboBox.IsEnabled = false;
            }
            else
            {
                port.Close();
                statusTextBlock.Text = "Disconnected";
                connectDisconnectButton.Content = "Connect";
                baudRateComboBox.IsEnabled = true;
                selectSerialPortComboBox.IsEnabled = true;
            }
        }

        /// <summary>
        /// receives data trought the serial port and write the data on the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TerminalDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            

            string dataFromPort = port.ReadExisting();
            string dataFromPortUTF16 = Convert.ToString(dataFromPort);

            inputOutputTextBox.Dispatcher.Invoke(() =>
            {
                inputOutputTextBox.AppendText(dataFromPortUTF16);
                inputOutputTextBox.ScrollToEnd();
            });
        }

    }


}
