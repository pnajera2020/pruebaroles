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
    public class BsPermiso : IBsPermiso
    {
        private readonly ApiDBContext context = null;
        public BsPermiso(ApiDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Inserta un registro de Permiso en base de datos
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información ingresada</param>
        /// <returns>Variable de tipo entero indicando el identificador de Permiso si se insertó correctamente</returns>
        public async Task<long> AgregaPermisoJsonAsync(Permiso permiso)
        {
            long resultado = 0;
            try
            {
                var itemPermiso = new CtPermiso
                {
                    Descripcion = permiso.Descripcion,
                    Activo = permiso.Activo
                };
                context.CtPermiso.Add(itemPermiso);
                await context.SaveChangesAsync();
                resultado = itemPermiso.PKIdPermiso;
            }
            catch (Exception e)
            {
                var message = $"Ocurrió un error al registrar el Permiso : {permiso.Descripcion}";
                throw new IOException(message, e);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene todos los registros de Permiso 
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo Permiso</returns>
        public async Task<IList<Permiso>> ObtenerPermisosAsync()
        {
            Task<List<Permiso>> listaPermiso;
            try
            {
                listaPermiso = context.CtPermiso.Select(x => new Permiso
                {
                    IdPermiso = x.PKIdPermiso,
                    Descripcion = x.Descripcion,
                    Activo = x.Activo
                }).OrderBy(x => x.IdPermiso).ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al obtener los Permisos.";
                throw new IOException(message, ex);
            }
            return await listaPermiso;
        }

        /// <summary>
        /// Obtiene Permiso por Id
        /// </summary>
        /// <param name="idPermiso">Identificador de la Permiso</param>
        /// <returns>Devuelve el objeto Permiso seleccionado por ID</returns>
        public async Task<Permiso> ObtenerPermisoPorIdAsync(int idPermiso)
        {
            Task<Permiso> Permiso;
            try
            {
                //Consulta para obtener Permiso
                Permiso = context.CtPermiso
                    .Where(x => x.PKIdPermiso == idPermiso)
                    .Select(x => new Permiso
                    {
                        IdPermiso = x.PKIdPermiso,
                        Descripcion = x.Descripcion,
                        Activo = x.Activo
                    }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al obtener el Permiso.";
                throw new IOException(message, ex);
            }
            return await Permiso;
        }

        /// <summary>
        /// Realiza la actualización de datos de un registro de Permiso
        /// </summary>
        /// <param name="Permiso">Objeto de tipo Permiso con la información actualizada</param>
        /// <returns>Regresa el identificador del registro actualizado en caso exitoso</returns>
        public async Task<long> EditarPermisoJsonAsync(Permiso Permiso)
        {
            long resultado = 0;
            try
            {
                CtPermiso objPermiso = context.CtPermiso.Where(x => x.PKIdPermiso == Permiso.IdPermiso).FirstOrDefault();
                objPermiso.PKIdPermiso = Permiso.IdPermiso;
                objPermiso.Descripcion = Permiso.Descripcion;
                objPermiso.Activo = Permiso.Activo;

                await context.SaveChangesAsync();
                resultado = objPermiso.PKIdPermiso;
            }
            catch (Exception e)
            {
                var message = $"Ocurrió un error al actualizar el Permiso.";
                throw new IOException(message, e);
            }
            return resultado;
        }

        /// <summary>
        /// Realiza una baja lógica de Permiso
        /// <param name="idPermiso"/>Id de Permiso a eliminar
        /// </summary>
        /// <returns>Regresa un 1 en caso exitoso, 0 si ocurre algún error</returns>
        public async Task<int> EliminarPermisoAsync(int idPermiso)
        {
            //Se inicializan variables
            int resultado = 0;

            try
            {
                CtPermiso objDelete = context.CtPermiso.Where(o => o.PKIdPermiso == idPermiso).FirstOrDefault();

                if (objDelete != null)
                {
                    objDelete.Activo = false;
                    await context.SaveChangesAsync();
                    resultado = 1;
                }
            }
            catch (Exception ex)
            {
                var message = $"Ocurrió un error al eliminar al Permiso.";
                throw new IOException(message, ex);
            }

            //Devuelve resultado
            return await Task.FromResult<int>(resultado);
        }
    }
}
