using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class ImageService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public Image GetImage(Guid id) {
        if (sc != null && sc.isValid()) {
            Image i = new Image(id);
            if (!i.empty) return i; else return null;
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertImage(Image i) {
        if (sc != null && sc.isValid()) {
            return Image.Insert(i);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? UpdateImage(Image i) {
        if (sc != null && sc.isValid()) {
            return Image.Update(i);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? DeleteImage(Guid id) {
        if (sc != null && sc.isValid()) {
            return Image.Delete(id);
        } else {
            return null;
        }
    }

}