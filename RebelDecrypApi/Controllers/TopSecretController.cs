using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RebelDecrypApi.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace RebelDecrypApi.Controllers
{
  [ApiController]
  public class TopSecretController : ControllerBase
  {

    private readonly ILogger<TopSecretController> _logger;
    private IMemoryCache _cache;

    public TopSecretController(ILogger<TopSecretController> logger, IMemoryCache cache)
    {
      _logger = logger;
      _cache = cache;
    }

    /// <summary>
    /// Rastrear nave imperial enemiga con la información de los 3 satelites
    /// </summary>
    /// <param name="mensajesCapturados">Mensajes capturados de los 3 satelites</param>
    /// <returns>coordenadas de la nave y el mensaje descifrado</returns>
    [HttpPost]
    [Route("topsecret")]
    public IActionResult MensajeEntrante([FromBody] InformacionEntrante mensajesCapturados)
    {
      try
      {
        if (mensajesCapturados.satellites.Count != 3)
        {
          return NotFound("");
        }
        return Ok(ComputadoraCentral.ProcesarInformacion(mensajesCapturados.satellites));
      }
      catch (Exception ex)
      {
        throw new Exception("Error de negocio");
      }
    }

    /// <summary>
    /// Captura la información de manera individual de cada satelite al compretar los 3 satelites se puede triangular la nave
    /// </summary>
    /// <param name="mensaje">Distancia des mensaje y mensaje</param>
    /// <param name="satelite"> Nombre del satelite</param>
    [HttpPost]
    [Route("topsecret_split/{satelite}")]
    public void MensajeDividido([FromBody] MensajeInterceptado mensaje, string satelite)
    {
      var mensajeCacheado = _cache.GetOrCreate<MensajeInterceptado>(satelite, _cache => mensaje);
    }

    /// <summary>
    /// Luego de cargada la información de los satelites con este endpoint se triangula la ubicación de la nave y se descubre el mensaje
    /// </summary>
    /// <param name="satelite">nombre del satelite</param>
    /// <returns> La ubicaición de la nave y el mensaje</returns>
    [HttpGet]
    [Route("topsecret_split/{satelite}")]
    public IActionResult MensajeDivididoObtenerReporte(string satelite)
    {
      try
      {
        InformacionEntrante informacion = new InformacionEntrante();
        informacion.satellites = new List<MensajeInterceptado>();
        informacion.satellites.Add(ComputadoraCentral.validarMensaje(_cache, "kenobi"));
        informacion.satellites.Add(ComputadoraCentral.validarMensaje(_cache, "skywalker"));
        informacion.satellites.Add(ComputadoraCentral.validarMensaje(_cache, "sato"));
        return MensajeEntrante(informacion);
      }
      catch (Exception ex)
      {
        return NotFound(ex.Message);
      }
    }
  }
}
