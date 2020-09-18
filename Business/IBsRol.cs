using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IBsRol
    {
        /// <summary>
        /// Inserta un registro de Rol en base de datos
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información ingresada</param>
        /// <returns>Variable de tipo entero indicando el identificador de Rol si se insertó correctamente</returns>
        Task<long> AgregaRolJsonAsync(Rol rol);

        /// <summary>
        /// Obtiene todos los registros de Rol activos
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo Rol</returns>
        Task<IList<Rol>> ObtenerRolesAsync();

        /// <summary>
        /// Obtiene Rol por Id
        /// </summary>
        /// <param name="idRol">Identificador de la Rol</param>
        /// <returns>Devuelve el objeto Rol seleccionado por ID</returns>
        Task<Rol> ObtenerRolPorIdAsync(int idRol);

        /// <summary>
        /// Realiza la actualización de datos de un registro de Rol
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información actualizada</param>
        /// <returns>Regresa el identificador del registro actualizado en caso exitoso</returns>
        Task<long> EditarRolJsonAsync(Rol rol);

        /// <summary>
        /// Realiza una baja lógica de Rol
        /// <param name="idRol"/>Id de Rol a eliminar
        /// </summary>
        /// <returns>Regresa un 1 en caso exitoso, 0 si ocurre algún error</returns>
        Task<int> EliminarRolAsync(int idRol);
    }
}
