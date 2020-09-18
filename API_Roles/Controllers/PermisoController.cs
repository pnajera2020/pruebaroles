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
    public class PermisoController : ControllerBase
    {
        private readonly ILogger<PermisoController> _logger = null;
        private readonly IBsPermiso _bsPermiso = null;

        public PermisoController(ILogger<PermisoController> logger, IBsPermiso bsPermiso)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bsPermiso = bsPermiso ?? throw new ArgumentNullException(nameof(bsPermiso));
        }

        /// <summary>
        /// Inserta un registro de Permiso en base de datos
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información ingresada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPost("agregarPermiso")]
        public async Task<ActionResult> AgregarPermiso([FromBody]Permiso permiso)
        {
            ObjectResult result;
            long resultado;
            try
            {
                resultado = await _bsPermiso.AgregaPermisoJsonAsync(permiso);
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
        /// Obtiene todos los registros de Permiso activos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo Permiso</returns>
        [HttpGet("obtenerPermisos")]
        public async Task<ActionResult<IList<Permiso>>> ObtenerPermisosAsync()
        {
            ObjectResult valRet;
            _logger.LogInformation("ObtenerPermisosAsync: INICIO");

            IList<Permiso> listaPermisos = null;
            try
            {
                listaPermisos = await _bsPermiso.ObtenerPermisosAsync();
                valRet = Ok(listaPermisos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                valRet = StatusCode(StatusCodes.Status500InternalServerError, null);
            }
            _logger.LogInformation("ObtenerPermisosAsync: FIN");
            return valRet;
        }

        /// <summary>
        /// Obtiene Permiso por Id
        /// </summary>
        /// <param name="idPermiso">Identificador del Permiso</param>
        /// <returns>Devuelve el objeto Permiso seleccionado por ID</returns>
        [HttpGet("obtenerPermisoPorId/{idPermiso}")]
        public async Task<ActionResult<Permiso>> ObtenerPermisoPorIdAsync(int idPermiso)
        {
            ObjectResult respuesta;
            _logger.LogInformation("ObtenerPermisoPorId: INICIO");
            _logger.LogDebug("idPermiso={idPermiso}", idPermiso);
            try
            {
                var resultado = await _bsPermiso.ObtenerPermisoPorIdAsync(idPermiso);
                respuesta = Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                respuesta = StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            _logger.LogInformation("ObtenerPermisoPorId: FIN");
            return respuesta;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de Permiso
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información actualizada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPut("editarPermisoI/{idPermiso}")]
        public async Task<ActionResult> EditarPermisoI(int idPermiso, [FromBody]Permiso Permiso)
        {
            ObjectResult result;
            long resultado;
            try
            {
                Permiso.IdPermiso = idPermiso;
                resultado = await _bsPermiso.EditarPermisoJsonAsync(Permiso);
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
        /// Realiza la actualización de datos de un registro de Permiso
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información actualizada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPut("editarPermiso")]
        public async Task<ActionResult> EditarPermiso([FromBody]Permiso Permiso)
        {
            ObjectResult result;
            long resultado;
            try
            {
                resultado = await _bsPermiso.EditarPermisoJsonAsync(Permiso);
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
        /// Realiza una baja lógica del Permiso
        /// </summary>
        /// <param name="idPermiso"/>Id del Permiso a eliminar
        /// <returns>Mensaje "Borrado exitoso" si la baja lógica se realizó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpGet("eliminarPermiso/{idPermiso}")]
        public async Task<ActionResult<bool>> EliminarPermisoAsync(int idPermiso)
        {
            ObjectResult respuesta;
            _logger.LogInformation("EliminarPermiso: INICIO");
            _logger.LogDebug("idPermiso={idPermiso}", idPermiso);
            try
            {
                var resultado = await _bsPermiso.EliminarPermisoAsync(idPermiso);
                respuesta = Ok(resultado == 1 ? "Borrado exitoso" : "Intente nuevamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                respuesta = StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            _logger.LogInformation("EliminarPermiso: FIN");
            return respuesta;
        }
    }
}