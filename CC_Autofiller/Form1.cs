using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CC_Autofiller
{
    public partial class Form1 : Form
    {
        //public enum cellErrorEnum
        //{
        //    ErrDiv0 = -2146826281,
        //    ErrNA = -2146826246,
        //    ErrName = -2146826259,
        //    ErrNull = -2146826288,
        //    ErrNum = -2146826252,
        //    ErrRef = -2146826265,
        //    ErrValue = -2146826273,
        //}

        public Form1()
        {
            InitializeComponent();
            FillGradeTypeComboBox();
            FillClassComboBox();
            dateTimePicker.Value = DateTime.Today;
        }

        private void FillGradeTypeComboBox()
        {
            List<string> gradeTypes = new List<string>
            {
                "Mitarbeit", "Quiz", "Schriftl. Leistung"
            };

            var bindingSource2 = new BindingSource
            {
                DataSource = gradeTypes
            };

            this.gradeTypeComboBox.DataSource = bindingSource2.DataSource;
        }

        private void FillClassComboBox()
        {
            List<Class> classes = new List<Class> { new Class("Klasse1"),
                                     new Class("Klasse2"),
                                     new Class("Klasse3"),
                                     new Class("Klasse4") };

            var bindingSource1 = new BindingSource
            {
                DataSource = classes
            };

            this.classesComboBox.DataSource = bindingSource1.DataSource;

            this.classesComboBox.DisplayMember = "Name";
            this.classesComboBox.ValueMember = "Name";
        }

        private void FillTimePeriodComboBox(string selectedGradeType)
        {
            var timeperiods = new List<string>();

            switch (selectedGradeType)
            {
                case "Mitarbeit":
                    timeperiods.AddRange(new List<string> { "HJ1", "HJ2" });
                    break;
                case "Quiz":
                    timeperiods.Add("n/a");
                    break;
                case "Schriftl. Leistung":
                    timeperiods.AddRange(new List<string> { "Q1", "Q2", "Q3", "Q4" });
                    break;
                default:
                    break;
            }

            var bindingSource2 = new BindingSource
            {
                DataSource = timeperiods
            };

            this.timePeriodComboBox.DataSource = bindingSource2.DataSource;
        }
        private void GradeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTimePeriodComboBox(gradeTypeComboBox.Text);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Selenium.Instance.LogIn(usernameTextBox.Text, passwordTextBox.Text);
            Selenium.Instance.SelectClassInCC(classesComboBox.Text);

            string worksheetName = Controller.GetWorksheetName(gradeTypeComboBox.Text, timePeriodComboBox.Text);

            ExcelUtilities.Instance.OpenExcelWorksheet(worksheetName, out Excel.Application excelApplication, out _Worksheet openSheet, ExcelOpenFileDialog.FileName);

            List<string> invalidNameEntries = new List<string> { String.Empty, "#NV", "\"\"", "0" };

            Controller.ReadExcelData(excelApplication, openSheet, invalidNameEntries, gradeTypeComboBox.Text, dateTimePicker.Value, timePeriodComboBox.Text);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            this.ExcelOpenFileDialog.FileName = String.Empty;

            DialogResult result = this.ExcelOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (this.ExcelOpenFileDialog.FileName != String.Empty)
                {
                    this.fileDirectoryTextBox.Text = Path.GetFileName(this.ExcelOpenFileDialog.FileName);
                }
                else
                {
                    string errorMessage = "Bitte eine gültige Datei auswählen";
                    MessageBox.Show(errorMessage);
                }

            }
        }

        private void OpenExcelButton_Click(object sender, EventArgs e)
        {
            ExcelUtilities.Instance.OpenExcelWorksheet(string.Empty, out _, out _, ExcelOpenFileDialog.FileName);
        }
    }
}
