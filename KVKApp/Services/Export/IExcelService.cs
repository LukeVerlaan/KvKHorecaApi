using KVKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KVKApp.Services.Export
{
    public interface IExcelService
    {
        Task ExportToExcel(string filePath, IEnumerable<Company> companies);
    }
}
