using System;

/// <summary>image(id, uri, rank)</summary>
public class Image {

    public Guid id { get; set; }
    //public Uri uri { get; set; } // System.Uri cannot be serialized because it does not have a parameterless constructor.
    public string uri { get; set; }
    public int rank { get; set; }

    public Image() { }

    public Image(Guid id) {
        // todo: test
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
                cmd.Parameters.Add("@rank", System.Data.SqlDbType.Int);
                cmd.Parameters["@rank"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@id"].Value)) {
                    this.id = Guid.Parse(cmd.Parameters["@id"].Value.ToString());
                    this.uri = cmd.Parameters["@uri"].Value.ToString(); // new Uri(cmd.Parameters["@uri"].Value.ToString());
                    this.rank = (int)cmd.Parameters["@uri"].Value;
                }
            }
        }
    }

    public static bool? Insert(Image i) {
        // todo: insert into db table, sp done
        return false;
    }

    public static bool? Update(Image i) {
        // todo: update db table, sp done
        return false;
    }

    public static bool? Delete(Guid id) {
        // todo: delete from db table, sp done
        return false;
    }

}