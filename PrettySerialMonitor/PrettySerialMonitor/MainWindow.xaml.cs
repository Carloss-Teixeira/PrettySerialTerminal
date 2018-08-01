using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace PrettySerialMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    




    public partial class MainWindow : Window
    {
        SerialPort terminal1;
        SerialPort terminal2;
        SerialPort terminal3;
        SerialPort terminal4;
        SerialPort terminal5;

     

        public MainWindow()
        {
            


            InitializeComponent();

            string[] portsList = SerialPort.GetPortNames();

            foreach (string port in portsList)
            {
                ComboBoxComPortSelectorTerminal1.Items.Add(port);
                ComboBoxComPortSelectorTerminal2.Items.Add(port);
                ComboBoxComPortSelectorTerminal3.Items.Add(port);
                ComboBoxComPortSelectorTerminal4.Items.Add(port);
                ComboBoxComPortSelectorTerminal5.Items.Add(port);
            }
            ComboBoxBaudRateTerminal1.Items.Add("9600");
            ComboBoxBaudRateTerminal1.Items.Add("19200");
            ComboBoxBaudRateTerminal1.Items.Add("38400");
            ComboBoxBaudRateTerminal1.Items.Add("57600");
            ComboBoxBaudRateTerminal1.Items.Add("115200");

            ComboBoxBaudRateTerminal2.Items.Add("9600");
            ComboBoxBaudRateTerminal2.Items.Add("19200");
            ComboBoxBaudRateTerminal2.Items.Add("38400");
            ComboBoxBaudRateTerminal2.Items.Add("57600");
            ComboBoxBaudRateTerminal2.Items.Add("115200");

            ComboBoxBaudRateTerminal3.Items.Add("9600");
            ComboBoxBaudRateTerminal3.Items.Add("19200");
            ComboBoxBaudRateTerminal3.Items.Add("38400");
            ComboBoxBaudRateTerminal3.Items.Add("57600");
            ComboBoxBaudRateTerminal3.Items.Add("115200");

            ComboBoxBaudRateTerminal4.Items.Add("9600");
            ComboBoxBaudRateTerminal4.Items.Add("19200");
            ComboBoxBaudRateTerminal4.Items.Add("38400");
            ComboBoxBaudRateTerminal4.Items.Add("57600");
            ComboBoxBaudRateTerminal4.Items.Add("115200");

            ComboBoxBaudRateTerminal5.Items.Add("9600");
            ComboBoxBaudRateTerminal5.Items.Add("19200");
            ComboBoxBaudRateTerminal5.Items.Add("38400");
            ComboBoxBaudRateTerminal5.Items.Add("57600");
            ComboBoxBaudRateTerminal5.Items.Add("115200");


        }

        private void ConnectToSerialPort(Button button_)
        {
          

            switch(button_.Name)
            {
                case "ConnectButtonTerminal1":
                    {
                       
                        inicialize_Serialport(ref terminal1,
                            ComboBoxBaudRateTerminal1,
                            ComboBoxComPortSelectorTerminal1,
                            button_,
                            StateTextBlockTerminal1);
                        break;
                    }
                case "ConnectButtonTerminal2":
                    {

                        inicialize_Serialport(ref terminal2,
                            ComboBoxBaudRateTerminal2,
                            ComboBoxComPortSelectorTerminal2,
                            button_,
                            StateTextBlockTerminal2);
                        break;
                    }
                case "ConnectButtonTerminal3":
                    {

                        inicialize_Serialport(ref terminal3,
                            ComboBoxBaudRateTerminal3,
                            ComboBoxComPortSelectorTerminal3,
                            button_,
                            StateTextBlockTerminal3);
                        break;
                    }
                case "ConnectButtonTerminal4":
                    {

                        inicialize_Serialport(ref terminal4,
                            ComboBoxBaudRateTerminal4,
                            ComboBoxComPortSelectorTerminal4,
                            button_,
                            StateTextBlockTerminal4);
                        break;
                    }
                case "ConnectButtonTerminal5":
                    {

                        inicialize_Serialport(ref terminal5,
                            ComboBoxBaudRateTerminal5,
                            ComboBoxComPortSelectorTerminal5,
                            button_,
                            StateTextBlockTerminal5);
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            void inicialize_Serialport(ref SerialPort terminal,
                ComboBox ComboBoxBaudRateTerminal,
                ComboBox ComboBoxComPortSelectorTerminal,
                Button ConnectButtonTerminal,TextBlock StateTextBlockTerminal)
            {
                if (terminal is null) terminal = new SerialPort();
                if (terminal.IsOpen == false)
                {


                    string baudRateStringForm = (string)ComboBoxBaudRateTerminal.SelectedValue;
                    bool correctlyParsed = int.TryParse(baudRateStringForm, out int baudRate);
                    if (correctlyParsed == false)
                    {
                       StateTextBlockTerminal.Text = "Invalid BaudRate";
                        return;
                    }
                    else
                    {
                        terminal.BaudRate = baudRate;
                        terminal.PortName = ComboBoxComPortSelectorTerminal.Text;
                        try
                        {
                          
                            terminal.Open();
                            StateTextBlockTerminal.Text = "Connected";
                            ConnectButtonTerminal.Content = "Disconnect";

                            terminal.DataReceived += new SerialDataReceivedEventHandler(TerminalDataReceived);
                        }
                        catch (UnauthorizedAccessException)
                        {

                            StateTextBlockTerminal.Text = "Access not permited";
                        }
                        catch(InvalidOperationException e)
                        {
                            StateTextBlockTerminal.Text = e.Message;
                        }
                    }
                }
                else
                {
                    terminal.Close();
                    ConnectButtonTerminal.Content = "Connect";
                    StateTextBlockTerminal.Text = "Disconnected";
                }
            }
        }


        private void ConnectButtonTerminal_Click(object sender, RoutedEventArgs e)
        {
            ConnectToSerialPort((Button)sender);
        }
        private void TerminalDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port =(SerialPort) sender;

          string dataFromPort =  port.ReadExisting();
           string dataFromPortUTF16 = Convert.ToString(dataFromPort);
           
            this.Dispatcher.Invoke(() =>
            {
                TextBoxTerminal1.AppendText(dataFromPortUTF16);
               
            });
        }

        private void TextBoxTerminal_KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete ||e.Key == Key.CapsLock || e.Key == Key.NumLock)
            {
                e.Handled = true;
                return;
            }

         


            TextBox text = (TextBox)sender; 

           switch (text.Name)
            {
                case "TextBoxTerminal1":
                    {
                       if(!(terminal1 is null) && terminal1.IsOpen == true)
                        {
                            if (Keyboard.IsKeyToggled(Key.CapsLock))
                            {
                                terminal1.Write(e.Key.ToString());
                            }
                            else
                            {
                                terminal1.Write(e.Key.ToString().ToLower());
                            }
                        }
                       else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case "TextBoxTerminal2":
                    {
                        if (!(terminal2 is null) && terminal2.IsOpen == true)
                        {
                            if (Keyboard.IsKeyToggled(Key.CapsLock))
                            {
                                terminal2.Write(e.Key.ToString());
                            }
                            else
                            {
                                terminal2.Write(e.Key.ToString().ToLower());
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case "TextBoxTerminal3":
                    {
                        if (!(terminal3 is null) && terminal3.IsOpen == true)
                        {
                            if (Keyboard.IsKeyToggled(Key.CapsLock))
                            {
                                terminal3.Write(e.Key.ToString());
                            }
                            else
                            {
                                terminal3.Write(e.Key.ToString().ToLower());
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case "TextBoxTerminal4":
                    {
                        if (!(terminal4 is null) && terminal4.IsOpen == true)
                        {
                            if (Keyboard.IsKeyToggled(Key.CapsLock))
                            {
                                terminal4.Write(e.Key.ToString());
                            }
                            else
                            {
                                terminal4.Write(e.Key.ToString().ToLower());
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
                case "TextBoxTerminal5":
                    {
                        if (!(terminal5 is null) && terminal5.IsOpen == true)
                        {
                            if (Keyboard.IsKeyToggled(Key.CapsLock))
                            {
                                terminal5.Write(e.Key.ToString());
                            }
                            else
                            {
                                terminal5.Write(e.Key.ToString().ToLower());
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                        break;
                    }
            }
            
        }


    }
}
