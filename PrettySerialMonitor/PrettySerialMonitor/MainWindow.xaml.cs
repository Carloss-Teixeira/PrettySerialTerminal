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
        FrameworkElement[,] uIElementsTerminals;


        List<SerialTerminal> terminals;



        public MainWindow()
        {
            
            

            InitializeComponent();
            terminals = new List<SerialTerminal>(6);

//////Inicializing array that contains the UI elements for all terminals,to make it easier to change the positions
            uIElementsTerminals = new FrameworkElement[6, 5];


            uIElementsTerminals[0, 0] = ComboBoxBaudRateTerminal1;
            uIElementsTerminals[1, 0] = ComboBoxBaudRateTerminal2;
            uIElementsTerminals[2, 0] = ComboBoxBaudRateTerminal3;
            uIElementsTerminals[3, 0] = ComboBoxBaudRateTerminal4;
            uIElementsTerminals[4, 0] = ComboBoxBaudRateTerminal5;
            uIElementsTerminals[5, 0] = ComboBoxBaudRateTerminal6;

            uIElementsTerminals[0, 1] = ComboBoxComPortSelectorTerminal1;
            uIElementsTerminals[1, 1] = ComboBoxComPortSelectorTerminal2;
            uIElementsTerminals[2, 1] = ComboBoxComPortSelectorTerminal3;
            uIElementsTerminals[3, 1] = ComboBoxComPortSelectorTerminal4;
            uIElementsTerminals[4, 1] = ComboBoxComPortSelectorTerminal5;
            uIElementsTerminals[5, 1] = ComboBoxComPortSelectorTerminal6;

            uIElementsTerminals[0, 2] = StateTextBlockTerminal1;
            uIElementsTerminals[1, 2] = StateTextBlockTerminal2;
            uIElementsTerminals[2, 2] = StateTextBlockTerminal3;
            uIElementsTerminals[3, 2] = StateTextBlockTerminal4;
            uIElementsTerminals[4, 2] = StateTextBlockTerminal5;
            uIElementsTerminals[5, 2] = StateTextBlockTerminal6;

            uIElementsTerminals[0, 3] = ConnectButtonTerminal1;
            uIElementsTerminals[1, 3] = ConnectButtonTerminal2;
            uIElementsTerminals[2, 3] = ConnectButtonTerminal3;
            uIElementsTerminals[3, 3] = ConnectButtonTerminal4;
            uIElementsTerminals[4, 3] = ConnectButtonTerminal5;
            uIElementsTerminals[5, 3] = ConnectButtonTerminal6;

            uIElementsTerminals[0, 4] = TextBoxTerminal1;
            uIElementsTerminals[1, 4] = TextBoxTerminal2;
            uIElementsTerminals[2, 4] = TextBoxTerminal3;
            uIElementsTerminals[3, 4] = TextBoxTerminal4;
            uIElementsTerminals[4, 4] = TextBoxTerminal5;
            uIElementsTerminals[5, 4] = TextBoxTerminal6;

////////////////////////////////////////////////////////////////////////////////////////////
           
//////Hiding all ui elementos that belong to the terminals

            foreach(FrameworkElement element in uIElementsTerminals)
            {
                element.Visibility = Visibility.Hidden;
            }
////////////////////////////////////////////////////////////////////

///////////for when the window changes the sizes and posions of the terminals are updates
            this.SizeChanged += UpdateTerminalSizesPositions;
            this.StateChanged += UpdateTerminalSizesPositions;
            //////////////////////////////////////////////////////////   


            //Add the first terminal

            this.Loaded += AddTerminal;
            ///////////////////////////////////////////////////////////
        }
        private void AddTerminal()
        {
            if (terminals.Count == 0)
            {
                terminals.Add(new SerialTerminal(ConnectButtonTerminal1, StateTextBlockTerminal1, TextBoxTerminal1, ComboBoxBaudRateTerminal1, ComboBoxComPortSelectorTerminal1));
                UpdateTerminalSizesPositions();

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
                UpdateTerminalSizesPositions();

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
                UpdateTerminalSizesPositions();

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
                UpdateTerminalSizesPositions();

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
                UpdateTerminalSizesPositions();
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
                UpdateTerminalSizesPositions();

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
        private void AddTerminal(object sender, RoutedEventArgs e)
        {
            AddTerminal();
        }


        private void UpdateTerminalSizesPositions()
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

                updateOtherUiElements();
            }

            if (terminals.Count == 2)
            {


                TextBoxTerminal1.Width = (this.ActualWidth / 2) - 20;


                Thickness thickness = TextBoxTerminal2.Margin;
                thickness.Left = TextBoxTerminal1.Margin.Left + TextBoxTerminal1.Width + 10;
                TextBoxTerminal2.Margin = thickness;
                TextBoxTerminal2.Width = (this.ActualWidth / 2) - 20;

                updateOtherUiElements();

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

                updateOtherUiElements();

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

                updateOtherUiElements();

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

                updateOtherUiElements();

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

                updateOtherUiElements();

            }


            void updateOtherUiElements()
            {
                for(int terminal=0;terminal<6; ++terminal)
                {
                    for(int element=0;element<5;++element)
                    {
                     Thickness thic = uIElementsTerminals[terminal, element].Margin;
                        thic.Left = uIElementsTerminals[terminal, 4].Margin.Left;
                        uIElementsTerminals[terminal, element].Margin = thic;
                    }
                }
            }
        }
        private void UpdateTerminalSizesPositions(object sender, SizeChangedEventArgs e)
        {
            UpdateTerminalSizesPositions();
        }
        private void UpdateTerminalSizesPositions(object sender, EventArgs e)
        {
            UpdateTerminalSizesPositions();
        }
        private void AddTerminalButtonClick(object sender, RoutedEventArgs e)
        {
            AddTerminal();
        }


        

        private void RefreshPortsButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (SerialTerminal terminal in terminals)
                terminal.UpdatePorts();
        }
    }
}
