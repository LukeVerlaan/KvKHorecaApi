using KVKApp.Models;
using KVKApp.Services.Api;
using KVKApp.Services.Export;
using KVKApp.ViewModels.Base;
using Microsoft.Win32;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Microsoft.Office.Interop.Excel;

namespace KVKApp.ViewModels
{    
    public class MainViewModel : ViewModelBase
    {
        IEnumerable<Company> companies;
        bool buttonPrintEnabled;
        string filePath;


        readonly IApiService apiService;
        readonly IExcelService excelService;
        
        public MainViewModel(IApiService apiService, IExcelService excelService)
        {
            this.apiService = apiService;
            this.excelService = excelService;
            buttonPrintEnabled = false;
        }

        public IEnumerable<Company> Companies
        {
            get => companies;
            set => SetProperty(ref companies, value);
        }

        public bool ButtonPrintEnabled
        {
            get => buttonPrintEnabled;
            set => SetProperty(ref buttonPrintEnabled, value);
        }

        public ICommand ApiCommand => new AsyncCommand(OnApiAsync);

        public ICommand PrintCommand => new AsyncCommand(OnPrintAsync);

        async Task OnApiAsync()
        {
            Companies = await apiService.Sync();
            ButtonPrintEnabled = true;
        }

        async Task OnPrintAsync()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
                filePath = saveFileDialog.FileName;

            if (saveFileDialog.FilterIndex == 1)
            {
                await excelService.ExportToExcel(filePath, companies);
            }            
        }
    }
}
