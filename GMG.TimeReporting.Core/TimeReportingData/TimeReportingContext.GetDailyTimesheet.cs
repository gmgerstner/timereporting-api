using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMG.TimeReporting.Core.TimeReportingData
{
    public partial class TimeReportingContext : DbContext
    {
        public IEnumerable<TimeSheetEntry> GetDailyTimesheet(DateTime? date)
        {
            if (!date.HasValue) date = DateTime.Today;

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter() { ParameterName = "@WorkDate", SqlDbType = System.Data.SqlDbType.DateTime, IsNullable = true, SqlValue = date } };

            // Get the connection from DbContext
            var connection = Database.GetDbConnection();

            // Open the connection if isn't open
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "GetDailyTimesheet";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;

                if (parameters?.Length > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                using (var dataReader = command.ExecuteReader())
                {
                    // List for column names
                    var names = new List<string>();

                    if (dataReader.HasRows)
                    {
                        // Add column names to list
                        for (var i = 0; i < dataReader.VisibleFieldCount; i++)
                        {
                            names.Add(dataReader.GetName(i));
                        }

                        while (dataReader.Read())
                        {
                            // Create the dynamic result for each row
                            var result = new ExpandoObject() as IDictionary<string, object>;

                            foreach (var name in names)
                            {
                                // Add key-value pair
                                // key = column name
                                // value = column value
                                result.Add(name, dataReader[name]);
                            }

                            TimeSheetEntry timeSheetEntry = new TimeSheetEntry
                            {
                                Title = result["Title"].ToString(),
                                TotalHours = result["TotalHours"] == DBNull.Value ? null : (decimal?)result["TotalHours"]
                            };
                            yield return timeSheetEntry;
                        }
                    }
                }
            }
        }
        public class TimeSheetEntry
        {
            public string Title { get; set; }

            public decimal? TotalHours { get; set; }
        }
    }
}
