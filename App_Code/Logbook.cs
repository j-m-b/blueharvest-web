using System;

public class Logbook {

    public Guid id { get; set; }
    public DateTime datetime { get; set; }
    public LogbookEntries entries { get; set; }

    public Logbook() { }

    public Logbook(Guid id) {
        using (System.Data.SqlClient.SqlConnection c =
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getLogbook", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@id"].Value = id;
                // output parameter
                cmd.Parameters.Add("@datetime", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@datetime"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@datetime"].Value)) { // check a req'd parameter
                    this.id = id;
                    this.datetime = Convert.ToDateTime(cmd.Parameters["@datetime"].Value).ToUniversalTime();
                    this.entries = new LogbookEntries(id); // call another constructor (we could use one stored proc ...)
                } else { /* something went wrong */ }
            }
        }
    }

    public static bool Insert() {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertLogbook", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    // datetime = sysutcdatetime()
                    // there are none to pass ... default values
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (sql error, etc.)
            return false;
        }
    }

}

/// <summary>logbookentry(id, datetime, title, text, logbook, user)</summary>
public class LogbookEntry {

    public Guid id { get; set; }
    public DateTime datetime { get; set; }
    public string title { get; set; }
    public string text { get; set; }
    public string username { get; set; } // user.username
    public string uri { get; set; } // user.image.uri

    public LogbookEntry() { }

    public static bool Insert(LogbookEntry l, Guid userid, Guid logbookid) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertLogbookEntry", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    // datetime = sysutcdatetime()
                    cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@title"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@title"].Value = l.title;
                    cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar, -1);
                    cmd.Parameters["@text"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@text"].Value = l.text;
                    cmd.Parameters.Add("@userid", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@userid"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@userid"].Value = userid;
                    cmd.Parameters.Add("@logbookid", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@logbookid"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@logbookid"].Value = logbookid;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (sql error, ids incorrect, etc.)
            return false;
        }
    }

}

public class LogbookEntries : System.Collections.ArrayList {

    public LogbookEntries(Guid LogbookId) {
        using (System.Data.SqlClient.SqlConnection c =
           new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
           ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getLogbookEntriesByLogbookId", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@id"].Value = LogbookId;
                c.Open(); // open connection
                using (System.Data.SqlClient.SqlDataReader r = cmd.ExecuteReader()) {
                    if (r.HasRows) {
                        while (r.Read()) {
                            LogbookEntry l = new LogbookEntry();
                            l.id = Guid.Parse(r["id"].ToString());
                            l.datetime = Convert.ToDateTime(r["datetime"]);
                            l.title = r["title"].ToString();
                            l.text = r["text"].ToString();
                            l.username = r["username"].ToString(); // user.username 
                            l.uri = r["uri"].ToString(); // user.image.uri
                            Add(l); // add to the array
                        }
                    }
                }
            }
        }
    }

}