using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RangoPorcentaje
/// </summary>
public class RangoPorcentaje
{
    private decimal id_municipio_centro;

    private decimal porcentaje;

    private bool isCentroZonal;



	public RangoPorcentaje()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public decimal getIdMunicipioCentro() {

        return this.id_municipio_centro;
    }

    public void setIdMunicipioCentro(decimal idMunicipioCentro) {
        this.id_municipio_centro = idMunicipioCentro;
    }

    public decimal getPorcentaje() {
        return this.porcentaje;
    }

    public void setPorcentaje(decimal porcentaje) {
        this.porcentaje = porcentaje;
    }

    public bool getIsCentroZonal() {
        return this.isCentroZonal;
    }

    public void setIsCentroZonal(bool isCentroZonal) {
        this.isCentroZonal = isCentroZonal;
    }

    
}