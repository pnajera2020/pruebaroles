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
    public class RolController : ControllerBase
    {
        private readonly ILogger<RolController> _logger = null;
        private readonly IBsRol _bsRol = null;

        public RolController(ILogger<RolController> logger, IBsRol bsRol)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bsRol = bsRol ?? throw new ArgumentNullException(nameof(bsRol));
        }

        /// <summary>
        /// Inserta un registro de Rol en base de datos
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información ingresada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPost("agregarRol")]
        public async Task<ActionResult> AgregarRol([FromBody]Rol rol)
        {
            ObjectResult result;
            long resultado;
            try
            {
                resultado = await _bsRol.AgregaRolJsonAsync(rol);
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
        /// Obtiene todos los registros de Rol activos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo Rol</returns>
        [HttpGet("obtenerRoles")]
        public async Task<ActionResult<IList<Rol>>> ObtenerRolesAsync()
        {
            ObjectResult valRet;
            _logger.LogInformation("ObtenerRolesAsync: INICIO");

            IList<Rol> listaRoles = null;
            try
            {
                listaRoles = await _bsRol.ObtenerRolesAsync();
                valRet = Ok(listaRoles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                valRet = StatusCode(StatusCodes.Status500InternalServerError, null);
            }
            _logger.LogInformation("ObtenerRolesAsync: FIN");
            return valRet;
        }

        /// <summary>
        /// Obtiene Rol por Id
        /// </summary>
        /// <param name="idRol">Identificador del Rol</param>
        /// <returns>Devuelve el objeto Rol seleccionado por ID</returns>
        [HttpGet("obtenerRolPorId/{idRol}")]
        public async Task<ActionResult<Rol>> ObtenerRolPorIdAsync(int idRol)
        {
            ObjectResult respuesta;
            _logger.LogInformation("ObtenerRolPorId: INICIO");
            _logger.LogDebug("idRol={idRol}", idRol);
            try
            {
                var resultado = await _bsRol.ObtenerRolPorIdAsync(idRol);
                respuesta = Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                respuesta = StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            _logger.LogInformation("ObtenerRolPorId: FIN");
            return respuesta;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de Rol
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información actualizada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPut("editarRolI/{idRol}")]
        public async Task<ActionResult> EditarRolI(int idRol, [FromBody]Rol Rol)
        {
            ObjectResult result;
            long resultado;
            try
            {
                Rol.IdRol = idRol;
                resultado = await _bsRol.EditarRolJsonAsync(Rol);
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
        /// Realiza la actualización de datos de un registro de Rol
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información actualizada</param>
        /// <returns>Mensaje "Registro exitoso" si la información se almacenó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpPut("editarRol")]
        public async Task<ActionResult> EditarRol([FromBody]Rol Rol)
        {
            ObjectResult result;
            long resultado;
            try
            {
                resultado = await _bsRol.EditarRolJsonAsync(Rol);
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
        /// Realiza una baja lógica del Rol
        /// </summary>
        /// <param name="idRol"/>Id del Rol a eliminar
        /// <returns>Mensaje "Borrado exitoso" si la baja lógica se realizó correctamente
        /// Mensaje "Intente nuevamente" en caso de algún error</returns>
        [HttpGet("eliminarRol/{idRol}")]
        public async Task<ActionResult<bool>> EliminarRolAsync(int idRol)
        {
            ObjectResult respuesta;
            _logger.LogInformation("EliminarRol: INICIO");
            _logger.LogDebug("idRol={idRol}", idRol);
            try
            {
                var resultado = await _bsRol.EliminarRolAsync(idRol);
                respuesta = Ok(resultado == 1 ? "Borrado exitoso" : "Intente nuevamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                respuesta = StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            _logger.LogInformation("EliminarRol: FIN");
            return respuesta;
        }
    }
}