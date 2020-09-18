using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Roles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolPermisoController : ControllerBase
    {
        private readonly ILogger<RolPermisoController> _logger = null;
        private readonly IBsRolPermiso _bsRolPermiso = null;

        public RolPermisoController(ILogger<RolPermisoController> logger, IBsRolPermiso bsRolPermiso)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bsRolPermiso = bsRolPermiso ?? throw new ArgumentNullException(nameof(bsRolPermiso));
        }

        /// <summary>
        /// Inserta un registro de RolPermiso en base de datos
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información ingresada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPost("agregarRolPermiso")]
        public async Task<ActionResult> AgregarRolPermiso([FromBody]RolPermiso rolPermiso)
        {
            ObjectResult result;
            long resultado;
            try
            {
                resultado = await _bsRolPermiso.AgregaRolPermisoJsonAsync(rolPermiso);
                result = Ok(resultado >= 1 ? "Registro exitoso " : "Intente nuevamente");
            }
            catch (Exception ex)
            {
                resultado = 0;
                result = StatusCode(StatusCodes.Status500InternalServerError, resultado);
                _logger.LogInformation($"Ha ocurrido un error: {ex.Message.ToString()}");
            }
            return result;
        }

        /// <summary>
        /// Obtiene todos los registros de RolPermiso activos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo RolPermiso</returns>
        [HttpGet("obtenerRolPermisos")]
        public async Task<ActionResult<IList<RolPermiso>>> ObtenerRolPermisosAsync()
        {
            ObjectResult valRet;
            _logger.LogInformation("ObtenerRolPermisosAsync: INICIO");

            IList<RolPermiso> listaRolPermisos = null;
            try
            {
                listaRolPermisos = await _bsRolPermiso.ObtenerRolPermisosAsync();
                valRet = Ok(listaRolPermisos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                valRet = StatusCode(StatusCodes.Status500InternalServerError, null);
            }
            _logger.LogInformation("ObtenerRolPermisosAsync: FIN");
            return valRet;
        }

        /// <summary>
        /// Obtiene RolPermiso por Id
        /// </summary>
        /// <param name="idRolPermiso">Identificador del RolPermiso</param>
        /// <returns>Devuelve el objeto RolPermiso seleccionado por ID</returns>
        [HttpGet("obtenerRolPermisoPorId/{idRolPermiso}")]
        public async Task<ActionResult<RolPermiso>> ObtenerRolPermisoPorIdAsync(int idRolPermiso)
        {
            ObjectResult respuesta;
            _logger.LogInformation("ObtenerRolPermisoPorId: INICIO");
            _logger.LogDebug("idRolPermiso={idRolPermiso}", idRolPermiso);
            try
            {
                var resultado = await _bsRolPermiso.ObtenerRolPermisoPorIdAsync(idRolPermiso);
                respuesta = Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                respuesta = StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            _logger.LogInformation("ObtenerRolPermisoPorId: FIN");
            return respuesta;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de RolPermiso
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información actualizada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPut("editarRolPermisoI/{idRolPermiso}")]
        public async Task<ActionResult> EditarRolPermisoI(int idRolPermiso, [FromBody]RolPermiso RolPermiso)
        {
            ObjectResult result;
            long resultado;
            try
            {
                RolPermiso.IdRolPermiso = idRolPermiso;
                resultado = await _bsRolPermiso.EditarRolPermisoJsonAsync(RolPermiso);
                result = Ok(resultado >= 1 ? "Registro exitoso " : "Intente nuevamente");
            }
            catch (Exception ex)
            {
                resultado = 0;
                result = StatusCode(StatusCodes.Status500InternalServerError, resultado);
                _logger.LogInformation($"Ha ocurrido un error: {ex.Message.ToString()}");
            }
            return result;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de RolPermiso
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información actualizada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPut("editarRolPermiso")]
        public async Task<ActionResult> EditarRolPermiso([FromBody]RolPermiso RolPermiso)
        {
            ObjectResult result;
            long resultado;
            try
            {
                resultado = await _bsRolPermiso.EditarRolPermisoJsonAsync(RolPermiso);
                result = Ok(resultado >= 1 ? "Registro exitoso " : "Intente nuevamente");
            }
            catch (Exception ex)
            {
                resultado = 0;
                result = StatusCode(StatusCodes.Status500InternalServerError, resultado);
                _logger.LogInformation($"Ha ocurrido un error: {ex.Message.ToString()}");
            }
            return result;
        }

        /// <summary>
        /// Realiza una baja lógica del RolPermiso
        /// </summary>
        /// <param name="idRolPermiso"/>Id del RolPermiso a eliminar
        /// <returns>Mensaje "Borrado exitoso" si la baja lógica se realizó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpGet("eliminarRolPermiso/{idRolPermiso}")]
        public async Task<ActionResult<bool>> EliminarRolPermisoAsync(int idRolPermiso)
        {
            ObjectResult respuesta;
            _logger.LogInformation("EliminarRolPermiso: INICIO");
            _logger.LogDebug("idRolPermiso={idRolPermiso}", idRolPermiso);
            try
            {
                var resultado = await _bsRolPermiso.EliminarRolPermisoAsync(idRolPermiso);
                respuesta = Ok(resultado == 1 ? "Borrado exitoso" : "Intente nuevamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                respuesta = StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            _logger.LogInformation("EliminarRolPermiso: FIN");
            return respuesta;
        }
    }
}