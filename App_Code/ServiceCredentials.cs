/// <summary>
///   Contains credentials for authenticating Web Services.
///   Any Web Service which provides sensitive information 
///   should include <code>[SoapHeader("sc")]</code> and used
///   like so:
///   <code>
///      if (sc != null && sc.isValid()) {
///          do something
///      } else {
///          don't do something
///      }
///   </code>
/// </summary>
public class ServiceCredentials : System.Web.Services.Protocols.SoapHeader {

    public string username { get; set; }
    public string password { get; set; }

    public bool isValid() {
        return this.username == System.Configuration.ConfigurationManager.AppSettings["wsusername"] &&
            this.password == System.Configuration.ConfigurationManager.AppSettings["wspassword"];
    }

}