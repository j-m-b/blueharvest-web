using System;

/// <summary>geocache(id, ...)</summary>
public class Geocache {

    public Guid id { get; set; }
    public DateTime anniversary { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int difficulty { get; set; }
    public int terrain { get; set; }
    public int size { get; set; }
    public int status { get; set; }
    public int type { get; set; }
    public Guid userid { get; set; }
    public User user { get; set; }
    public Guid locationid { get; set; }
    //public double latitude { get; set; }
    //public double longitude { get; set; }
    public Location location { get; set; }
    public Guid logbookid { get; set; }
    public Logbook logbook { get; set; }

    public Geocache() { }

    public Geocache(Guid id) { /* todo */ }

    public static bool? Insert(Geocache g) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertGeocacheWithLocationAndLogbook", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    // anniversary = sysutcdatetime()
                    cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@name"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@name"].Value = g.name;
                    cmd.Parameters.Add("@description", System.Data.SqlDbType.NVarChar, -1);
                    cmd.Parameters["@description"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@description"].Value = g.description;
                    cmd.Parameters.Add("@difficulty", System.Data.SqlDbType.Int);
                    cmd.Parameters["@difficulty"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@difficulty"].Value = g.difficulty;
                    cmd.Parameters.Add("@terrain", System.Data.SqlDbType.Int);
                    cmd.Parameters["@terrain"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@terrain"].Value = g.terrain;
                    cmd.Parameters.Add("@size", System.Data.SqlDbType.Int);
                    cmd.Parameters["@size"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@size"].Value = g.size;
                    cmd.Parameters.Add("@status", System.Data.SqlDbType.Int);
                    cmd.Parameters["@status"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@status"].Value = g.status;
                    cmd.Parameters.Add("@type", System.Data.SqlDbType.Int);
                    cmd.Parameters["@type"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@type"].Value = g.type;
                    cmd.Parameters.Add("@userid", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@userid"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@userid"].Value = g.user.id;
                    cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@latitude"].Precision = 10;
                    cmd.Parameters["@latitude"].Scale = 7;
                    cmd.Parameters["@latitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@latitude"].Value = g.location.latitude;
                    cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@longitude"].Precision = 10;
                    cmd.Parameters["@longitude"].Scale = 7;
                    cmd.Parameters["@longitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@longitude"].Value = g.location.longitude;
                    cmd.Parameters.Add("@altitude", System.Data.SqlDbType.Int);
                    cmd.Parameters["@altitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@altitude"].Value = g.location.altitude;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (duplicate parameters, sql error, etc.)
            return false;
        }
    }

    /// <summary>
    /// inserts a geocache with location and logbook
    /// using insertGeocacheWithLocationAndLogbook
    /// stored procedure
    /// </summary>
    /// <param name="g"></param>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    /// <returns></returns>
    public static bool? Insert(Geocache g, double latitude, double longitude) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertGeocacheWithLocationAndLogbook", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    // anniversary = sysutcdatetime()
                    cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@name"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@name"].Value = g.name;
                    cmd.Parameters.Add("@description", System.Data.SqlDbType.NVarChar, -1);
                    cmd.Parameters["@description"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@description"].Value = g.description;
                    cmd.Parameters.Add("@difficulty", System.Data.SqlDbType.Int);
                    cmd.Parameters["@difficulty"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@difficulty"].Value = g.difficulty;
                    cmd.Parameters.Add("@terrain", System.Data.SqlDbType.Int);
                    cmd.Parameters["@terrain"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@terrain"].Value = g.terrain;
                    cmd.Parameters.Add("@size", System.Data.SqlDbType.Int);
                    cmd.Parameters["@size"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@size"].Value = g.size;
                    cmd.Parameters.Add("@status", System.Data.SqlDbType.Int);
                    cmd.Parameters["@status"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@status"].Value = g.status;
                    cmd.Parameters.Add("@type", System.Data.SqlDbType.Int);
                    cmd.Parameters["@type"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@type"].Value = g.type;
                    cmd.Parameters.Add("@userid", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@userid"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@userid"].Value = g.userid;
                    cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@latitude"].Precision = 10;
                    cmd.Parameters["@latitude"].Scale = 7;
                    cmd.Parameters["@latitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@latitude"].Value = latitude;
                    cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@longitude"].Precision = 10;
                    cmd.Parameters["@longitude"].Scale = 7;
                    cmd.Parameters["@longitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@longitude"].Value = longitude;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (duplicate parameters, sql error, etc.)
            return false;
        }
    }

    public static bool? Update(Geocache g) {
        // todo: update in db table
        return false;
    }

    public static bool? Delete(Guid id) {
        // todo: delete from db table
        return false;
    }

}

public class Geocaches : System.Collections.ArrayList {

    /// <summary>getGeocachesWithinDistance stored procedure</summary>
    /// <param name="minlatrad">minimum latitude in radians</param>
    /// <param name="maxlatrad">maximum latitude in radians</param>
    /// <param name="minlngrad">minimum longitude in radians</param>
    /// <param name="maxlngrad">maximum longitude in radians</param>
    /// <param name="latrad">center latitude coordinate in radians</param>
    /// <param name="lngrad">center longitude coordinate in radians</param>
    /// <param name="distance">distance (radius)</param>
    public Geocaches(double minlatrad, double maxlatrad, double minlngrad, double maxlngrad, double latrad, double lngrad, double distance) {
        using (System.Data.SqlClient.SqlConnection c =
         new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
         ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getGeocachesWithinDistance", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@minlatrad", System.Data.SqlDbType.Decimal, 20);
                cmd.Parameters["@minlatrad"].Precision = 20;
                cmd.Parameters["@minlatrad"].Scale = 18;
                cmd.Parameters["@minlatrad"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@minlatrad"].Value = minlatrad;
                cmd.Parameters.Add("@maxlatrad", System.Data.SqlDbType.Decimal, 20);
                cmd.Parameters["@maxlatrad"].Precision = 20;
                cmd.Parameters["@maxlatrad"].Scale = 18;
                cmd.Parameters["@maxlatrad"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@maxlatrad"].Value = maxlatrad;
                cmd.Parameters.Add("@minlngrad", System.Data.SqlDbType.Decimal, 20);
                cmd.Parameters["@minlngrad"].Precision = 20;
                cmd.Parameters["@minlngrad"].Scale = 18;
                cmd.Parameters["@minlngrad"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@minlngrad"].Value = minlngrad;
                cmd.Parameters.Add("@maxlngrad", System.Data.SqlDbType.Decimal, 20);
                cmd.Parameters["@maxlngrad"].Precision = 20;
                cmd.Parameters["@maxlngrad"].Scale = 18;
                cmd.Parameters["@maxlngrad"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@maxlngrad"].Value = maxlngrad;
                cmd.Parameters.Add("@latrad", System.Data.SqlDbType.Decimal, 20);
                cmd.Parameters["@latrad"].Precision = 20;
                cmd.Parameters["@latrad"].Scale = 18;
                cmd.Parameters["@latrad"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@latrad"].Value = latrad;
                cmd.Parameters.Add("@lngrad", System.Data.SqlDbType.Decimal, 20);
                cmd.Parameters["@lngrad"].Precision = 20;
                cmd.Parameters["@lngrad"].Scale = 18;
                cmd.Parameters["@lngrad"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@lngrad"].Value = lngrad;
                cmd.Parameters.Add("@distance", System.Data.SqlDbType.Decimal, 10);
                cmd.Parameters["@distance"].Precision = 10;
                cmd.Parameters["@distance"].Scale = 5;
                cmd.Parameters["@distance"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@distance"].Value = distance;
                c.Open(); // open connection
                using (System.Data.SqlClient.SqlDataReader r = cmd.ExecuteReader()) {
                    if (r.HasRows) {
                        while (r.Read()) {
                            Geocache g = new Geocache();
                            g.id = Guid.Parse(r["geocacheid"].ToString());
                            g.anniversary = Convert.ToDateTime(r["anniversary"]);
                            g.name = r["name"].ToString();
                            g.description = r["description"].ToString();
                            g.difficulty = Convert.IsDBNull(r["difficulty"]) ? 0 : (int)r["difficulty"];
                            g.terrain = Convert.IsDBNull(r["terrain"]) ? 0 : (int)r["terrain"];
                            g.size = Convert.IsDBNull(r["size"]) ? 0 : (int)r["size"];
                            g.status = Convert.IsDBNull(r["status"]) ? 0 : (int)r["status"];
                            g.type = Convert.IsDBNull(r["type"]) ? 0 : (int)r["type"];
                            // location
                            g.location = new Location();
                            g.location.id = Guid.Parse(r["locationid"].ToString());
                            g.location.latitude = Convert.ToDouble(r["latitude"]);
                            g.location.longitude = Convert.ToDouble(r["longitude"]);
                            g.location.altitude = Convert.IsDBNull(r["altitude"]) ? 0 : (int)r["altitude"];
                            // user
                            g.user = new User();
                            g.user.id = Guid.Parse(r["userid"].ToString());
                            g.user.username = r["username"].ToString();
                            g.user.email = r["email"].ToString();
                            // logbook
                            g.logbook = new Logbook();
                            g.logbook.id = Guid.Parse(r["logbookid"].ToString());
                            Add(g); // add to the array
                        }
                    }
                }
            }
        }
    }

}