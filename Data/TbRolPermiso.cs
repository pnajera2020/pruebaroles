using System.Collections.Generic;

namespace Data
{
    public partial class TbRolPermiso
    {
        public long PKIdRolPermiso { get; set; }
        public long FKIdRol { get; set; }
        public long FKIdPermiso { get; set; }
        public bool Activo { get; set; }
        public virtual CtRol FKIdRolNavigation { get; set; }
        public virtual CtPermiso FKIdPermisoNavigation { get; set; }
    }
}