using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class GeocacheService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public Geocache GetGeocache(Guid id) {
        if (sc != null && sc.isValid()) {
            Geocache g = new Geocache(id);
            if (!g.empty) return new Geocache(id);
            else return null;
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public Geocache GetGeocacheByCode(string code) {
        if (sc != null && sc.isValid()) {
            Geocache g = new Geocache(code);
            if (!g.empty) return new Geocache(code);
            else return null;
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertGeocache(Geocache g) {
        if (sc != null && sc.isValid()) {
            return Geocache.Insert(g);
        } else {
            return null;
        }
    }

    /*
    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertGeocacheWithLocation(Geocache g, double latitude, double longitude) {
        if (sc != null && sc.isValid()) {
            return Geocache.Insert(g, latitude, longitude);
        } else {
            return null;
        }
    }
    */

    /*
    [WebMethod]
    [SoapHeader("sc")]
    public bool? UpdateGeocache(Geocache g) {
        if (sc != null && sc.isValid()) {
            return Geocache.Update(g);
        } else {
            return null;
        }
    }
    */

    /*
    [WebMethod]
    [SoapHeader("sc")]
    public bool? DeleteGeocache(Guid id) {
        if (sc != null && sc.isValid()) {
            return Geocache.Delete(id);
        } else {
            return null;
        }
    }
    */

    [WebMethod]
    [SoapHeader("sc")]
    public Geocaches GetGeocachesWithinDistance(
        double minlatrad, double maxlatrad,
        double minlngrad, double maxlngrad,
        double latrad, double lngrad, double distance) {
        if (sc != null && sc.isValid()) {
            return new Geocaches(
                minlatrad, maxlatrad,
                minlngrad, maxlngrad,
                latrad, lngrad, distance);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public Geocaches GetFavoriteGeocaches(Guid userid) {
        if (sc != null && sc.isValid()) {
            return new Geocaches(userid, Geocaches.type.favorite);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public Geocaches GetFoundGeocaches(Guid userid) {
        if (sc != null && sc.isValid()) {
            return new Geocaches(userid, Geocaches.type.found);
        } else {
            return null;
        }
    }

}