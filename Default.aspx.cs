using System;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        // testing area
        message.Text += "Hello World!";

        /*User u = new User("username");
        Geocache g = new Geocache("BH13GC7");

        message.Text += "<br />" + u.id;
        message.Text += "<br />" + g.id;

        message.Text += "<br />" + Geocache.IsFavorite(g.id, u.id);
        message.Text += "<br />" + Geocache.IsFound(g.id, u.id);*/

        /* everything works just fine!
        // testing favorite and found
        User u = new User("jamie");
        Geocache g = new Geocache("BH13GC7");
        // testing favorite insert
        //message.Text += "<br />" + global::User.relateFavoriteGeocache(u.id, g.id, true);
        // testing favorite delete
        //message.Text += "<br />" + global::User.relateFavoriteGeocache(u.id, g.id, false);
        // testing favorite list
        //message.Text += "<br />" + new Geocaches(u.id, Geocaches.type.favorite).Count;

        // testing found insert
        message.Text += "<br />" +  global::User.relateFoundGeocache(u.id, g.id, true);
        // testing found delete
        //message.Text += "<br />" + global::User.relateFoundGeocache(u.id, g.id, false);
        // testing found list
        message.Text += "<br />" + new Geocaches(u.id, Geocaches.type.found).Count;
        */

        /* Geocache g = new Geocache("BH13GC7");
         message.Text += "<br />" + g.name;
         message.Text += "<br />" + g.location.latitude.ToString();*/

        //Location l = new Location(5d, 6d);
        //message.Text += "<br />" + l.empty;

        /*Geocache g = new Geocache(Guid.Parse("F68044F4-F146-4DD5-8289-7BA044612357"));
        message.Text += "<br />" + g.name;*/

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

        /* geocaches by distance */
        /*
        min lat: 0.7076499545598947
        max lat: 0.7126727060545557
        min lng: -1.295632394429061
        max lng: -1.2890083113699913
        lat: 0.7101613303072252
        lng: -1.2923203528995262
        */
        /*Geocaches g = new Geocaches(
            0.7076499545598947, 0.7126727060545557,
            -1.295632394429061, -1.2890083113699913,
            0.7101613303072252, -1.2923203528995262, 16d);
        message.Text += "<br />" + g.Count;*/

        /*User u = new User();
        u.username = "test";
        u.password = "password";
        u.email = "test@test.com";
        u.active = true;
        u.locked = false;
        u.role = new Role(Guid.NewGuid(), "Basic");
        global::User.Insert(u);*/
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