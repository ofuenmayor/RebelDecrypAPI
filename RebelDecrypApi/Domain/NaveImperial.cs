using System;
using System.Collections.Generic;

namespace RebelDecrypApi.Domain
{
  public class NaveImperial
  {
    private double radioDelMensaje;
    private string[] mensajeCapturado;
    public NaveImperial(double radioDelMensaje, string[] mensajeCapturado)
    {
      this.radioDelMensaje = radioDelMensaje;
      this.mensajeCapturado = mensajeCapturado;
    }

    internal string[] MensajeCapturado()
    {
      return mensajeCapturado;
    }

    internal double RadioMensaje()
    {
      return radioDelMensaje;
    }
  }
}