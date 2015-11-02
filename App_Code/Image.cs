using System;

/// <summary>image(id, uri, caption)</summary>
public class Image {

    public Guid id { get; set; }
    //public Uri uri { get; set; } // System.Uri cannot be serialized because it does not have a parameterless constructor.
    public string uri { get; set; }
    //public int rank { get; set; }
    public string caption { get; set; }
    // forego empty attribute ... can be determined from 
    // the state of id or uri which are required for 
    // instantiation.

    public Image() { }

    public Image(Guid id) {
        using (System.Data.SqlClient.SqlConnection c =
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getImagebyId", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@id"].Value = id;
                // output parameter(s)
                cmd.Parameters.Add("@uri", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters["@uri"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@caption", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@caption"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@uri"].Value)) { // there exists a db image
                    this.id = id;
                    this.uri = cmd.Parameters["@uri"].Value.ToString(); // new Uri(cmd.Parameters["@uri"].Value.ToString());
                    this.caption = cmd.Parameters["@caption"].Value.ToString();
                }
            }
        }
    }

    public static bool? Insert(Image i) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertImage", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    cmd.Parameters.Add("@uri", System.Data.SqlDbType.NVarChar, 255);
                    cmd.Parameters["@uri"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@uri"].Value = i.uri;
                    cmd.Parameters.Add("@caption", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@caption"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@caption"].Value = i.caption;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (duplicate uri, sql error, etc.)
            return false;
        }
    }

    public static bool? Update(Image i) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.updateImage", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@id"].Value = i.id; // strictly for where clause
                    cmd.Parameters.Add("@uri", System.Data.SqlDbType.NVarChar, 255);
                    cmd.Parameters["@uri"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@uri"].Value = i.uri;
                    cmd.Parameters.Add("@caption", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@caption"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@caption"].Value = i.caption;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the update failed somehow (duplicate uri, sql error, etc.)
            return false;
        }
    }

    public static bool? Delete(Guid id) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.deleteImage", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@id"].Value = id; // strictly for where clause
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch /*(Exception e)*/ { // the delete failed somehow (sql error, etc.)
            //System.Diagnostics.Debug.WriteLine(e.Message);
            return false;
        }
    }

}