using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Globalization;
using Microsoft.Office.Interop.Excel;

namespace ExcelWrapper
{
    public class ExcelSpreadsheet
    {
        private Application excelApplication;
        private Workbook workbook;
        private Worksheet worksheet;
        private Window mainWindow;

        private Dictionary<string, XlPattern> namePatternMap;
        private Dictionary<string, XlLineStyle> nameLineStyleMap;
        private Dictionary<string, XlBorderWeight> nameBorderWeightMap;
        private Dictionary<string, XlHAlign> nameHAlignMap;
        private Dictionary<string, XlVAlign> nameVAlignMap;

        public ExcelSpreadsheet(string filePath)
        {

        }

        public ExcelSpreadsheet(bool displayGridLines)
        {
            Initialize();

            excelApplication = new Application();

            // passing xlWBATWorksheet from XlWBATemplate enumeration as parameter
            // based on Workbooks.Add Method (http://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel.workbooks.add%28v=office.11%29.aspx)
            workbook = excelApplication.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            mainWindow = workbook.Windows[1];
            mainWindow.DisplayGridlines = displayGridLines;

            // index starts on 1
            worksheet = (Worksheet)workbook.Worksheets[1];
        }

        private void Initialize()
        {
            namePatternMap = new Dictionary<string, XlPattern>();
            namePatternMap.Add("25% Gray", XlPattern.xlPatternGray25);

            nameLineStyleMap = new Dictionary<string, XlLineStyle>();
            nameLineStyleMap.Add("Continuous", XlLineStyle.xlContinuous);
            nameLineStyleMap.Add("Dot", XlLineStyle.xlDot);

            nameBorderWeightMap = new Dictionary<string, XlBorderWeight>();
            nameBorderWeightMap.Add("Thin", XlBorderWeight.xlThin);
            nameBorderWeightMap.Add("HairLine", XlBorderWeight.xlHairline);

            nameHAlignMap = new Dictionary<string, XlHAlign>();
            nameHAlignMap.Add("Center", XlHAlign.xlHAlignCenter);

            nameVAlignMap = new Dictionary<string, XlVAlign>();
            nameVAlignMap.Add("Center", XlVAlign.xlVAlignCenter);
        }

        public void Show()
        {
            excelApplication.Visible = true;
        }

        public void Save(string path, string entity, DateTime date)
        {
            workbook.Saved = true; 
            workbook.SaveCopyAs(path);
        }

        public void Close()
        {
            workbook.Close(true, Type.Missing, Type.Missing); 
            workbook = null;
            excelApplication.Quit();
            excelApplication = null;
        }

        public void SetZoom(int zoomPercentage)
        {
            mainWindow.Zoom = zoomPercentage;
        }

        public void FreezePanes(int splitRow, int scrollRow, int splitColumn, int scrollColumn)
        {
            mainWindow.SplitRow = splitRow;
            mainWindow.ScrollRow = scrollRow;
            mainWindow.SplitColumn = splitColumn;
            mainWindow.ScrollColumn = scrollColumn;
            mainWindow.FreezePanes = true;
        }

        public void SetFont(string startCell, string endCell, string family, int size)
        {
            Range range = worksheet.get_Range(startCell, endCell);
            range.Font.Name = family;
            range.Font.Size = size;
        }

        public void SetFontStyle(string startCell, string endCell, bool bold, bool underline, string color)
        {
            Range range = worksheet.get_Range(startCell, endCell);
            range.Font.Bold = bold;
            range.Font.Underline = underline;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(color));            
        }

        public void SetBackgroundColor(string startCell, string endCell, string color)
        {
            Range range = worksheet.get_Range(startCell, endCell);
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(color));            
        }

        public void SetNumberFormat(string startCell, string endCell, string numberFormat)
        {
            Range range = worksheet.get_Range(startCell, endCell);
            range.NumberFormat = numberFormat;
        }

        public void SetPattern(string startCell, string endCell, string pattern)
        {
            Range range = worksheet.get_Range(startCell, endCell);

            try
            {
                XlPattern xlPattern = namePatternMap[pattern];
                range.Interior.Pattern = xlPattern;
            }
            catch
            {
                range.Interior.Pattern = XlPattern.xlPatternSolid;
            }
        }

        public void InsertPicture(string path, float left, float top, float width, float height)
        {
            worksheet.Shapes.AddPicture(path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue,
                left, top, width, height);
        }

        public void SetText(string cell, string text)
        {
            Range range = worksheet.get_Range(cell, cell);
            range.Cells[1,1] = text;
        }

        public void SetFormula(string cell, string formula)
        {
            Range range = worksheet.get_Range(cell, cell);
            range.Formula = formula;
        }

        public void SetBorderAround(string startCell, string endCell, string lineStyle, string borderWeight, string borderColorName)
        {
            Range range = worksheet.get_Range(startCell, endCell);

            try
            {
                object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(borderColorName));
                range.BorderAround(nameLineStyleMap[lineStyle], nameBorderWeightMap[borderWeight], XlColorIndex.xlColorIndexAutomatic, borderColor);
            }
            catch
            {
                object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName("Black"));
                range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, borderColor);
            }
        }

        public void SetBorderInternal(string startCell, string endCell, string lineStyle, string borderWeight, string borderColorName)
        {
            Range range = worksheet.get_Range(startCell, endCell);

            try
            {
                object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(borderColorName));
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = nameLineStyleMap[lineStyle];
                range.Borders[XlBordersIndex.xlInsideHorizontal].Weight = nameBorderWeightMap[borderWeight];
                range.Borders[XlBordersIndex.xlInsideHorizontal].Color = borderColor;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = nameLineStyleMap[lineStyle];
                range.Borders[XlBordersIndex.xlInsideVertical].Weight = nameBorderWeightMap[borderWeight];
                range.Borders[XlBordersIndex.xlInsideVertical].Color = borderColor;
            }
            catch
            {
                object borderColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName("Black"));
                range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, borderColor);
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlDot;
                range.Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlHairline;
                range.Borders[XlBordersIndex.xlInsideHorizontal].Color = borderColor;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlDot;
                range.Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlHairline;
                range.Borders[XlBordersIndex.xlInsideVertical].Color = borderColor;
            }
        }

        public void SetHorizontalAlignment(string startCell, string endCell, string hAlign)
        {
            Range range = worksheet.get_Range(startCell, endCell);            

            try
            {
                range.HorizontalAlignment = nameHAlignMap[hAlign];
            }
            catch
            {
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
        }

        public void SetVerticalAlignment(string startCell, string endCell, string vAlign)
        {
            Range range = worksheet.get_Range(startCell, endCell);

            try
            {
                range.VerticalAlignment = nameVAlignMap[vAlign];
            }
            catch
            {
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;
            }
        }

        public void AutoFitRow(string cell)
        {
            Range range = worksheet.get_Range(cell, cell);
            range.EntireRow.AutoFit();
        }

        public void AutoFitColumn(string cell)
        {
            Range range = worksheet.get_Range(cell, cell);
            range.EntireColumn.AutoFit();
        }

        public void SetRowHeight(string cell, float height)
        {
            Range range = worksheet.get_Range(cell, cell);
            range.RowHeight = height;
        }

        public void SetColumnWidth(string cell, float width)
        {
            Range range = worksheet.get_Range(cell, cell);
            range.ColumnWidth = width;
        }
    }
}
}
