﻿using System;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://blueharvestgeo.com/webservices/")]
public class LogbookService {

    public ServiceCredentials sc;

    [WebMethod]
    [SoapHeader("sc")]
    public LogbookEntry GetLogbookEntry (Guid id) {
        if (sc != null && sc.isValid()) {
            return new LogbookEntry(id);
        } else {
            return null;
        }
    }

    [WebMethod]
    //[System.Xml.Serialization.XmlInclude(typeof(LogbookEntry))] // not sure if we need this
    [SoapHeader("sc")]
    public LogbookEntries GetLogbookEntries(Guid logbookid) {
        if (sc != null && sc.isValid()) {
            return new LogbookEntries(logbookid);
        } else {
            return null;
        }
    }

    [WebMethod]
    [SoapHeader("sc")]
    public Logbook GetLogbookWithEntries (Guid id) {
        if (sc != null && sc.isValid()) {
            return new Logbook(id);
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

    [WebMethod]
    [SoapHeader("sc")]
    public bool? InsertLogbookEntryByStrings(string title, string text, Guid userid, Guid logbookid) {
        if (sc != null && sc.isValid()) {
            LogbookEntry e = new LogbookEntry();
            e.title = title;
            e.text = text;
            return LogbookEntry.Insert(e, userid, logbookid);
        } else {
            return null;
        }
    }

}