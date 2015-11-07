using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class DatabaseService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public bool? DeleteAll(string username, string password) {
        if (sc != null && sc.isValid()) {
            User u = new User(username);
            if (PasswordHash.PasswordHash.ValidatePassword(u.salt + password, u.password) && u.role.name.Equals("Admin") && !u.locked && u.active) {
                return Database.DeleteAll();
            } else {
                return null;
            }
        } else {
            return null;
        }
    }

}