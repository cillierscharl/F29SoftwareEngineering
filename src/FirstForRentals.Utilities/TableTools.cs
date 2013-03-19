using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FirstForRentals.Utilities
{
    public class TableTools
    {
        public static string BuildHTMLTable(DataSet dataSet)
        {
            var table = dataSet.Tables[0];
            var tableString = "<table class='content_table'>";
            
            tableString += "<thead>";
            
            for (var i = 0; i < table.Columns.Count; i++)
            {
                tableString += "<th>" + table.Columns[i].ColumnName + "</th>";
            }
            tableString += "</thead>";
            tableString += "<tbody>";

            for(var x = 0; x < table.Rows.Count; x++)
            {
                tableString += "<tr>";

                for (var y = 0; y < table.Columns.Count; y++)
                {
                    tableString += "<td>";
                    tableString += table.Rows[x][y];
                    tableString += "</td>";
                }
                

                tableString += "</tr>";
            }

            tableString += "</tbody>";
            tableString += "</table>";

            return tableString;
        }
    }
}
