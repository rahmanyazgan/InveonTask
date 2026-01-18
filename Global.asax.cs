using System.Globalization;
using System.Threading;


public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
    }

    protected void Application_BeginRequest()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
    }
}
