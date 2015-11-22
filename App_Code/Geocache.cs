using System;

/// <summary>geocache(id, ...)</summary>
public class Geocache {

    public Guid id { get; set; }
    public DateTime anniversary { get; set; }
    public string code { get; set; }
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
    public bool empty { get; set; }

    public Geocache() { }

    public Geocache(Guid id) {
        using (System.Data.SqlClient.SqlConnection c =
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getGeocacheById", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@id"].Value = id;
                // output parameter(s)
                // geocache
                cmd.Parameters.Add("@anniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@anniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 13);
                cmd.Parameters["@code"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@name"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.NVarChar, -1);
                cmd.Parameters["@description"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@difficulty", System.Data.SqlDbType.Int);
                cmd.Parameters["@difficulty"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@terrain", System.Data.SqlDbType.Int);
                cmd.Parameters["@terrain"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@size", System.Data.SqlDbType.Int);
                cmd.Parameters["@size"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@status", System.Data.SqlDbType.Int);
                cmd.Parameters["@status"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@type", System.Data.SqlDbType.Int);
                cmd.Parameters["@type"].Direction = System.Data.ParameterDirection.Output;
                // user
                cmd.Parameters.Add("@userid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@userid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@uanniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@uanniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@email"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@active", System.Data.SqlDbType.Bit);
                cmd.Parameters["@active"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@locked", System.Data.SqlDbType.Bit);
                cmd.Parameters["@locked"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@roleid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@roleid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@rolename", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@rolename"].Direction = System.Data.ParameterDirection.Output;
                // location (and address)
                cmd.Parameters.Add("@locationid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@locationid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal, 10);
                cmd.Parameters["@latitude"].Precision = 10;
                cmd.Parameters["@latitude"].Scale = 7;
                cmd.Parameters["@latitude"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal, 10);
                cmd.Parameters["@longitude"].Precision = 10;
                cmd.Parameters["@longitude"].Scale = 7;
                cmd.Parameters["@longitude"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@altitude", System.Data.SqlDbType.Int);
                cmd.Parameters["@altitude"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@addressid", System.Data.SqlDbType.UniqueIdentifier);
                //cmd.Parameters["@addressid"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@street", System.Data.SqlDbType.NVarChar, 100);
                //cmd.Parameters["@street"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@city", System.Data.SqlDbType.NVarChar, 100);
                //cmd.Parameters["@city"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@region", System.Data.SqlDbType.NVarChar, 100);
                //cmd.Parameters["@region"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@postalcode", System.Data.SqlDbType.NVarChar, 25);
                //cmd.Parameters["@postalcode"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@logbookid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@logbookid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@datetime", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@datetime"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@anniversary"].Value)) { // any req'ed column
                    this.id = id;
                    this.anniversary = Convert.ToDateTime(cmd.Parameters["@anniversary"].Value).ToUniversalTime();
                    this.code = cmd.Parameters["@code"].Value.ToString();
                    this.name = cmd.Parameters["@name"].Value.ToString();
                    this.description = cmd.Parameters["@description"].Value.ToString();
                    this.difficulty = (int)cmd.Parameters["@difficulty"].Value;
                    this.terrain = (int)cmd.Parameters["@terrain"].Value;
                    this.size = (int)cmd.Parameters["@size"].Value;
                    this.status = (int)cmd.Parameters["@status"].Value;
                    this.type = (int)cmd.Parameters["@type"].Value;
                    this.user = new User();
                    this.user.id = Guid.Parse(cmd.Parameters["@userid"].Value.ToString());
                    this.user.anniversary = Convert.ToDateTime(cmd.Parameters["@uanniversary"].Value).ToUniversalTime();
                    this.user.username = cmd.Parameters["@username"].Value.ToString();
                    this.user.email = cmd.Parameters["@email"].Value.ToString();
                    this.user.active = Convert.ToBoolean(cmd.Parameters["@active"].Value);
                    this.user.locked = Convert.ToBoolean(cmd.Parameters["@locked"].Value);
                    this.user.role = new Role(Guid.Parse(cmd.Parameters["@roleid"].Value.ToString()),
                        cmd.Parameters["@rolename"].Value.ToString());
                    this.location = new Location();
                    this.location.id = Guid.Parse(cmd.Parameters["@locationid"].Value.ToString());
                    this.location.longitude = Convert.ToDouble(cmd.Parameters["@longitude"].Value);
                    this.location.altitude = (int)cmd.Parameters["@altitude"].Value;
                    // Guid.Parse(cmd.Parameters["@addressid"].Value.ToString())
                    // cmd.Parameters["@street"].Value
                    // cmd.Parameters["@city"].Value
                    // cmd.Parameters["@region"].Value
                    // cmd.Parameters["@postalcode"].Value
                    this.logbook = new Logbook();
                    this.logbook.id = Guid.Parse(cmd.Parameters["@logbookid"].Value.ToString());
                    this.logbook.datetime = Convert.ToDateTime(cmd.Parameters["@datetime"].Value);
                } else { // no result
                    this.empty = true;
                }
            }
        }
    }

    public Geocache(string code) {
        using (System.Data.SqlClient.SqlConnection c =
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getGeocacheByCode", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 13);
                cmd.Parameters["@code"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@code"].Value = code;
                // output parameter(s)
                // geocache
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@anniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@anniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@name"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.NVarChar, -1);
                cmd.Parameters["@description"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@difficulty", System.Data.SqlDbType.Int);
                cmd.Parameters["@difficulty"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@terrain", System.Data.SqlDbType.Int);
                cmd.Parameters["@terrain"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@size", System.Data.SqlDbType.Int);
                cmd.Parameters["@size"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@status", System.Data.SqlDbType.Int);
                cmd.Parameters["@status"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@type", System.Data.SqlDbType.Int);
                cmd.Parameters["@type"].Direction = System.Data.ParameterDirection.Output;
                // user
                cmd.Parameters.Add("@userid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@userid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@uanniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@uanniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@email"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@active", System.Data.SqlDbType.Bit);
                cmd.Parameters["@active"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@locked", System.Data.SqlDbType.Bit);
                cmd.Parameters["@locked"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@roleid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@roleid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@rolename", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@rolename"].Direction = System.Data.ParameterDirection.Output;
                // location (and address)
                cmd.Parameters.Add("@locationid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@locationid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal, 10);
                cmd.Parameters["@latitude"].Precision = 10;
                cmd.Parameters["@latitude"].Scale = 7;
                cmd.Parameters["@latitude"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal, 10);
                cmd.Parameters["@longitude"].Precision = 10;
                cmd.Parameters["@longitude"].Scale = 7;
                cmd.Parameters["@longitude"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@altitude", System.Data.SqlDbType.Int);
                cmd.Parameters["@altitude"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@addressid", System.Data.SqlDbType.UniqueIdentifier);
                //cmd.Parameters["@addressid"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@street", System.Data.SqlDbType.NVarChar, 100);
                //cmd.Parameters["@street"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@city", System.Data.SqlDbType.NVarChar, 100);
                //cmd.Parameters["@city"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@region", System.Data.SqlDbType.NVarChar, 100);
                //cmd.Parameters["@region"].Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add("@postalcode", System.Data.SqlDbType.NVarChar, 25);
                //cmd.Parameters["@postalcode"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@logbookid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@logbookid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@datetime", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@datetime"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@anniversary"].Value)) { // any req'ed column
                    this.id = id;
                    this.anniversary = Convert.ToDateTime(cmd.Parameters["@anniversary"].Value).ToUniversalTime();
                    this.code = cmd.Parameters["@code"].Value.ToString();
                    this.name = cmd.Parameters["@name"].Value.ToString();
                    this.description = cmd.Parameters["@description"].Value.ToString();
                    this.difficulty = (int)cmd.Parameters["@difficulty"].Value;
                    this.terrain = (int)cmd.Parameters["@terrain"].Value;
                    this.size = (int)cmd.Parameters["@size"].Value;
                    this.status = (int)cmd.Parameters["@status"].Value;
                    this.type = (int)cmd.Parameters["@type"].Value;
                    this.user = new User();
                    this.user.id = Guid.Parse(cmd.Parameters["@userid"].Value.ToString());
                    this.user.anniversary = Convert.ToDateTime(cmd.Parameters["@uanniversary"].Value).ToUniversalTime();
                    this.user.username = cmd.Parameters["@username"].Value.ToString();
                    this.user.email = cmd.Parameters["@email"].Value.ToString();
                    this.user.active = Convert.ToBoolean(cmd.Parameters["@active"].Value);
                    this.user.locked = Convert.ToBoolean(cmd.Parameters["@locked"].Value);
                    this.user.role = new Role(Guid.Parse(cmd.Parameters["@roleid"].Value.ToString()),
                        cmd.Parameters["@rolename"].Value.ToString());
                    this.location = new Location();
                    this.location.id = Guid.Parse(cmd.Parameters["@locationid"].Value.ToString());
                    this.location.latitude = Convert.ToDouble(cmd.Parameters["@latitude"].Value);
                    this.location.longitude = Convert.ToDouble(cmd.Parameters["@longitude"].Value);
                    this.location.altitude = (int)cmd.Parameters["@altitude"].Value;
                    // Guid.Parse(cmd.Parameters["@addressid"].Value.ToString())
                    // cmd.Parameters["@street"].Value
                    // cmd.Parameters["@city"].Value
                    // cmd.Parameters["@region"].Value
                    // cmd.Parameters["@postalcode"].Value
                    this.logbook = new Logbook();
                    this.logbook.id = Guid.Parse(cmd.Parameters["@logbookid"].Value.ToString());
                    this.logbook.datetime = Convert.ToDateTime(cmd.Parameters["@datetime"].Value);
                } else { // no result
                    this.empty = true;
                }
            }
        }
    }

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
                    cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 13);
                    cmd.Parameters["@code"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@code"].Value = g.code;
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
                    cmd.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 13);
                    cmd.Parameters["@code"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@code"].Value = g.name;
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
                            g.code = r["code"].ToString();
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
                            // user role
                            g.user.role = new Role();
                            g.user.role.id = Guid.Parse(r["roleid"].ToString());
                            g.user.role.name = r["rolename"].ToString();
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