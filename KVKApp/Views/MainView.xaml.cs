using KVKApp.Models;
using KVKApp.Services.Api;
using KVKApp.Services.Export;
using KVKApp.ViewModels;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;


namespace KVKApp.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : System.Windows.Window
    {
        MainViewModel mvm;
        List<string> branchNumbers = new List<string> { "56", "561", "5610", "56101", "56102", "56103", "562", "5621", "5629", "563" };

        public MainView()
        {
            InitializeComponent();
            mvm = new MainViewModel(new ApiService(), new ExcelService());
            this.DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
