using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bibcsv
{
    public class ExportHelper
    {
        public bool Export(DataGridView dgv)
        {
            bool exported = false;

            List<string> lines = new List<string>();
            DataGridViewColumnCollection header = dgv.Columns;
            bool firstDone = false;
            StringBuilder headerLine = new StringBuilder();
            foreach (DataGridViewColumn column in header)
            {
                if (!firstDone)
                {
                    headerLine.Append(column.DataPropertyName);
                    firstDone = true; 
                }
                else
                {
                    headerLine.Append(","+column.DataPropertyName);
                }
            }

            lines.Add(headerLine.ToString());

            foreach(DataGridViewRow row in dgv.Rows)
            {
                StringBuilder dataLine = new StringBuilder();
                firstDone = false;
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if(!firstDone)
                    {
                        dataLine.Append(cell.Value);
                        firstDone=true;
                    }
                    else
                    {
                        dataLine.Append("," + cell.Value);
                    }
                }
                lines.Add(dataLine.ToString());
            }

            string file = @"c:\\data2022.csv";
            System.IO.File.WriteAllLines(file, lines);
            System.Diagnostics.Process.Start(file);
            return exported;
        }
    }
}
