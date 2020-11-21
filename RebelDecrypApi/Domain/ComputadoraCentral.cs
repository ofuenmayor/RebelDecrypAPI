using System.Text;
using System;
using System.Collections.Generic;

namespace RebelDecrypApi.Domain
{
  public class ComputadoraCentral
  {
    public static ReporteComputadoraCentral TriangularUbicacionDeLaNave(Satelite kenovi, Satelite skyWalker, Satelite sato)
    {
      double distancia = CalcularDistanciaEntreDosPuntos(kenovi, skyWalker);

      double latitud = (Math.Pow(kenovi.RadioEnemigoDetectado(), 2) - Math.Pow(skyWalker.RadioEnemigoDetectado(), 2) + Math.Pow(distancia, 2)) / (2 * distancia);
      double longitud = ((Math.Pow(kenovi.RadioEnemigoDetectado(), 2) - Math.Pow(skyWalker.RadioEnemigoDetectado(), 2) + Math.Pow(sato.Latitud(), 2) + Math.Pow(sato.Longitud(), 2)) / (2 * sato.Longitud())) - ((sato.Latitud() / sato.Longitud()) * latitud);

      return new ReporteComputadoraCentral(latitud, longitud);
    }

    private static double CalcularDistanciaEntreDosPuntos(Satelite satelite1, Satelite satelite2)
    {
      return Math.Sqrt(Math.Pow((satelite1.Latitud() - (satelite1.Longitud())), 2) + Math.Pow(satelite2.Latitud() - (satelite2.Longitud()), 2));
    }

    public static string DescifrarMensaje(Satelite kenovi, Satelite skyWalker, Satelite sato)
    {
      StringBuilder mensaje = new StringBuilder();
      int arrayLength = kenovi.mensaje().Length;
      string[] mensajeArray = new string[arrayLength];

      for (var i = 0; i < arrayLength; i++)
      {
        string[] aux = kenovi.mensaje();
        mensajeArray[i] = aux[i];
      }
      RecorrerMensaje(mensajeArray, skyWalker);
      RecorrerMensaje(mensajeArray, sato);

      for (var i = 0; i < arrayLength; i++)
      {
        mensaje.Append(mensajeArray[i]);
        if (i + 1 < arrayLength) { mensaje.Append(" "); }
      }

      return mensaje.ToString();
    }

    private static void RecorrerMensaje(string[] mensajeArray, Satelite satelite)
    {
      for (var i = 0; i < satelite.mensaje().Length; i++)
      {
        string[] aux = satelite.mensaje();
        if (string.IsNullOrEmpty(aux[i]))
        {
          continue;
        }
        mensajeArray[i] = aux[i];
      }
    }
  }
}