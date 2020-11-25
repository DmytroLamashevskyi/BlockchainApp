using Blockchain;
using BlockchainApp.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {    
        public ObservableCollection<Block<Student>> Students { get => Pool<Student>.Instance().GetList(); }
        public Block<Student> SelectedStudent { set; get; }
        public Visibility AddPanelWidth { set; get; }

        public Student StudentPanel { set; get; }
        public MainWindow()
        {

            AddPanelWidth = Visibility.Collapsed;
            InitializeComponent(); 
            Pool<Student>.Instance().LoadDataFromFile();
            Pool<Student>.Instance().AddBlock(new Student() { Name="Admin", Surname="Admin", Id=0, Birthday=DateTime.Now});

            StudentList.ItemsSource = Pool<Student>.Instance().GetList();
            StudentPanel = new Student();
            OnPropertyChanged("Students");
            OnPropertyChanged("StudentPanel");
            OnPropertyChanged("AddPanelWidth");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        private void OpenData(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent != null)
                return;
            AddPanelWidth = Visibility.Visible;

        }
        
        private void AddData(object sender, RoutedEventArgs e)
        {
            Pool<Student>.Instance().AddBlock(new Student() { Name = "Admin", Surname = "Admin", Id = 0, Birthday = DateTime.Now });
            OnPropertyChanged("Students");
            AddPanelWidth = Visibility.Visible;
            OnPropertyChanged("AddPanelWidth");
        }

    }
}
