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

namespace Picex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string inifolder = null;
        private string Destfolder = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result.ToString() == "OK")
                {
                    this.Destfolder = dialog.SelectedPath;
                    DestinationPath.Text = this.Destfolder;
                }
                else
                {
                    MessageBox.Show("Please enter path agagin");
                    DestinationPath.Text = "";
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog();
            var result = ofd.ShowDialog();
            if (result == false) return;
            this.inifolder = ofd.FileName;


            TextExtraction Tex = new TextExtraction(this.inifolder, this.Destfolder,null);            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextExtraction Tex = new TextExtraction(null, this.Destfolder,tab2_URL.Text);
        }
    }
}
