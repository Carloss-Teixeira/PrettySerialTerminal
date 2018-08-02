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



        List<SerialTerminal> terminals;



        public MainWindow()
        {
            
            

            InitializeComponent();
            terminals = new List<SerialTerminal>(6);

            TextBoxTerminal1.Visibility = Visibility.Hidden;
            TextBoxTerminal2.Visibility = Visibility.Hidden;
            TextBoxTerminal3.Visibility = Visibility.Hidden;
            TextBoxTerminal4.Visibility = Visibility.Hidden;
            TextBoxTerminal5.Visibility = Visibility.Hidden;
            TextBoxTerminal6.Visibility = Visibility.Hidden;

            ConnectButtonTerminal1.Visibility = Visibility.Hidden;
            ConnectButtonTerminal2.Visibility = Visibility.Hidden;
            ConnectButtonTerminal3.Visibility = Visibility.Hidden;
            ConnectButtonTerminal4.Visibility = Visibility.Hidden;
            ConnectButtonTerminal5.Visibility = Visibility.Hidden;
            ConnectButtonTerminal6.Visibility = Visibility.Hidden;

            StateTextBlockTerminal1.Visibility = Visibility.Hidden;
            StateTextBlockTerminal2.Visibility = Visibility.Hidden;
            StateTextBlockTerminal3.Visibility = Visibility.Hidden;
            StateTextBlockTerminal4.Visibility = Visibility.Hidden;
            StateTextBlockTerminal5.Visibility = Visibility.Hidden;
            StateTextBlockTerminal6.Visibility = Visibility.Hidden;

            TextBoxTerminal1.Visibility = Visibility.Hidden;
            TextBoxTerminal2.Visibility = Visibility.Hidden;
            TextBoxTerminal3.Visibility = Visibility.Hidden;
            TextBoxTerminal4.Visibility = Visibility.Hidden;
            TextBoxTerminal5.Visibility = Visibility.Hidden;
            TextBoxTerminal6.Visibility = Visibility.Hidden;

            ComboBoxBaudRateTerminal1.Visibility = Visibility.Hidden;
            ComboBoxBaudRateTerminal2.Visibility = Visibility.Hidden;
            ComboBoxBaudRateTerminal3.Visibility = Visibility.Hidden;
            ComboBoxBaudRateTerminal4.Visibility = Visibility.Hidden;
            ComboBoxBaudRateTerminal5.Visibility = Visibility.Hidden;
            ComboBoxBaudRateTerminal6.Visibility = Visibility.Hidden;

            ComboBoxComPortSelectorTerminal1.Visibility = Visibility.Hidden;
            ComboBoxComPortSelectorTerminal2.Visibility = Visibility.Hidden;
            ComboBoxComPortSelectorTerminal3.Visibility = Visibility.Hidden;
            ComboBoxComPortSelectorTerminal4.Visibility = Visibility.Hidden;
            ComboBoxComPortSelectorTerminal5.Visibility = Visibility.Hidden;
            ComboBoxComPortSelectorTerminal6.Visibility = Visibility.Hidden;

            this.SizeChanged += UpdateTerminalSizes;
            this.StateChanged += UpdateTerminalSizes;
            

        }


        private void UpdateTerminalSizes(object sender, EventArgs e)
        {
            UpdateTerminalSizes();
        }
        private void UpdateTerminalSizes()
        {
            //The Height it´s the same for all
            TextBoxTerminal1.Height = this.ActualHeight - TextBoxTerminal1.Margin.Top - 100;
            TextBoxTerminal2.Height = this.ActualHeight - TextBoxTerminal2.Margin.Top - 100;
            TextBoxTerminal3.Height = this.ActualHeight - TextBoxTerminal1.Margin.Top - 100;
            TextBoxTerminal4.Height = this.ActualHeight - TextBoxTerminal2.Margin.Top - 100;
            TextBoxTerminal5.Height = this.ActualHeight - TextBoxTerminal1.Margin.Top - 100;
            TextBoxTerminal6.Height = this.ActualHeight - TextBoxTerminal2.Margin.Top - 100;

            if (terminals.Count == 1)
            {






                TextBoxTerminal1.Width = this.ActualWidth - 20;
            }

            if (terminals.Count == 2)
            {


                TextBoxTerminal1.Width = (this.ActualWidth / 2) - 20;


                Thickness thickness = TextBoxTerminal2.Margin;
                thickness.Left = TextBoxTerminal1.Margin.Left + TextBoxTerminal1.Width + 10;
                TextBoxTerminal2.Margin = thickness;
                TextBoxTerminal2.Width = (this.ActualWidth / 2) - 20;

            }
            if (terminals.Count == 3)
            {

                TextBoxTerminal1.Width = (this.ActualWidth / 3) - 20;


                Thickness thickness = TextBoxTerminal2.Margin;
                thickness.Left = TextBoxTerminal1.Margin.Left + TextBoxTerminal1.Width + 10;
                TextBoxTerminal2.Margin = thickness;
                TextBoxTerminal2.Width = (this.ActualWidth / 3) - 20;


                thickness = TextBoxTerminal3.Margin;
                thickness.Left = TextBoxTerminal2.Margin.Left + TextBoxTerminal2.Width + 10;
                TextBoxTerminal3.Margin = thickness;
                TextBoxTerminal3.Width = (this.ActualWidth / 3) - 20;
            }

            if (terminals.Count == 4)
            {
                TextBoxTerminal1.Width = (this.ActualWidth / 4) - 20;


                Thickness thickness = TextBoxTerminal2.Margin;
                thickness.Left = TextBoxTerminal1.Margin.Left + TextBoxTerminal1.Width + 10;
                TextBoxTerminal2.Margin = thickness;
                TextBoxTerminal2.Width = (this.ActualWidth / 4) - 20;


                thickness = TextBoxTerminal3.Margin;
                thickness.Left = TextBoxTerminal2.Margin.Left + TextBoxTerminal2.Width + 10;
                TextBoxTerminal3.Margin = thickness;
                TextBoxTerminal3.Width = (this.ActualWidth / 4) - 20;

                thickness = TextBoxTerminal4.Margin;
                thickness.Left = TextBoxTerminal3.Margin.Left + TextBoxTerminal3.Width + 10;
                TextBoxTerminal4.Margin = thickness;
                TextBoxTerminal4.Width = (this.ActualWidth / 4) - 20;
            }

            if (terminals.Count == 5)
            {
                TextBoxTerminal1.Width = (this.ActualWidth / 5) - 20;


                Thickness thickness = TextBoxTerminal2.Margin;
                thickness.Left = TextBoxTerminal1.Margin.Left + TextBoxTerminal1.Width + 10;
                TextBoxTerminal2.Margin = thickness;
                TextBoxTerminal2.Width = (this.ActualWidth / 5) - 20;


                thickness = TextBoxTerminal3.Margin;
                thickness.Left = TextBoxTerminal2.Margin.Left + TextBoxTerminal2.Width + 10;
                TextBoxTerminal3.Margin = thickness;
                TextBoxTerminal3.Width = (this.ActualWidth / 5) - 20;

                thickness = TextBoxTerminal4.Margin;
                thickness.Left = TextBoxTerminal3.Margin.Left + TextBoxTerminal3.Width + 10;
                TextBoxTerminal4.Margin = thickness;
                TextBoxTerminal4.Width = (this.ActualWidth / 5) - 20;


                thickness = TextBoxTerminal5.Margin;
                thickness.Left = TextBoxTerminal4.Margin.Left + TextBoxTerminal4.Width + 10;
                TextBoxTerminal5.Margin = thickness;
                TextBoxTerminal5.Width = (this.ActualWidth / 5) - 20;
            }
            if (terminals.Count == 6)
            {
                TextBoxTerminal1.Width = (this.ActualWidth / 6) - 20;


                Thickness thickness = TextBoxTerminal2.Margin;
                thickness.Left = TextBoxTerminal1.Margin.Left + TextBoxTerminal1.Width + 10;
                TextBoxTerminal2.Margin = thickness;
                TextBoxTerminal2.Width = (this.ActualWidth / 6) - 20;


                thickness = TextBoxTerminal3.Margin;
                thickness.Left = TextBoxTerminal2.Margin.Left + TextBoxTerminal2.Width + 10;
                TextBoxTerminal3.Margin = thickness;
                TextBoxTerminal3.Width = (this.ActualWidth / 6) - 20;

                thickness = TextBoxTerminal4.Margin;
                thickness.Left = TextBoxTerminal3.Margin.Left + TextBoxTerminal3.Width + 10;
                TextBoxTerminal4.Margin = thickness;
                TextBoxTerminal4.Width = (this.ActualWidth / 6) - 20;


                thickness = TextBoxTerminal5.Margin;
                thickness.Left = TextBoxTerminal4.Margin.Left + TextBoxTerminal4.Width + 10;
                TextBoxTerminal5.Margin = thickness;
                TextBoxTerminal5.Width = (this.ActualWidth / 6) - 20;

                thickness = TextBoxTerminal6.Margin;
                thickness.Left = TextBoxTerminal5.Margin.Left + TextBoxTerminal5.Width + 10;
                TextBoxTerminal6.Margin = thickness;
                TextBoxTerminal6.Width = (this.ActualWidth / 6) - 20;
            }
        }
        private void UpdateTerminalSizes(object sender, SizeChangedEventArgs e)
        {
            UpdateTerminalSizes();
        }

        private void AddTerminalButtonClick(object sender, RoutedEventArgs e)
        {
            if(terminals.Count == 0)
            {
                terminals.Add(new SerialTerminal(ConnectButtonTerminal1, StateTextBlockTerminal1, TextBoxTerminal1, ComboBoxBaudRateTerminal1, ComboBoxComPortSelectorTerminal1));
                UpdateTerminalSizes();

                TextBoxTerminal1.Visibility = Visibility.Visible;

                ConnectButtonTerminal1.Visibility = Visibility.Visible;

                StateTextBlockTerminal1.Visibility = Visibility.Visible;

                TextBoxTerminal1.Visibility = Visibility.Visible;

                ComboBoxBaudRateTerminal1.Visibility = Visibility.Visible;

                ComboBoxComPortSelectorTerminal1.Visibility = Visibility.Visible;

                return;

            }
            if (terminals.Count == 1)
            {
                terminals.Add(new SerialTerminal(ConnectButtonTerminal2, StateTextBlockTerminal2, TextBoxTerminal2, ComboBoxBaudRateTerminal2, ComboBoxComPortSelectorTerminal2));
                UpdateTerminalSizes();

                TextBoxTerminal2.Visibility = Visibility.Visible;

                ConnectButtonTerminal2.Visibility = Visibility.Visible;

                StateTextBlockTerminal2.Visibility = Visibility.Visible;

                TextBoxTerminal2.Visibility = Visibility.Visible;

                ComboBoxBaudRateTerminal2.Visibility = Visibility.Visible;

                ComboBoxComPortSelectorTerminal2.Visibility = Visibility.Visible;

                return;

            }
            if (terminals.Count == 2)
            {

                terminals.Add(new SerialTerminal(ConnectButtonTerminal3, StateTextBlockTerminal3, TextBoxTerminal3, ComboBoxBaudRateTerminal3, ComboBoxComPortSelectorTerminal3));
                UpdateTerminalSizes();

                TextBoxTerminal3.Visibility = Visibility.Visible;

                ConnectButtonTerminal3.Visibility = Visibility.Visible;

                StateTextBlockTerminal3.Visibility = Visibility.Visible;

                TextBoxTerminal3.Visibility = Visibility.Visible;

                ComboBoxBaudRateTerminal3.Visibility = Visibility.Visible;

                ComboBoxComPortSelectorTerminal3.Visibility = Visibility.Visible;

                return;
            }
            if (terminals.Count == 3)
            {

                terminals.Add(new SerialTerminal(ConnectButtonTerminal4, StateTextBlockTerminal4, TextBoxTerminal4, ComboBoxBaudRateTerminal4, ComboBoxComPortSelectorTerminal4));
                UpdateTerminalSizes();

                TextBoxTerminal4.Visibility = Visibility.Visible;

                ConnectButtonTerminal4.Visibility = Visibility.Visible;

                StateTextBlockTerminal4.Visibility = Visibility.Visible;

                TextBoxTerminal4.Visibility = Visibility.Visible;

                ComboBoxBaudRateTerminal4.Visibility = Visibility.Visible;

                ComboBoxComPortSelectorTerminal4.Visibility = Visibility.Visible;

                return;
            }
            if (terminals.Count == 4)
            {

                terminals.Add(new SerialTerminal(ConnectButtonTerminal5, StateTextBlockTerminal5, TextBoxTerminal5, ComboBoxBaudRateTerminal5, ComboBoxComPortSelectorTerminal5));
                UpdateTerminalSizes();
                TextBoxTerminal5.Visibility = Visibility.Visible;

                ConnectButtonTerminal5.Visibility = Visibility.Visible;

                StateTextBlockTerminal5.Visibility = Visibility.Visible;

                TextBoxTerminal5.Visibility = Visibility.Visible;

                ComboBoxBaudRateTerminal5.Visibility = Visibility.Visible;

                ComboBoxComPortSelectorTerminal5.Visibility = Visibility.Visible;

                return;
            }
            if (terminals.Count == 5)
            {
                terminals.Add(new SerialTerminal(ConnectButtonTerminal6, StateTextBlockTerminal6, TextBoxTerminal6, ComboBoxBaudRateTerminal6, ComboBoxComPortSelectorTerminal6));
                UpdateTerminalSizes();

                TextBoxTerminal6.Visibility = Visibility.Visible;

                ConnectButtonTerminal6.Visibility = Visibility.Visible;

                StateTextBlockTerminal6.Visibility = Visibility.Visible;

                TextBoxTerminal6.Visibility = Visibility.Visible;

                ComboBoxBaudRateTerminal6.Visibility = Visibility.Visible;

                ComboBoxComPortSelectorTerminal6.Visibility = Visibility.Visible;

                return;

            }
            MessageBox.Show("Max number of terminals is 6", "Why do you need so many terminals?");


        }

        private void RefreshPortsButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (SerialTerminal terminal in terminals)
                terminal.UpdatePorts();
        }
    }
}
