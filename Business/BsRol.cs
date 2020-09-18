using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class BsRol : IBsRol
    {
        private readonly ApiDBContext context = null;
        public BsRol(ApiDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Inserta un registro de Rol en base de datos
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información ingresada</param>
        /// <returns>Variable de tipo entero indicando el identificador de Rol si se insertó correctamente</returns>
        public async Task<long> AgregaRolJsonAsync(Rol rol)
        {
            long resultado = 0;
            try
            {
                var itemRol = new CtRol
                {
                    Descripcion = rol.Descripcion,
                    Activo = rol.Activo
                };
                context.CtRol.Add(itemRol);
                await context.SaveChangesAsync();
                resultado = itemRol.PKIdRol;
            }
            catch (Exception e)
            {
                var message = $"Ocurrió un error al registrar el Rol : {rol.Descripcion}";
                throw new IOException(message, e);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene todos los registros de Rol 
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo Rol</returns>
        public async Task<IList<Rol>> ObtenerRolesAsync()
        {
            Task<List<Rol>> listaRol;
            try
            {
                listaRol = context.CtRol.Select(x => new Rol
                {
                    IdRol = x.PKIdRol,
                    Descripcion = x.Descripcion,
                    Activo = x.Activo
                }).OrderBy(x => x.IdRol).ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al obtener los Roles.";
                throw new IOException(message, ex);
            }
            return await listaRol;
        }

        /// <summary>
        /// Obtiene Rol por Id
        /// </summary>
        /// <param name="idRol">Identificador de la Rol</param>
        /// <returns>Devuelve el objeto Rol seleccionado por ID</returns>
        public async Task<Rol> ObtenerRolPorIdAsync(int idRol)
        {
            Task<Rol> Rol;
            try
            {
                //Consulta para obtener Rol
                Rol = context.CtRol
                    .Where(x => x.PKIdRol == idRol)
                    .Select(x => new Rol
                    {
                        IdRol = x.PKIdRol,
                        Descripcion = x.Descripcion,
                        Activo = x.Activo
                    }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al obtener el Rol.";
                throw new IOException(message, ex);
            }
            return await Rol;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de Rol
        /// </summary>
        /// <param name="Rol">Objeto de tipo Rol con la información actualizada</param>
        /// <returns>Regresa el identificador del registro actualizado en caso exitoso</returns>
        public async Task<long> EditarRolJsonAsync(Rol rol)
        {
            long resultado = 0;
            try
            {
                CtRol objRol = context.CtRol.Where(x => x.PKIdRol == rol.IdRol).FirstOrDefault();
                objRol.PKIdRol = rol.IdRol;
                objRol.Descripcion = rol.Descripcion;
                objRol.Activo = rol.Activo;

                await context.SaveChangesAsync();
                resultado = objRol.PKIdRol;
            }
            catch (Exception e)
            {
                var message = $"Ocurrió un error al actualizar el Rol.";
                throw new IOException(message, e);
            }
            return resultado;
        }

        /// <summary>
        /// Realiza una baja lógica de Rol
        /// <param name="idRol"/>Id de Rol a eliminar
        /// </summary>
        /// <returns>Regresa un 1 en caso exitoso, 0 si ocurre algún error</returns>
        public async Task<int> EliminarRolAsync(int idRol)
        {
            //Se inicializan variables
            int resultado = 0;

            try
            {
                CtRol objDelete = context.CtRol.Where(o => o.PKIdRol == idRol).FirstOrDefault();

                if (objDelete != null)
                {
                    objDelete.Activo = false;
                    await context.SaveChangesAsync();
                    resultado = 1;
                }
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al eliminar al Rol.";
                throw new IOException(message, ex);
            }

            //Devuelve resultado
            return await Task.FromResult<int>(resultado);
        }
    }
}
