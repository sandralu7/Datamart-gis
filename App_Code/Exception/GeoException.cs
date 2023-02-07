using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Clase encargada de describir una excepcion presentada.
/// </summary>
public class GeoException : Exception
{
    protected string myMessage;

    public string MyMessage
    {
        get { return this.myMessage; }
        set { this.myMessage = value; }
    }

}
