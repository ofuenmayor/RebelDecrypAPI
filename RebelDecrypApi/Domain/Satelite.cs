using System;
using System.Collections.Generic;

namespace RebelDecrypApi.Domain
{
  public class Satelite
  {
    private double latitud;
    private double longitud;
    private NaveImperial informacionNaveImperial;

    public Satelite(double latitud, double longitud)
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

    public void InterceptarTransmicion(double radioDeDistancia, List<string> mensaje)
    {
      informacionNaveImperial = new NaveImperial(radioDeDistancia, mensaje);
    }

    public List<string> mensaje()
    {
      return informacionNaveImperial.MensajeCapturado();
    }

    public double RadioEnemigoDetectado()
    {
      return informacionNaveImperial.RadioMensaje();
    }
  }
}