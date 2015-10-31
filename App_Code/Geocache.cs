using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>geocache(id, ...)</summary>
public class Geocache {

    public Guid id { get; set; }
    public DateTime anniversary { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int difficulty { get; set; }
    public int terrain { get; set; }
    public int size { get; set; }
    public int status { get; set; }
    public Guid userid { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }

    public Geocache() {
       // todo: get from db table
    }

    public static bool? Insert(Geocache g) {
        // todo: insert into db table
        return false;
    }

    public static bool? Update(Geocache g) {
        // todo: update in db table
        return false;
    }

    public static bool? Delete(Guid id) {
        // todo: delete from db table
        return false;
    }

}