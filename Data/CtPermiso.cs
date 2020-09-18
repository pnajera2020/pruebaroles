using System.Collections.Generic;

namespace Data
{
    public partial class CtPermiso
    {
        public CtPermiso()
        {
            TbRolPermiso = new HashSet<TbRolPermiso>();
        }

        public long PKIdPermiso { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TbRolPermiso> TbRolPermiso { get; set; }
    }
}
