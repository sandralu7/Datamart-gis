using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Rango
/// </summary>
public class Rango
{
    private String nombreRango;

    private decimal valorMinimo;

    private decimal valorMaximo;

	public Rango()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}


    public String getNombreRango() {
        return this.nombreRango;
    }

    public void setNombreRango(String nombreRango) {
        this.nombreRango = nombreRango;
    }

    public decimal getValorMinimo()
    {
        return this.valorMinimo;
    }

    public void setValorMinimo(decimal valorMinimo)
    {
        this.valorMinimo = valorMinimo;
    }

    public decimal getValorMaximo()
    {
        return this.valorMaximo;
    }

    public void setValorMaximo(decimal valorMaximo)
    {
        this.valorMaximo = valorMaximo;
    }
    

}