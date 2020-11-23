using System.Net;
using System.Data.Common;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using RebelDecrypApi.Controllers;
using RebelDecrypApi.Domain;
using Xunit;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

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
        var memoryCache = new Mock<IMemoryCache>();
        TopSecretController topSecretController = new TopSecretController(iLogger.Object, memoryCache.Object);
        List<MensajeInterceptado> mensajes = new List<MensajeInterceptado>();

        MensajeInterceptado mensaje1 = CrearMensaje(100, "kenovi", new List<string>() { "este", "", "", "mensaje", "" });
        mensajes.Add(mensaje1);

        MensajeInterceptado mensaje2 = CrearMensaje(115.5, "skywalker", new List<string>() { "", "es", "", "", "secreto" });
        mensajes.Add(mensaje2);


        InformacionEntrante mensajesInterceptados = new InformacionEntrante();

        mensajesInterceptados.satellites = mensajes;

        //        ReporteComputadoraCentral reporte = topSecretController.MensajeEntrante(mensajesInterceptados);



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
      var memoryCache = new Mock<IMemoryCache>();
      TopSecretController topSecretController = new TopSecretController(iLogger.Object, memoryCache.Object);
      List<MensajeInterceptado> mensajes = new List<MensajeInterceptado>();

      MensajeInterceptado mensaje1 = CrearMensaje(100, "kenobi", new List<string>() { "este", "", "", "mensaje", "" });
      mensajes.Add(mensaje1);

      MensajeInterceptado mensaje2 = CrearMensaje(115.5, "skywalker", new List<string>() { "", "es", "", "", "secreto" });
      mensajes.Add(mensaje2);

      MensajeInterceptado mensaje3 = CrearMensaje(142.7, "sato", new List<string>() { "este", "", "un", "", "" });
      mensajes.Add(mensaje3);

      InformacionEntrante mensajesInterceptados = new InformacionEntrante();
      mensajesInterceptados.satellites = mensajes;

      var reporte = (OkObjectResult)topSecretController.MensajeEntrante(mensajesInterceptados);
      ReporteComputadoraCentral reporteCentral = reporte.Value as ReporteComputadoraCentral;
      Assert.Equal("este es un mensaje secreto", reporteCentral.message);
      Assert.Equal(175.65, reporteCentral.position.x);
      Assert.Equal(405.07, reporteCentral.position.y);

    }

    private static MensajeInterceptado CrearMensaje(double distance, string satellite, List<string> mensaje)
    {
      return new MensajeInterceptado()
      {
        distance = distance,
        name = satellite,
        message = mensaje
      };
    }
  }
}
