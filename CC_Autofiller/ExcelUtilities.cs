using Microsoft.Office.Interop.Excel;
using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace CC_Autofiller
{
    class ExcelUtilities
    {
        private static readonly ExcelUtilities instance = new ExcelUtilities();
        private Excel.Application oXL;
        private Excel._Workbook oWB;
        private Excel._Worksheet oSheet;

        static ExcelUtilities() { }

        private ExcelUtilities()
        {
            oXL = new Excel.Application();
            oXL.Visible = false;
        }

        public static ExcelUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private void OpenWorkbook(string filename)
        {
            oWB = (Excel._Workbook)(oXL.Workbooks.Open(filename));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        }

        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public object[,] GetUsernames(_Worksheet openSheet, string gradeType)
        {
            string nameColumn = GetNameColumn(gradeType);
            int nameRowBeginning = GetNameRowBeginning(gradeType);

            return openSheet.get_Range(string.Concat(nameColumn, nameRowBeginning), string.Concat(nameColumn, 3 + 50)).Cells.Value;

        }

        public string GetNameColumn(string gradeType)
        {
            switch (gradeType)
            {
                case "Mitarbeit":
                    return "C";
                case "Schriftl. Leistung":
                    return "E";
                default:
                    return "";
            }
        }

        public int GetNameRowBeginning(string gradeType)
        {
            switch (gradeType)
            {
                case "Mitarbeit":
                    return 3;
                case "Schriftl. Leistung":
                    return 2;
                default:
                    return 0;
            }
        }

        public string GetRelevantDataColumn(_Worksheet openSheet, string gradeType, DateTime date)
        {
            string rangeBeginning = default;
            string rangeEnd = default;

            switch (gradeType)
            {
                case "Mitarbeit":
                    rangeBeginning = "E1";
                    rangeEnd = "AK1";
                    break;
                case "Schriftl. Leistung":
                    return "K";
                default:
                    break;
            }
            Excel.Range columnRange = openSheet.get_Range(rangeBeginning, rangeEnd);
            Excel.Range currentDataColumnRange = columnRange.Find(date.ToShortDateString());

            return ExcelUtilities.GetExcelColumnName(currentDataColumnRange.Column);
        }

        public void OpenExcelWorksheet(string worksheetName, out Excel.Application excelApplication, out _Worksheet openSheet, string fileName)
        {
            Excel._Workbook openWorkbook;

            excelApplication = new Excel.Application
            {
                Visible = false,
                DisplayAlerts = false
            };

            try
            {
                openWorkbook = (Excel._Workbook)(excelApplication.Workbooks.Open(fileName, UpdateLinks: 2));
            }
            catch (Exception)
            {
                excelApplication.Quit();
                throw new Exception("Bitte eine gültige Excel-Datei auswählen.");
            }


            Excel.Sheets excelSheets = openWorkbook.Worksheets;
            if (worksheetName != string.Empty)
            {
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(worksheetName);
                excelWorksheet.Activate();
            }
            openSheet = (Excel._Worksheet)openWorkbook.ActiveSheet;
        }
    }
}
