using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Clase que heredad de la clase GeoException y envia el mensaje de excepcion en
/// el mapa cuando se presenta.
/// </summary>
public class GeoMapException :GeoException
{
    public GeoMapException(String newMessage)
	{
        myMessage = newMessage;
	}
}
