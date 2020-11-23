using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

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

    public static ReporteComputadoraCentral ProcesarInformacion(List<MensajeInterceptado> mensajes)
    {
      Satelite kenovi = new Satelite(-500, -200);
      MensajeInterceptado mensajeKenovi = mensajes.Where(m => m.name.ToLower() == "kenobi").FirstOrDefault();
      kenovi.InterceptarTransmicion(mensajeKenovi.distance, mensajeKenovi.message);

      Satelite skywalker = new Satelite(100, -100);
      MensajeInterceptado mensajeSkyWalker = mensajes.Where(m => m.name.ToLower() == "skywalker").FirstOrDefault();
      skywalker.InterceptarTransmicion(mensajeSkyWalker.distance, mensajeSkyWalker.message);

      Satelite sato = new Satelite(500, 100);
      MensajeInterceptado mensajeSato = mensajes.Where(m => m.name.ToLower() == "sato").FirstOrDefault();
      sato.InterceptarTransmicion(mensajeSato.distance, mensajeSato.message);

      ReporteComputadoraCentral reporte = TriangularUbicacionDeLaNave(kenovi, skywalker, sato);
      reporte.AgregarMensaje(DescifrarMensaje(kenovi, skywalker, sato));

      return reporte;
    }

    private static double CalcularDistanciaEntreDosPuntos(Satelite satelite1, Satelite satelite2)
    {
      return Math.Sqrt(Math.Pow((satelite1.Latitud() - (satelite1.Longitud())), 2) + Math.Pow(satelite2.Latitud() - (satelite2.Longitud()), 2));
    }

    public static string DescifrarMensaje(Satelite kenovi, Satelite skyWalker, Satelite sato)
    {
      StringBuilder mensaje = new StringBuilder();
      int arrayLength = kenovi.mensaje().Count;
      string[] mensajeArray = new string[arrayLength];

      for (var i = 0; i < arrayLength; i++)
      {
        List<string> aux = kenovi.mensaje();
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
      for (var i = 0; i < satelite.mensaje().Count; i++)
      {
        List<string> aux = satelite.mensaje();
        if (string.IsNullOrEmpty(aux[i]))
        {
          continue;
        }
        mensajeArray[i] = aux[i];
      }
    }

    public static MensajeInterceptado validarMensaje(IMemoryCache _cache, string satelite)
    {
      MensajeInterceptado mensaje = new MensajeInterceptado();
      _cache.TryGetValue(satelite, out mensaje);
      if (mensaje != null)
      {
        mensaje.name = satelite;
      }
      else
      {
        throw new Exception("Imposible determinar el mensaje y la ubicacion");
      }
      return mensaje;
    }
  }
}