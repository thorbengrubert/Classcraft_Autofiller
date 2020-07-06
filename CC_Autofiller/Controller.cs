using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace CC_Autofiller
{
    class Controller
    {
        public static string GetWorksheetName(string gradeType, string timeperiod)
        {
            switch (gradeType)
            {
                case "Mitarbeit":
                    return $"SoMi_Zeichen_{timeperiod}";
                case "Quiz":
                    return "Quiz_Pkte";
                case "Schriftl. Leistung":
                    return $"Schriftlich_{timeperiod}_Übersicht";
                default:
                    return "";
            }
        }

        public static void ReadExcelData(Excel.Application excelApplication, _Worksheet openSheet, List<string> invalidNameEntries, string gradeType, DateTime date, string timePeriod)
        {
            try
            {
                AwardExp(openSheet, invalidNameEntries, gradeType, date, timePeriod);
            }
            catch (NullReferenceException nullNeferenceException)
            {
                string errorMessage = "Ausgewähltes Datum konnte nicht in der Exceltabelle gefunden werden.\n";
                errorMessage = String.Concat(errorMessage, nullNeferenceException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, nullNeferenceException.Source);

                throw new Exception(errorMessage);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                throw new Exception(errorMessage);
            }
            finally
            {
                Controller.FinishAndCleanUpApplications(excelApplication);
            }
        }

        private static void AwardExp(_Worksheet openSheet, List<string> invalidNameEntries, string gradeType, DateTime date, string timePeriod)
        {
            object[,] usernames = ExcelUtilities.Instance.GetUsernames(openSheet, gradeType);
            string nameColumn = ExcelUtilities.Instance.GetNameColumn(gradeType);
            int nameRowBeginning = ExcelUtilities.Instance.GetNameRowBeginning(gradeType);
            string relevantDataColumn = ExcelUtilities.Instance.GetRelevantDataColumn(openSheet, gradeType, date);

            for (int i = 0; i < usernames.GetLength(0); i++)
            {
                if (invalidNameEntries.IndexOf($"{usernames[i + 1, 1]}") == -1)
                {
                    string username = openSheet.get_Range(string.Concat(nameColumn, nameRowBeginning + i), Missing.Value).Value;
                    switch (gradeType)
                    {
                        case "Mitarbeit":
                            string symbolGrade = openSheet.get_Range(string.Concat(relevantDataColumn, nameRowBeginning + i), Missing.Value).Value;
                            Selenium.Instance.AwardExp(username, symbolGrade);
                            break;
                        case "Schriftl. Leistung":
                            int expFlat = ((int)(openSheet.get_Range(string.Concat(relevantDataColumn, nameRowBeginning + i), Missing.Value).Value));
                            string expDescription = GetExpDescription(gradeType, timePeriod);
                            if (expFlat >= 0)
                            {
                                Selenium.Instance.AwardExp(username, expFlat.ToString(), expDescription);
                            }
                            break;
                        default:
                            break;
                    }


                }
            }
        }
        private static string GetExpDescription(string gradeType, string timePeriod)
        {
            return $"{gradeType}_{timePeriod}";
        }

        public static void FinishAndCleanUpApplications(Excel.Application excelApplication)
        {
            excelApplication.Quit();
            Selenium.Instance.FinishSession();
        }
    }
}
