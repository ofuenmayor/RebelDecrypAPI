using System.Net;
using System.Data.Common;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using RebelDecrypApi.Controllers;
using RebelDecrypApi.Domain;
using Xunit;

namespace RebelDecprypApi_test
{
  public class Level2
  {
    [Fact]
    public void Test0()
    {
      try
      {
        var iLogger = new Mock<ILogger<TopSecretController>>();
        TopSecretController topSecretController = new TopSecretController(iLogger.Object);
        List<MensajeInterceptado> mensajes = new List<MensajeInterceptado>();

        MensajeInterceptado mensaje1 = CrearMensaje(100, "kenovi", new string[] { "este", "", "", "mensaje", "" });
        mensajes.Add(mensaje1);

        MensajeInterceptado mensaje2 = CrearMensaje(115.5, "skywalker", new string[] { "", "es", "", "", "secreto" });
        mensajes.Add(mensaje2);

        ReporteComputadoraCentral reporte = topSecretController.MensajeEntrante(mensajes);



      }
      catch (WebException ex)
      {
        Assert.NotNull(ex);
        // Assert.Equal(HttpStatusCode.NotFound, ex.Status);
      }
    }

    [Fact]
    public void Test1()
    {
      var iLogger = new Mock<ILogger<TopSecretController>>();
      TopSecretController topSecretController = new TopSecretController(iLogger.Object);
      List<MensajeInterceptado> mensajes = new List<MensajeInterceptado>();

      MensajeInterceptado mensaje1 = CrearMensaje(100, "kenovi", new string[] { "este", "", "", "mensaje", "" });
      mensajes.Add(mensaje1);

      MensajeInterceptado mensaje2 = CrearMensaje(115.5, "skywalker", new string[] { "", "es", "", "", "secreto" });
      mensajes.Add(mensaje2);

      MensajeInterceptado mensaje3 = CrearMensaje(142.7, "sato", new string[] { "este", "", "un", "", "" });
      mensajes.Add(mensaje3);

      ReporteComputadoraCentral reporte = topSecretController.MensajeEntrante(mensajes);

      Assert.Equal("este es un mensaje secreto", reporte.message);
      Assert.Equal(175.65, reporte.position.x);
      Assert.Equal(405.07, reporte.position.y);

    }

    private static MensajeInterceptado CrearMensaje(double distance, string satellite, string[] mensaje)
    {
      return new MensajeInterceptado()
      {
        distance = distance,
        name = satellite,
        mensaje = mensaje
      };
    }
  }
}
