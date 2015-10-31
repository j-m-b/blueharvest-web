using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary> location(id, latitude, longitude, altitude)</summary>
public class Location {

    public Guid id { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int altitude { get; set; }

    public Location() { }

    /// <summary>getLocationById stored procedure</summary>
    public Location(Guid id) {
        using (System.Data.SqlClient.SqlConnection c =
           new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
           ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getLocationById", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@id"].Value = id;
                // output parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@anniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@anniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters["@password"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@salt", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@salt"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@email"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@active", System.Data.SqlDbType.Bit);
                cmd.Parameters["@active"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@locked", System.Data.SqlDbType.Bit);
                cmd.Parameters["@locked"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@latitude"].Value) && !Convert.IsDBNull(cmd.Parameters["@longitude"].Value)) {
                    this.id = Guid.Parse(cmd.Parameters["@id"].Value.ToString());
                    this.latitude = (double)cmd.Parameters["@latitude"].Value;
                    this.latitude = (double)cmd.Parameters["@longitude"].Value;
                    this.latitude = (int)cmd.Parameters["@altitude"].Value;
                } else { // no result
                    // what to do??
                }
            }
        }
    }

    /// <summary>insertLocation stored procedure</summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static bool Insert(Location l) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertLocation", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@latitude"].Precision = 7;
                    cmd.Parameters["@latitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@latitude"].Value = l.latitude;
                    cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@longitude"].Precision = 7;
                    cmd.Parameters["@longitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@longitude"].Value = l.longitude;
                    cmd.Parameters.Add("@altitude", System.Data.SqlDbType.Int);
                    cmd.Parameters["@altitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@altitude"].Value = l.altitude;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (sql error, ids incorrect, etc.)
            return false;
        }
    }

    /// <summary>updateLocation stored procedure</summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static bool Update(Location l) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertLocation", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@latitude"].Precision = 7;
                    cmd.Parameters["@latitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@latitude"].Value = l.latitude;
                    cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal, 10);
                    cmd.Parameters["@longitude"].Precision = 7;
                    cmd.Parameters["@longitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@longitude"].Value = l.longitude;
                    cmd.Parameters.Add("@altitude", System.Data.SqlDbType.Int);
                    cmd.Parameters["@altitude"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@altitude"].Value = l.altitude;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (sql error, ids incorrect, etc.)
            return false;
        }
    }

    public static bool Delete(Guid id) {
        throw new NotImplementedException(); // todo
    }

}