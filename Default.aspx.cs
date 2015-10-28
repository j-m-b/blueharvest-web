using System;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        // testing area
        message.Text += "Hello World!";

        // from aws rds db instance
        //message.Text += "<br />" + DateTime.Now + " aws rds db: " + new User("jamie").email;

        // from godaddy hosted db instance
        //message.Text += "<br />" + DateTime.Now + " godaddy db:" + getTestById(Guid.Parse("F584BD9B-AF95-4BA2-9B6A-47B29FF3C8A1"));

        //Image.Delete(new Guid("78290B3C-B687-4191-8E1A-F781646C04F6"));

    }

    protected string getTestById(Guid id) {
        using (System.Data.SqlClient.SqlConnection c =
           new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
           ConnectionStrings["blueharvest-gd"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.getTestById", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@id"].Value = id;
                // input/output parameter(s)
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@name"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@id"].Value)) {
                    return cmd.Parameters["@name"].Value.ToString();
                } else {
                    return "nope, didn't work";
                }
            }
        }

    }

}