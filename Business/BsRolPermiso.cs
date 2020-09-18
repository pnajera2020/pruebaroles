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
    public class BsRolPermiso : IBsRolPermiso
    {
        private readonly ApiDBContext context = null;
        public BsRolPermiso(ApiDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Inserta un registro de RolPermiso en base de datos
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información ingresada</param>
        /// <returns>Variable de tipo entero indicando el identificador de RolPermiso si se insertó correctamente</returns>
        public async Task<long> AgregaRolPermisoJsonAsync(RolPermiso rolPermiso)
        {
            long resultado = 0;
            try
            {
                //Consulta para obtener RolPermiso
                TbRolPermiso objRolPermiso = context.TbRolPermiso.Where(x => x.FKIdRol == rolPermiso.IdRol && x.FKIdPermiso == rolPermiso.IdPermiso).FirstOrDefault();

                if (objRolPermiso == null)
                {
                    var itemRolPermiso = new TbRolPermiso
                    {
                        FKIdRol = rolPermiso.IdRol,
                        FKIdPermiso = rolPermiso.IdPermiso,
                        Activo = rolPermiso.Activo
                    };
                    context.TbRolPermiso.Add(itemRolPermiso);
                    await context.SaveChangesAsync();
                    resultado = itemRolPermiso.PKIdRolPermiso;
                }
                else
                {
                    objRolPermiso.FKIdRol = rolPermiso.IdRol;
                    objRolPermiso.FKIdPermiso = rolPermiso.IdPermiso;
                    objRolPermiso.Activo = true;

                    await context.SaveChangesAsync();
                    resultado = objRolPermiso.PKIdRolPermiso;
                }
            }
            catch (Exception e)
            {
                var message = $"Ocurrió un error al registrar el RolPermiso";
                throw new IOException(message, e);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene todos los registros de RolPermiso 
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo RolPermiso</returns>
        public async Task<IList<RolPermiso>> ObtenerRolPermisosAsync()
        {
            Task<List<RolPermiso>> listaRolPermiso;
            try
            {
                listaRolPermiso = context.TbRolPermiso.Select(x => new RolPermiso
                {
                    IdRolPermiso = x.PKIdRolPermiso,
                    IdRol = x.FKIdRol,
                    IdPermiso = x.FKIdPermiso,
                    Activo = x.Activo
                }).OrderBy(x => x.IdRolPermiso).ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al obtener los permisos por rol.";
                throw new IOException(message, ex);
            }
            return await listaRolPermiso;
        }

        /// <summary>
        /// Obtiene RolPermiso por Id
        /// </summary>
        /// <param name="idRolPermiso">Identificador de la RolPermiso</param>
        /// <returns>Devuelve el objeto RolPermiso seleccionado por ID</returns>
        public async Task<RolPermiso> ObtenerRolPermisoPorIdAsync(int idRolPermiso)
        {
            Task<RolPermiso> rolPermiso;
            try
            {
                //Consulta para obtener RolPermiso
                rolPermiso = context.TbRolPermiso
                    .Where(x => x.PKIdRolPermiso == idRolPermiso)
                    .Select(x => new RolPermiso
                    {
                        IdRolPermiso = x.PKIdRolPermiso,
                        IdRol = x.FKIdRol,
                        IdPermiso = x.FKIdPermiso,
                        Activo = x.Activo
                    }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al obtener el RolPermiso.";
                throw new IOException(message, ex);
            }
            return await rolPermiso;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de RolPermiso
        /// </summary>
        /// <param name="RolPermiso">Objeto de tipo RolPermiso con la información actualizada</param>
        /// <returns>Regresa el identificador del registro actualizado en caso exitoso</returns>
        public async Task<long> EditarRolPermisoJsonAsync(RolPermiso rolPermiso)
        {
            long resultado = 0;
            try
            {
                TbRolPermiso objRolPermiso = context.TbRolPermiso.Where(x => x.PKIdRolPermiso == rolPermiso.IdRolPermiso).FirstOrDefault();
                objRolPermiso.PKIdRolPermiso = rolPermiso.IdRolPermiso;
                objRolPermiso.FKIdRol = rolPermiso.IdRol;
                objRolPermiso.FKIdPermiso = rolPermiso.IdPermiso;
                objRolPermiso.Activo = rolPermiso.Activo;

                await context.SaveChangesAsync();
                resultado = objRolPermiso.PKIdRolPermiso;
            }
            catch (Exception e)
            {
                var message = $"Ocurrió un error al actualizar el RolPermiso.";
                throw new IOException(message, e);
            }
            return resultado;
        }

        /// <summary>
        /// Realiza una baja lógica de RolPermiso
        /// <param name="idRolPermiso"/>Id de RolPermiso a eliminar
        /// </summary>
        /// <returns>Regresa un 1 en caso exitoso, 0 si ocurre algún error</returns>
        public async Task<int> EliminarRolPermisoAsync(int idRolPermiso)
        {
            //Se inicializan variables
            int resultado = 0;

            try
            {
                TbRolPermiso objDelete = context.TbRolPermiso.Where(o => o.PKIdRolPermiso == idRolPermiso).FirstOrDefault();

                if (objDelete != null)
                {
                    objDelete.Activo = false;
                    await context.SaveChangesAsync();
                    resultado = 1;
                }
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al eliminar al RolPermiso.";
                throw new IOException(message, ex);
            }

            //Devuelve resultado
            return await Task.FromResult<int>(resultado);
        }
    }
}
