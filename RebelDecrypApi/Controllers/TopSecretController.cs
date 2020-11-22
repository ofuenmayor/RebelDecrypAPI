﻿using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RebelDecrypApi.Domain;

namespace RebelDecrypApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TopSecretController : ControllerBase
  {

    private readonly ILogger<TopSecretController> _logger;

    public TopSecretController(ILogger<TopSecretController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    public ReporteComputadoraCentral MensajeEntrante([FromBody] InformacionEntrante mensajesCapturados)
    {
      try
      {
        if (mensajesCapturados.satellites.Count != 3)
        {
          throw new WebException();
        }

        return ComputadoraCentral.ProcesarInformacion(mensajesCapturados.satellites);
      }
      catch (WebException ex)
      {
        throw new WebException("", WebExceptionStatus.UnknownError);
      }
    }
  }
}
