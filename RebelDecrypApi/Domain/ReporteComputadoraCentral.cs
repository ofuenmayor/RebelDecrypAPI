using System;
using System.Collections.Generic;

namespace RebelDecrypApi.Domain
{
  public class ReporteComputadoraCentral
  {
    private double latitud;
    private double longitud;
    private string mensaje;

    public ReporteComputadoraCentral(double latitud, double longitud)
    {
      this.latitud = latitud;
      this.longitud = longitud;
    }

    public double Latitud()
    {
      return latitud;
    }

    public double Longitud()
    {
      return longitud;
    }

    public string Mensaje()
    {
      return mensaje;
    }

    public void AgregarMensaje(string mensajeDesencriptado)
    {
      mensaje = mensajeDesencriptado;
    }
  }
}