using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class LocationService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public Location GetLocation(Guid id) {
        if (sc != null && sc.isValid()) {
            return new Location(id);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertLocation(Location l) {
        if (sc != null && sc.isValid()) {
            return Location.Insert(l);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? UpdateLocation(Location l) {
        if (sc != null && sc.isValid()) {
            return Location.Update(l);
        } else {
            return null;
        }
    }

}