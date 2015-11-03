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

        /*LogbookEntry le = new LogbookEntry();
        le.title = "title";
        le.text = "text";
        Guid userid = Guid.Parse("1A64A1A1-2F3E-404B-86CF-25507CD74EC0");
        Guid logbookid = Guid.Parse("E32FE75A-DB0D-4DC7-AE89-E3FF6C72BAA8");
        message.Text += "<br />" + LogbookEntry.Insert(le, userid, logbookid);*/

        /* LogbookEntries l = new LogbookEntries(Guid.Parse("E32FE75A-DB0D-4DC7-AE89-E3FF6C72BAA8"));
         message.Text += "<br />" + l.Count;
         for (int i = 0; i < l.Count - 1; i++) {
            message.Text += "<br />" + ((LogbookEntry) l[i]).title;
         }*/

        //Geocache.Insert(new Geocache(), 0, 0);

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