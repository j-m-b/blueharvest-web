using System;

/// <summary>
/// user(id, username, password, salt, email, salt, active, locked, roleid) Database Object
/// </summary>
public class User {

    public Guid id { get; set; }
    public DateTime anniversary { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public Guid salt { get; set; }
    //public System.Net.Mail.MailAddress email { get; set; }
    public string email { get; set; }
    public bool active { get; set; }
    public bool locked { get; set; }
    public Role role { get; set; }
    //todo: image, etc.
    public bool empty { get; set; } // web service specific

    public User() { }
    
    /// <summary>getUserByUsernameAndPassword stored procedure todo: test</summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public User(string username, string password) {
        //User u = new User(username);
        using (System.Data.SqlClient.SqlConnection c =    
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getUserByUsernameAndPassword", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@username"].Value = username;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters["@password"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@password"].Value = password; // PasswordHash.PasswordHash.ValidatePassword(u.salt + password, u.password)
                // output parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@anniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@anniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@salt", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@salt"].Direction = System.Data.ParameterDirection.Output;
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
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@id"].Value)) {
                    this.id = Guid.Parse(cmd.Parameters["@id"].Value.ToString());
                    this.anniversary = Convert.ToDateTime(cmd.Parameters["@anniversary"].Value).ToUniversalTime();
                    this.username = username;
                    //this.password = cmd.Parameters["@password"].Value.ToString();
                    //this.salt = Guid.Parse(cmd.Parameters["@salt"].Value.ToString());
                    this.email = cmd.Parameters["@email"].Value.ToString();
                    this.active = Convert.ToBoolean(cmd.Parameters["@active"].Value);
                    this.locked = Convert.ToBoolean(cmd.Parameters["@locked"].Value);
                    this.role = new Role(Guid.Parse(cmd.Parameters["@roleid"].Value.ToString()),
                        cmd.Parameters["@rolename"].Value.ToString());
                } else { // no result
                    this.empty = true;
                }
            }
        }
    }

    /// <summary>getUserByUsername stored procedure</summary>
    /// <param name="username"></param>
    public User(string username) {
        using (System.Data.SqlClient.SqlConnection c =
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getUserByUsername", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@username"].Value = username;
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
                cmd.Parameters.Add("@roleid", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@roleid"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@rolename", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@rolename"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@id"].Value)) {
                    this.id = Guid.Parse(cmd.Parameters["@id"].Value.ToString());
                    this.anniversary = Convert.ToDateTime(cmd.Parameters["@anniversary"].Value).ToUniversalTime();
                    this.username = username;
                    this.password = cmd.Parameters["@password"].Value.ToString();
                    this.salt = Guid.Parse(cmd.Parameters["@salt"].Value.ToString());
                    this.email = cmd.Parameters["@email"].Value.ToString();
                    this.active = Convert.ToBoolean(cmd.Parameters["@active"].Value);
                    this.locked = Convert.ToBoolean(cmd.Parameters["@locked"].Value);
                    this.role = new Role(Guid.Parse(cmd.Parameters["@roleid"].Value.ToString()), cmd.Parameters["@rolename"].Value.ToString());
                } else { // no result
                    this.empty = true;
                    this.id = new Guid();
                    this.anniversary = new DateTime();
                    this.username = null;
                    this.password = null;
                    this.salt = new Guid();
                    this.email = null;
                    this.active = false;
                    this.locked = true;
                }
            }
        }
    }

    /// <summary>getUserByEmail Stored Procedure</summary>
    /// <param name="email"></param>
    public User(System.Net.Mail.MailAddress email) {
        using (System.Data.SqlClient.SqlConnection c =
            new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
            ConnectionStrings["blueharvest-rds"].ConnectionString)) {
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                "blueharvest.dbo.getUserByEmail", c)) {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // input parameter(s)
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@email"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters["@email"].Value = email.ToString(); // no conversion when email is already a string
                // output parameter(s)
                cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@anniversary", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@anniversary"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters["@username"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters["@password"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@salt", System.Data.SqlDbType.UniqueIdentifier);
                cmd.Parameters["@salt"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@active", System.Data.SqlDbType.Bit);
                cmd.Parameters["@active"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@locked", System.Data.SqlDbType.Bit);
                cmd.Parameters["@locked"].Direction = System.Data.ParameterDirection.Output;
                // open and execute
                c.Open(); cmd.ExecuteNonQuery();
                if (!Convert.IsDBNull(cmd.Parameters["@id"].Value)) {
                    this.id = Guid.Parse(cmd.Parameters["@id"].Value.ToString());
                    this.anniversary = Convert.ToDateTime(cmd.Parameters["@anniversary"].Value).ToUniversalTime();
                    this.username = cmd.Parameters["@username"].Value.ToString();
                    this.password = cmd.Parameters["@password"].Value.ToString();
                    this.salt = Guid.Parse(cmd.Parameters["@salt"].Value.ToString());
                    // this.email = new System.Net.Mail.MailAddress(cmd.Parameters["@email"].Value.ToString());
                    this.email = email.ToString();
                    this.active = Convert.ToBoolean(cmd.Parameters["@active"].Value);
                    this.locked = Convert.ToBoolean(cmd.Parameters["@locked"].Value);
                } else { // no results
                    this.empty = true;
                }
            }
        }
    }

    /// <summary>
    /// insertUser stored procedure
    /// Inserts user(id, anniversary, username, password, salt, email, active, locked)
    /// into the database using the blueharvest.dbo.insertUser stored procedure.
    /// id and anniversary have default values in the user table definition and are 
    /// not required nor are used. The password in the user object parameter at this state
    /// is a clear text string consisting of any combination of characters, symbols, or numbers.
    /// A salt is created and hashed with the password and must not exceed 255 Unicode characters.
    /// Role id is based on role name.
    /// </summary>
    /// <param name="u"></param>
    /// <returns></returns>
    public static bool Insert(User u) {
        try {
            Guid salt = Guid.NewGuid(); // salt to hash with password
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.insertUser", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // input parameter(s)
                    // id = newid()
                    // anniversary = sysutcdatetime()
                    cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@username"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@username"].Value = u.username;
                    cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 255);
                    cmd.Parameters["@password"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@password"].Value = PasswordHash.PasswordHash.CreateHash(salt + u.password);
                    cmd.Parameters.Add("@salt", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@salt"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@salt"].Value = salt;
                    cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@email"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@email"].Value = u.email.ToString(); // no conversion when email is already a string
                    cmd.Parameters.Add("@active", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@active"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@active"].Value = u.active;
                    cmd.Parameters.Add("@locked", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@locked"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@locked"].Value = u.locked;
                    cmd.Parameters.Add("@rolename", System.Data.SqlDbType.NVarChar, 50);
                    cmd.Parameters["@rolename"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@rolename"].Value = u.role.name;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the insert failed somehow (duplicate email address, duplicate username, sql error, etc.
            return false;
        }
    }

    public static bool Update(User u) {
        try {
            using (System.Data.SqlClient.SqlConnection c =
               new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.
               ConnectionStrings["blueharvest-rds"].ConnectionString)) {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
                    "blueharvest.dbo.updateUser", c)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@id"].Value = u.id;
                    cmd.Parameters.Add("@active", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@active"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@active"].Value = u.active;
                    cmd.Parameters.Add("@locked", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@locked"].Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters["@locked"].Value = u.locked;
                    c.Open(); cmd.ExecuteNonQuery();  // open and execute
                }
            }
            return true;
        } catch { // the update failed somehow
            return false;
        }
    }

}