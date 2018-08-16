using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.IO;


namespace PrettySerialMonitor
{
    enum TerminalModes
    {
        assci = 0,
        hex = 1,
        bin = 2,

    }

  public  class SerialTerminal
    {


        struct SerialText
        {
           public string Sender { get; }
           public string Message { get; }

            public SerialText(string sender,string message)
            {
                this.Sender = sender;
                this.Message = message;
            }
        }


   
       
        public bool AutoScroll { get; set; } = true;
        public bool ShowSenders { get; set; } = false;

        List<SerialText> SerialMessages = new List<SerialText>(250);
     
      
        SerialPort port;
        Button connectDisconnectButton;
        TextBlock statusTextBlock;
        RichTextBox inputOutputTextBox;
        ComboBox baudRateComboBox;
        ComboBox selectSerialPortComboBox;
        TextBox sendTextTextBox;
        Button sendButton;

        bool portConnected= false;
        

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="connectDisconnectButton"></param>
        /// <param name="statusTextBlock"></param>
        /// <param name="inputOutputTextBox"></param>
        /// <param name="baudRateComboBox"></param>
        /// <param name="selectSerialPortcomboBox"></param>
        /// <param name="sendTextTextBox"></param>
        /// <param name="sendButton"></param>
        public SerialTerminal(Button connectDisconnectButton, TextBlock statusTextBlock, RichTextBox inputOutputTextBox, ComboBox baudRateComboBox, ComboBox selectSerialPortcomboBox, TextBox sendTextTextBox, Button sendButton)
        {




             
            
            port = new SerialPort();

            this.selectSerialPortComboBox = selectSerialPortcomboBox;
            this.baudRateComboBox = baudRateComboBox;
            this.inputOutputTextBox = inputOutputTextBox;
            this.statusTextBlock = statusTextBlock;
            this.connectDisconnectButton = connectDisconnectButton;
            this.sendTextTextBox = sendTextTextBox;
            this.sendButton = sendButton;

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
            sendButton.Click += SendButtonClick;
            inputOutputTextBox.PreviewKeyDown += TextBoxTerminal_KeyEvent;
            port.DataReceived += TerminalDataReceived;

        }
        /// <summary>
        /// Sends data thought the serial port and show the data on the input output textBox
        /// </summary>
        /// <param name="data"></param>
        private void WriteToTerminal(string data)
        {
            SerialMessages.Add(new SerialText("Computer", data));
            WriteToTextBox(new SerialText("Computer", data));
            port.Write(data);
            


        }
        /// <summary>
        /// Locks the selecion boxes
        /// </summary>
        private void LockUi()
        {
            baudRateComboBox.IsEnabled = false;
            selectSerialPortComboBox.IsEnabled = false;
        }
        /// <summary>
        /// unlocks the selection boxes
        /// </summary>
        private void UnlockUi()
        {
            baudRateComboBox.IsEnabled = true;
            selectSerialPortComboBox.IsEnabled = true;
        }
        /// <summary>
        /// Check if port is connect and the portConnected flag is set
        /// if it is and the port is not connected the terminal closes
        /// 
        /// </summary>
        /// <returns> The state of the terminal </returns>
        private bool IsConnected()
        {
            if(portConnected == true && port.IsOpen == false )
            {
                portConnected = false;
                statusTextBlock.Text = "Port disconnected";
                UnlockUi();
                connectDisconnectButton.Content = "Connect";
                return false;
            }
           else if (portConnected == true && port.IsOpen == true) return true;

           else return false;

        }
        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            if(IsConnected())
            {
                if(!string.IsNullOrEmpty(sendTextTextBox.Text))
                {
                    string data = sendTextTextBox.Text;
                    sendTextTextBox.Clear();
                    WriteToTerminal(data);


                }
            }


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


            if (IsConnected())
            {
                //not to write "Return" on the text box
                if (e.Key == Key.Return)
                {
                    WriteToTerminal("\n");

                }
                else if (Keyboard.IsKeyToggled(Key.CapsLock))
                {
                   
                    WriteToTerminal(e.Key.ToString());

                }
                else
                {
                    WriteToTerminal(e.Key.ToString().ToLower());
                   

                }
                e.Handled = true;

            }
            else
            {
                //if the terminal isn´t open then,the letter wont know on the text box
                e.Handled = true;
            }






        }
        private void ConnectDisconnectButtonClick(object sender , RoutedEventArgs e)
        {
           
            
            if (IsConnected() == false)
            {
                if (selectSerialPortComboBox.SelectedItem is null)
                {
                    statusTextBlock.Text = "Serial port not selected";
                    return;
                }
                if (baudRateComboBox.Text is null || !(int.TryParse(baudRateComboBox.Text, out _)))
                {
                    
                    statusTextBlock.Text = "Invalid baud rate";
                    return;
                }
                int baudRate = int.Parse(baudRateComboBox.Text);
                string serialPortName = (string)selectSerialPortComboBox.SelectedItem;

                try
                {
                    port.PortName = serialPortName;
                    port.BaudRate = baudRate;

                    port.Open();
                    
                    this.portConnected = true;
                }
                catch (Exception exc)
                {
                    statusTextBlock.Text = exc.Message;
                    return;
                }
                statusTextBlock.Text = "Connected \n" + port.PortName + "\n" + baudRate.ToString();

                connectDisconnectButton.Content = "Disconnect";
                LockUi();
            }
            else
            {
                this.portConnected = false;
                port.Close();
                statusTextBlock.Text = "Disconnected";
                connectDisconnectButton.Content = "Connect";
                UnlockUi();
            }
        }
        /// <summary>
        /// receives data trought the serial port and write the data on the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TerminalDataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            String dataFromPort = port.ReadExisting();
            
     
            
            string dataFromPortUTF16 = Convert.ToString(dataFromPort);

            SerialMessages.Add(new SerialText("Device", dataFromPortUTF16));


            inputOutputTextBox.Dispatcher.Invoke(() =>
                {
                    WriteToTextBox(new SerialText("Device", dataFromPortUTF16));

                });
            
        }
        public void UpdatePorts()
        {
            if (!IsConnected())
            {
                selectSerialPortComboBox.Items.Clear();
                string[] portsList = SerialPort.GetPortNames();

                foreach (string port in portsList)
                {
                    selectSerialPortComboBox.Items.Add(port);
                }
            }
        }
        private void WriteToTextBox(SerialText data)
        {

            if (inputOutputTextBox.Document.Blocks.Count == 0) inputOutputTextBox.Document.Blocks.Add(new Paragraph() { LineHeight = 1, });
            
            Paragraph paragraph = (Paragraph)inputOutputTextBox.Document.Blocks.Last();

            if (ShowSenders && (paragraph.Inlines.Count == 0 || SerialMessages[SerialMessages.Count - 2].Sender != data.Sender)) 
            {




                if (paragraph.Inlines.Count > 0 ) paragraph.Inlines.Add(new Run("\n"));
                   

                paragraph.Inlines.Add(new Bold(new Run(data.Sender + "->")));

               
                
            }
            
            
            paragraph.Inlines.Add(new Run(data.Message));

            if (AutoScroll)
            {
                inputOutputTextBox.ScrollToEnd();
                inputOutputTextBox.CaretPosition = inputOutputTextBox.CaretPosition.DocumentEnd;
            }
        
        }

        public void UpdateShowSenders(bool showSenders)
        {
            this.ShowSenders = showSenders;

            //rewrites everyting with or without the senders name
                inputOutputTextBox.Document.Blocks.Clear();

            List<SerialText> temporaryList = new List<SerialText>(SerialMessages);
            SerialMessages.Clear();
                foreach(SerialText text in temporaryList)
                {
                    SerialMessages.Add(text);
                    WriteToTextBox(text);
                }

          
        }
        public void ClearTerminalText()
        {
            inputOutputTextBox.Document.Blocks.Clear();
            SerialMessages.Clear();
        }

        public void SaveData(String directory, String fileName, Encoding encoding,List<String> validSenders,bool showSenders,bool allMessagesNewLineSeparated)
        {
            if (String.IsNullOrEmpty(directory))
            {
                throw new ArgumentException("No directory", nameof(directory));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("Enconding not valid",nameof(encoding));
            }
            if(!Directory.Exists(directory)) throw new ArgumentException("Invalid directory", nameof(directory));
            var fileStream = File.Create((directory +"/"+ fileName));
            List<SerialText> MessagesToSave = new List<SerialText>(SerialMessages.Count);
            foreach (SerialText data in SerialMessages)
            {
                if (validSenders.Contains(data.Sender)) MessagesToSave.Add(data);
               
            }
            

           if (showSenders)
            {
                foreach (SerialText data in MessagesToSave)
                {
                    fileStream.Write(encoding.GetBytes((data.Sender+"->")), 0, encoding.GetByteCount((data.Sender + "->")));
                    fileStream.Write(encoding.GetBytes(data.Message), 0, encoding.GetByteCount(data.Message));
                    if(allMessagesNewLineSeparated) fileStream.Write(encoding.GetBytes("\n"), 0, encoding.GetByteCount("\n"));
                }

            }
       
            else
            {
                foreach (SerialText data in MessagesToSave)
                {

                    fileStream.Write(encoding.GetBytes(data.Message), 0, encoding.GetByteCount(data.Message));
                    if (allMessagesNewLineSeparated) fileStream.Write(encoding.GetBytes("\n"), 0, encoding.GetByteCount("\n"));
                }
            }
           
        }

        
    }




}
