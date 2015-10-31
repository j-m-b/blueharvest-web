using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class LogbookService {

    public ServiceCredentials sc;

    [WebMethod]
    //[System.Xml.Serialization.XmlInclude(typeof(LogbookEntry))] // not sure if we need this
    [SoapHeader("sc")]
    public LogbookEntries GetLogbook(Guid id) {
        if (sc != null && sc.isValid()) {
            return new LogbookEntries(id);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertLogbook() {
        if (sc != null && sc.isValid()) {
            return Logbook.Insert();
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertLogbookEntry(LogbookEntry entry, Guid userid, Guid logbookid) {
        if (sc != null && sc.isValid()) {
            return LogbookEntry.Insert(entry, userid, logbookid);
        } else {
            return null;
        }
    }

}