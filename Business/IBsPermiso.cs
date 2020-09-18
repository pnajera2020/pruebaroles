using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IBsPermiso
    {
        /// <summary>
        /// Inserta un registro de Permiso en base de datos
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información ingresada</param>
        /// <returns>Variable de tipo entero indicando el identificador de Permiso si se insertó correctamente</returns>
        Task<long> AgregaPermisoJsonAsync(Permiso permiso);

        /// <summary>
        /// Obtiene todos los registros de Permiso activos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo Permiso</returns>
        Task<IList<Permiso>> ObtenerPermisosAsync();

        /// <summary>
        /// Obtiene Permiso por Id
        /// </summary>
        /// <param name="idPermiso">Identificador de la Permiso</param>
        /// <returns>Devuelve el objeto Permiso seleccionado por ID</returns>
        Task<Permiso> ObtenerPermisoPorIdAsync(int idPermiso);

        /// <summary>
        /// Realiza la actualización de datos de un registro de Permiso
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información actualizada</param>
        /// <returns>Regresa el identificador del registro actualizado en caso exitoso</returns>
        Task<long> EditarPermisoJsonAsync(Permiso permiso);

        /// <summary>
        /// Realiza una baja lógica de Permiso
        /// <param name="idPermiso"/>Id de Permiso a eliminar
        /// </summary>
        /// <returns>Regresa un 1 en caso exitoso, 0 si ocurre algún error</returns>
        Task<int> EliminarPermisoAsync(int idPermiso);
    }
}
