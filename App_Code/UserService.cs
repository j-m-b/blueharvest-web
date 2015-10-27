using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class UserService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public User GetUser(string username) {
        if (sc != null && sc.isValid()) {
            return new User(username);
        } else {
            return null;
        } 
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertUser(User u) {
        if (sc != null && sc.isValid()) {
            return User.Insert(u);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? UpdateUser(User u) {
        if (sc != null && sc.isValid()) {
            return User.Update(u);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? AuthUser(string username, string password) {
        if (sc != null && sc.isValid()) { // soap header credentials
            User u = new User(username);
            if (!u.empty && !u.locked) // user does not exist or is locked out
                return PasswordHash.PasswordHash.ValidatePassword(u.salt + password, u.password);
            else
                return false;
        } else { // soap header credentials failed
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? IsUsernameAvailable(string username) {
        // note: i'm not convinced we need this ... 
        if (sc != null && sc.isValid()) { // soap header credentials
            return !new User(username).empty;
        } else { // soap header credentials failed
            return null;
        }
    }

}
