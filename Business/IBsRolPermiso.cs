using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IBsRolPermiso
    {
        /// <summary>
        /// Inserta un registro de RolPermiso en base de datos
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información ingresada</param>
        /// <returns>Variable de tipo entero indicando el identificador de RolPermiso si se insertó correctamente</returns>
        Task<long> AgregaRolPermisoJsonAsync(RolPermiso rolPermiso);

        /// <summary>
        /// Obtiene todos los registros de RolPermiso activos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo RolPermiso</returns>
        Task<IList<RolPermiso>> ObtenerRolPermisosAsync();

        /// <summary>
        /// Obtiene RolPermiso por Id
        /// </summary>
        /// <param name="idRolPermiso">Identificador de la RolPermiso</param>
        /// <returns>Devuelve el objeto RolPermiso seleccionado por ID</returns>
        Task<RolPermiso> ObtenerRolPermisoPorIdAsync(int idRolPermiso);

        /// <summary>
        /// Realiza la actualización de datos de un registro de RolPermiso
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información actualizada</param>
        /// <returns>Regresa el identificador del registro actualizado en caso exitoso</returns>
        Task<long> EditarRolPermisoJsonAsync(RolPermiso RolPermiso);

        /// <summary>
        /// Realiza una baja lógica de RolPermiso
        /// <param name="idRolPermiso"/>Id de RolPermiso a eliminar
        /// </summary>
        /// <returns>Regresa un 1 en caso exitoso, 0 si ocurre algún error</returns>
        Task<int> EliminarRolPermisoAsync(int idRolPermiso);
    }
}

