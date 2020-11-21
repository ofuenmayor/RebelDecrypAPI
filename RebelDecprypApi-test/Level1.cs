using System;
using System.Collections.Generic;
using RebelDecrypApi.Domain;
using Xunit;

namespace RebelDecprypApi_test
{
  public class Level1
  {
    [Fact]
    public void Test0()
    {
      Satelite kenovi = new Satelite(-500, -200);

      Assert.Equal(-500, kenovi.Latitud());
    }

    [Fact]
    public void Test1()
    {
      Satelite kenovi = new Satelite(-500, -200);

      string[] array = { "es", "", "mensaje", "" };

      kenovi.InterceptarTransmicion(100, array);

      Assert.Equal(-500, kenovi.Latitud());
      Assert.Equal(array, kenovi.mensaje());
      Assert.Equal(100, kenovi.RadioEnemigoDetectado());
    }

    [Fact]
    public void Test2()
    {
      Satelite kenovi = new Satelite(-500, -200);
      Satelite skyWalker = new Satelite(100, -100);
      Satelite sato = new Satelite(500, 100);

      string[] array = { "", "", "", "" };

      kenovi.InterceptarTransmicion(100, array);
      skyWalker.InterceptarTransmicion(115.5, array);
      sato.InterceptarTransmicion(142.7, array);

      List<Satelite> SatelitesOperativos = new List<Satelite>();

      ReporteComputadoraCentral reporte = ComputadoraCentral.TriangularUbicacionDeLaNave(kenovi, skyWalker, sato);

      Assert.Equal(175.64547044709616, reporte.Latitud());
      Assert.Equal(405.07139776451913, reporte.Longitud());

    }
    [Fact]
    public void Test3()
    {
      Satelite kenovi = new Satelite(-500, -200);
      Satelite skyWalker = new Satelite(100, -100);
      Satelite sato = new Satelite(500, 100);

      string[] array1 = { "Este", "", "un", "" };
      string[] array2 = { "Este", "", "", "mensaje" };
      string[] array3 = { "", "es", "", "" };

      kenovi.InterceptarTransmicion(100, array1);
      skyWalker.InterceptarTransmicion(115.5, array2);
      sato.InterceptarTransmicion(142.7, array3);

      List<Satelite> SatelitesOperativos = new List<Satelite>();

      ReporteComputadoraCentral reporte = ComputadoraCentral.TriangularUbicacionDeLaNave(kenovi, skyWalker, sato);
      reporte.AgregarMensaje(ComputadoraCentral.DescifrarMensaje(kenovi, skyWalker, sato));

      Assert.Equal(175.64547044709616, reporte.Latitud());
      Assert.Equal(405.07139776451913, reporte.Longitud());
      Assert.Equal("Este es un mensaje", reporte.Mensaje());
    }
  }
}
