using Blockchain;
using BlockchainApp.Models;
using GalaSoft.MvvmLight.Command;
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

namespace BlockchainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {    
        public double AddPanelWidth { set; get; }
        public MainWindow()
        {
            InitializeComponent(); 
            Pool<Student>.Instance().LoadDataFromFile();
        }

        private void OpenData(object sender, RoutedEventArgs e)
        { 
            AddPanelWidth = Double.NaN;
        }
        
        private void AddData(object sender, RoutedEventArgs e)
        {
            AddPanelWidth = Double.NaN;
        }

    }
}
