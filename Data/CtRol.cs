using System.Collections.Generic;

namespace Data
{
    public partial class CtRol
    {
        public CtRol()
        {
            TbRolPermiso = new HashSet<TbRolPermiso>();
        }

        public long PKIdRol { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TbRolPermiso> TbRolPermiso { get; set; }
    }
}