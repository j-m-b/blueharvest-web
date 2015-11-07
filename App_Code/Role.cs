using System;

/// <summary>role(id, name)</summary>
public class Role {

    public Guid id { get; set; }
    public string name { get; set; }

    public Role() { }

    public Role(Guid id, string name) {
        this.id = id;
        this.name = name;
    }

}