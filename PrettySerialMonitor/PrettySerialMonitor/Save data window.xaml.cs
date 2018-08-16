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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Forms;
using System.IO;
namespace PrettySerialMonitor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SaveDataWindow : MetroWindow
    {
        SerialTerminal terminal;
        public SaveDataWindow(SerialTerminal terminal)
        {
            this.terminal = terminal;
            InitializeComponent();

            DirectoryTextBox.Text   = Directory.GetCurrentDirectory();
            string fileNameDefault = "LogFile";
            FileNameTextBox.Text    =  fileNameDefault +".txt";
        }

        private void DirectorySelectTextBox_Click(object sender, RoutedEventArgs e)
        {
            
           var folderDialog = new FolderBrowserDialog();
           
            folderDialog.ShowDialog();
            DirectoryTextBox.Text = folderDialog.SelectedPath;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var directory       = DirectoryTextBox.Text;
            var fileName        = FileNameTextBox.Text;
            var showSenders     = (bool) ShowSendersCheckBox.IsChecked;
            var NewLine         = (bool)NewLinesCheckBox.IsChecked;
            var SendersToShow   = new List<String>(4);

            if ((bool)Computer1CheckBox.IsChecked) SendersToShow.Add("Computer");
            if ((bool)Terminal1CheckBox.IsChecked) SendersToShow.Add("Device");
            if ((bool)Terminal2CheckBox.IsChecked) SendersToShow.Add("Device2");
            if ((bool)Terminal3CheckBox.IsChecked) SendersToShow.Add("Device3");

            try
            {
               var c= File.Create(directory + @"\" + fileName);
                c.Close();
            }
            catch(Exception e_)
            {
                System.Windows.MessageBox.Show(e_.Message, "Error");
                return;
            }
            terminal.SaveData(directory, fileName, Encoding.UTF8,SendersToShow, true,NewLine);


            this.Close();
        }
    }
}
