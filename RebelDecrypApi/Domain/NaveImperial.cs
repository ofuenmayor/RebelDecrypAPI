using System;
using System.Collections.Generic;

namespace RebelDecrypApi.Domain
{
  public class NaveImperial
  {
    private double radioDelMensaje;
    private List<string> mensajeCapturado;
    public NaveImperial(double radioDelMensaje, List<string> mensajeCapturado)
    {
      this.radioDelMensaje = radioDelMensaje;
      this.mensajeCapturado = mensajeCapturado;
    }

    internal List<string> MensajeCapturado()
    {
      return mensajeCapturado;
    }

    internal double RadioMensaje()
    {
      return radioDelMensaje;
    }
  }
}