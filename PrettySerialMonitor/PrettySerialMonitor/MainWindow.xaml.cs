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
using MahApps.Metro.Controls;
using MahApps.Metro;

namespace PrettySerialMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    




    public partial class MainWindow : MetroWindow
    {
        

        const int uiElementsPerTerminal = 7;


        FrameworkElement[] uIElementsTerminals;


        SerialTerminal terminal;



        public MainWindow()
        {

            InitializeComponent();


            
        
//////Inicializing array that contains the UI elements for all terminals,to make it easier to change the positions
            uIElementsTerminals = new FrameworkElement[ 7];

            uIElementsTerminals[ 0] = ComboBoxBaudRateTerminal;
            uIElementsTerminals[ 1] = ComboBoxComPortSelectorTerminal;        
            uIElementsTerminals[ 2] = StateTextBlockTerminal;    
            uIElementsTerminals[ 3] = ConnectButtonTerminal;    
            uIElementsTerminals[ 4] = TextBoxTerminal;        
            uIElementsTerminals[ 5] = TerminalSendTextBox;
            uIElementsTerminals[ 6] = TerminalSendButton;
            
            ////////////////////////////////////////////////////////////////////////////////////////////

            //////Hiding all ui elementos that belong to the terminals

            foreach (FrameworkElement element in uIElementsTerminals)
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
            
            
                terminal =new SerialTerminal(ConnectButtonTerminal, StateTextBlockTerminal, TextBoxTerminal, ComboBoxBaudRateTerminal, ComboBoxComPortSelectorTerminal,TerminalSendTextBox,TerminalSendButton);
                UpdateTerminalSizesPositions();

                for (int i = 0; i < uiElementsPerTerminal; i++) uIElementsTerminals[ i].Visibility = Visibility.Visible;

                return;

            }
           
        private void AddTerminal(object sender, RoutedEventArgs e)
        {
            AddTerminal();
        }


        private void UpdateTerminalSizesPositions()
        {
            //The Height it´s the same for all
            TextBoxTerminal.Height = this.ActualHeight - TextBoxTerminal.Margin.Top - 100;
      


                TextBoxTerminal.Width = this.ActualWidth - 30;


               
                

                updateOtherUiElements();
      
            


            void updateOtherUiElements()
            {
                
                    for(int element=0;element<5;++element)
                    {
                     Thickness thic = uIElementsTerminals[element].Margin;
                        thic.Left = uIElementsTerminals[ 4].Margin.Left;
                        uIElementsTerminals[ element].Margin = thic;
                    }
                


                for (int terminal = 0; terminal < 6; ++terminal)
                {
                    uIElementsTerminals[ 5].Width = uIElementsTerminals[ 4].Width - uIElementsTerminals[ 6].Width;


                    uIElementsTerminals[ 5].Margin = new Thickness(
                    uIElementsTerminals[ 4].Margin.Left,
                    (uIElementsTerminals[ 4].Margin.Top + uIElementsTerminals[ 4].Height),
                    0,
                    0);
                    uIElementsTerminals[ 6].Margin = new Thickness(
                        (uIElementsTerminals[ 4].Margin.Left + uIElementsTerminals[ 5].Width),
                        (uIElementsTerminals[ 4].Margin.Top + uIElementsTerminals[ 4].Height),
                        0,
                        0);

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
            
                terminal.UpdatePorts();
        }

        private void AutoScrollCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
           if(!(terminal is null)) terminal.AutoScroll =(bool) box.IsChecked;
        }

        private void ShowSendersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (!(terminal is null)) terminal.UpdateShowSenders((bool)box.IsChecked);

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if(!(terminal is null))terminal.ClearTerminalText();
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {

            terminal.SaveData(System.IO.Directory.GetCurrentDirectory(), "TESTE321.txt", Encoding.UTF8, new string[2] { "Computer", "Device" }, true,true);           
            if(!(terminal is null))
                {
                SaveDataWindow window = new SaveDataWindow(terminal);
                window.Show();
            }

          
           

        }
    }
}
