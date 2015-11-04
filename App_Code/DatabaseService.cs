using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class DatabaseService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public bool? DeleteAll() {
        if (sc != null && sc.isValid()) {
            return Database.DeleteAll();
        } else {
            return null;
        }
    }

}