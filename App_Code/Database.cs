using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database {

    public Database() { }

    /// <summary>
    /// deleteAll stored procedure
    /// deletes all data from every table and is irreversible!
    /// </summary>
    /// <returns></returns>
    public static bool DeleteAll() {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.deleteAll", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // there are none to pass
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the delete failed somehow (sql error, etc.)
            return false;
        }
    }

}