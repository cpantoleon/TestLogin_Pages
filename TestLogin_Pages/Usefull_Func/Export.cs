using OpenQA.Selenium;
using System.Reflection.Emit;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Label = ceTe.DynamicPDF.PageElements.Label;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System;
using System.Drawing.Text;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace TestLogin_Pages.Usefull_Func
{
    /*class Validation
    {
        private int _Test;

        public static int val(int x)
        {
            //?????????????????????????????????????????
            return x;
        }

        public int Test
        {
            get { return _Test; }
            set { _Test = 1; }
        }
    } */

    class Export
    {
        
        public static void Login(string Text, string Name, int[] chr, string ex)
        {

            // Create a PDF Document 
            Document document = new Document();

            //Create Time
            DateTime dt=DateTime.Now;

            // Create a Page
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            // Create a text
            string labelText = Text;
            Label label = new Label(labelText, 0, 0, 500, 100, Font.Helvetica, 18, TextAlign.Center);

            Label label2 = new Label(dt.ToString(), 450, -50, 500, 100, Font.Helvetica, 9);
            //Console.WriteLine(dt);
            
            // Create a table
            Table2 table = new Table2(75, 50, 600, 600);
            table.CellDefault.Border.Color = RgbColor.Black;
            table.CellSpacing = 5.0f;

            // Add columns to the table
            table.Columns.Add(50);
            table.Columns.Add(200);
            table.Columns.Add(80);

            // Add rows to the table and add cells to the rows
            Row2 row1 = table.Rows.Add(40,
                                       Font.HelveticaBold,
                                       16,
                                       RgbColor.Black,
                                       RgbColor.White);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Steps");
            row1.Cells.Add("Actions");
            row1.Cells.Add("Status");

            //Check the table


            // Add rows
            AddRow(table, "1", "ECHA Website is up and running", chr[0]);     
            AddRow(table, "2", "Click on the Login button", chr[1]);
            AddRow(table, "4", "Fill the 'Username' and the 'Password' Fields", chr[2]);
            AddRow(table, "5", "Click on the login buttom", chr[3]);
            AddRow(table, "6", "User logged in succesfully", chr[4]);

            for (int i = 0; i < chr.Length; i++)
            {
                if (chr[i] == 1)
                {
                    Table2 table1 = new Table2(0, 350, 600, 600);
                    table1.CellDefault.Border.Color = RgbColor.Black;
                    table1.CellSpacing = 5.0f;

                    Label errorlabel = new Label("Step "+(i+1)+" failed", 0, 320, 500, 100, Font.Helvetica, 16, TextAlign.Center);

                    string[] collection = ex.Split('}');

                    // Add columns to the table
                    table1.Columns.Add(500);
                    Row2 row2 = table1.Rows.Add(40,
                                       Font.HelveticaBold,
                                       8,
                                       RgbColor.Black,
                                       RgbColor.White);
                    row2.CellDefault.VAlign = VAlign.Center;
                    row2.Cells.Add(ex);

                    page.Elements.Add(table1);
                    page.Elements.Add(errorlabel);
                }
            }

            // Add the table and the text to the page
            page.Elements.Add(table);
            page.Elements.Add(label);
            page.Elements.Add(label2);

            // Save the PDF 
            document.Draw(Util.GetPath("Output/" + Name + ".pdf"));
        }

        public static void Pact(string Text, string Name, int[] chr, string ex)
        {
            ;
            // Create a PDF Document 
            Document document = new Document();

            //Create Time
            DateTime dt = DateTime.Now;

            // Create a Page
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            // Create a text
            string labelText = Text;
            Label label = new Label(labelText, 0, 0, 500, 100, Font.Helvetica, 18, TextAlign.Center);

            Label label2 = new Label(dt.ToString(), 450, -50, 500, 100, Font.Helvetica, 9);
            //Console.WriteLine(dt);

            // Create a table
            Table2 table = new Table2(75, 50, 600, 600);
            table.CellDefault.Border.Color = RgbColor.Black;
            table.CellSpacing = 5.0f;

            // Add columns to the table
            table.Columns.Add(50);
            table.Columns.Add(200);
            table.Columns.Add(80);

            // Add rows to the table and add cells to the rows
            Row2 row1 = table.Rows.Add(40,
                                       Font.HelveticaBold,
                                       16,
                                       RgbColor.Black,
                                       RgbColor.White);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Steps");
            row1.Cells.Add("Actions");
            row1.Cells.Add("Status");

            // Add rows
            AddRow(table, "1", "ECHA Website is up and running", chr[0]);
            AddRow(table, "2", "Navigate to the 'PACT' page", chr[1]);
            AddRow(table, "3", "Perform a search", chr[2]);
            AddRow(table, "4", "Click on the eye icon", chr[3]);
            AddRow(table, "5", "Verify that the system redirects the user to the corresponding details page", chr[4]);

            for (int i = 0; i < chr.Length; i++)
            {
                if (chr[i] == 1)
                {
                    Table2 table1 = new Table2(0, 350, 600, 600);
                    table1.CellDefault.Border.Color = RgbColor.Black;
                    table1.CellSpacing = 5.0f;

                    Label errorlabel = new Label("Step " + (i + 1) + " failed", 0, 320, 500, 100, Font.Helvetica, 16, TextAlign.Center);

                    // Add columns to the table
                    table1.Columns.Add(500);
                    Row2 row2 = table1.Rows.Add(40,
                                       Font.HelveticaBold,
                                       8,
                                       RgbColor.Black,
                                       RgbColor.White);
                    row2.CellDefault.VAlign = VAlign.Center;
                    row2.Cells.Add(ex);

                    page.Elements.Add(table1);
                    page.Elements.Add(errorlabel);
                }
            }

            // Add the table and the text to the page
            page.Elements.Add(table);
            page.Elements.Add(label);
            page.Elements.Add(label2);

            // Save the PDF 
            document.Draw(Util.GetPath("Output/" + Name + ".pdf"));
        }

        public static void Scip(string Text, string Name, int[] chr, string ex)
        {
            //Validation pantchris = new Validation();

            //int chr = pantchris.Test;

            // Create a PDF Document 
            Document document = new Document();

            //Date
            DateTime dt = DateTime.Now;

            // Create a Page
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            // Create a text
            string labelText = Text;
            Label label = new Label(labelText, 0, 0, 500, 100, Font.Helvetica, 18, TextAlign.Center);

            Label label2 = new Label(dt.ToString(), 450, -50, 500, 100, Font.Helvetica, 9);
            //Console.WriteLine(dt);

            // Create a table
            Table2 table = new Table2(75, 50, 600, 600);
            table.CellDefault.Border.Color = RgbColor.Black;
            table.CellSpacing = 5.0f;

            // Add columns to the table
            table.Columns.Add(50);
            table.Columns.Add(200);
            table.Columns.Add(80);

            // Add rows to the table and add cells to the rows
            Row2 row1 = table.Rows.Add(40,
                                       Font.HelveticaBold,
                                       16,
                                       RgbColor.Black,
                                       RgbColor.White);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Steps");
            row1.Cells.Add("Actions");
            row1.Cells.Add("Status");

            // Add rows
            AddRow(table, "1", "ECHA Website is up and running", chr[0]);
            AddRow(table, "2", "Navigate to the 'SCIP' page", chr[1]);
            AddRow(table, "3", "Perform a search", chr[2]);
            AddRow(table, "4", "Click on the eye icon", chr[3]);
            AddRow(table, "5", "The SCIP item contains Mterial categories values", chr[4]);

            //Console.WriteLine(chr);

            for (int i = 0; i < chr.Length; i++)
            {
                if (chr[i] == 1)
                {
                    Table2 table1 = new Table2(0, 350, 600, 600);
                    table1.CellDefault.Border.Color = RgbColor.Black;
                    table1.CellSpacing = 5.0f;

                    Label errorlabel = new Label("Step " + (i + 1) + " failed", 0, 320, 500, 100, Font.Helvetica, 16, TextAlign.Center);


                    string[] collection = ex.Split('}');

                    // Add columns to the table
                    table1.Columns.Add(500);
                    Row2 row2 = table1.Rows.Add(40,
                                       Font.HelveticaBold,
                                       8,
                                       RgbColor.Black,
                                       RgbColor.White);
                    row2.CellDefault.VAlign = VAlign.Center;
                    row2.Cells.Add(ex);

                    page.Elements.Add(table1);
                    page.Elements.Add(errorlabel);
                }
            }

            // Add the table and the text to the page
            page.Elements.Add(table);
            page.Elements.Add(label);
            page.Elements.Add(label2);

            // Save the PDF 
            document.Draw(Util.GetPath("Output/" + Name + ".pdf"));
        }
        private static void AddRow(Table2 table, string number, string Actions, int num)
        {
            if (num == 0)
            {
                string Status = "Passed";

                Row2 row = table.Rows.Add(30);
                Cell2 cell = row.Cells.Add(number);
                cell.Align = TextAlign.Center;
                cell.VAlign = VAlign.Center;

                Cell2 cell1 = row.Cells.Add(Actions);
                //cell1.Align = TextAlign.Center;
                cell1.VAlign = VAlign.Center;

                Cell2 cell2 = row.Cells.Add(Status);
                cell2.Align = TextAlign.Center;
                cell2.VAlign = VAlign.Center;
                cell2.BackgroundColor = RgbColor.Green;
                cell2.Font = Font.HelveticaBold;
            }
            else if (num == 1)
            {
                string Status = "Failed";

                Row2 row = table.Rows.Add(30);
                Cell2 cell = row.Cells.Add(number);
                cell.Align = TextAlign.Center;
                cell.VAlign = VAlign.Center;

                Cell2 cell1 = row.Cells.Add(Actions);
                //cell1.Align = TextAlign.Center;
                cell1.VAlign = VAlign.Center;

                Cell2 cell2 = row.Cells.Add(Status);
                cell2.Align = TextAlign.Center;
                cell2.VAlign = VAlign.Center;
                cell2.BackgroundColor = RgbColor.Red;
                cell2.Font = Font.HelveticaBold;
            }
            else
            {
                string Status = "Null";

                Row2 row = table.Rows.Add(30);
                Cell2 cell = row.Cells.Add(number);
                cell.Align = TextAlign.Center;
                cell.VAlign = VAlign.Center;

                Cell2 cell1 = row.Cells.Add(Actions);
                //cell1.Align = TextAlign.Center;
                cell1.VAlign = VAlign.Center;

                Cell2 cell2 = row.Cells.Add(Status);
                cell2.Align = TextAlign.Center;
                cell2.VAlign = VAlign.Center;
                cell2.BackgroundColor = RgbColor.Gray;
                cell2.Font = Font.HelveticaBold;
            }
        }
    }
}
