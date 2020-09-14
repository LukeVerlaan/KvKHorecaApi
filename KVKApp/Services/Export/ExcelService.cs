using KVKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KVKApp.Services.Export
{
    public class ExcelService : IExcelService
    {
        public async Task ExportToExcel(string filePath, IEnumerable<Company> companies)
        {

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                //    //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "KvK Nummer";
                oSheet.Cells[1, 2] = "Business Naam";
                oSheet.Cells[1, 3] = "Adres";
                oSheet.Cells[1, 4] = "Branche Nummer";
                oSheet.Cells[1, 5] = "RSIN";
                oSheet.Cells[1, 6] = "HasEntryInBusinessRegister";
                oSheet.Cells[1, 7] = "HasNOnMailingIndication";
                oSheet.Cells[1, 8] = "IsLegalPerson";
                oSheet.Cells[1, 9] = "IsBranch";
                oSheet.Cells[1, 10] = "IsMainBranch";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "J1").Font.Bold = true;
                oSheet.get_Range("A1", "J1").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                // Create an array to multiple values at once.
                string[,] saNames = new string[5, 10];

                int teller = 0;
                foreach (var i in companies)
                {
                    if (i != null)
                    {
                        saNames[teller, 0] = i.KvkNumber;
                        saNames[teller, 1] = i.TradeNames.BusinessName;
                        saNames[teller, 2] = i.Addresses[0].FullAddress;
                        saNames[teller, 3] = i.BranchNumber;
                        saNames[teller, 4] = i.RSIN;
                        saNames[teller, 5] = i.HasEntryInBusinessRegister.ToString();
                        saNames[teller, 6] = i.HasNonMailingIndication.ToString();
                        saNames[teller, 7] = i.IsLegalPerson.ToString();
                        saNames[teller, 8] = i.IsBranch.ToString();
                        saNames[teller, 9] = i.IsMainBranch.ToString();
                        teller += 1;
                    }
                }

                //Fill A2:B6 with an array of values (First and Last Names).
                oSheet.get_Range("A2", "J6").Value2 = saNames;

                //AutoFit columns A:J.
                oRng = oSheet.get_Range("A1", "J1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
                oXL.Quit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
