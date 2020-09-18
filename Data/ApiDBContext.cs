using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { }

        //Creación de tablas
        public DbSet<CtRol> CtRol { get; set; }
        public DbSet<CtPermiso> CtPermiso { get; set; }
        public DbSet<TbRolPermiso> TbRolPermiso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<CtRol>(entity =>
            {
                entity.HasKey(e => e.PKIdRol);
                entity.ToTable("cat_rol");
                entity.Property(e => e.PKIdRol).HasColumnName("id_rol");
                entity.Property(e => e.Descripcion).HasColumnName("ds_descripcion");
                entity.Property(e => e.Activo).HasColumnName("b_Activo");
            });

            modelBuilder.Entity<CtPermiso>(entity =>
            {
                entity.HasKey(e => e.PKIdPermiso);
                entity.ToTable("cat_permiso");
                entity.Property(e => e.PKIdPermiso).HasColumnName("id_permiso");
                entity.Property(e => e.Descripcion).HasColumnName("ds_descripcion");
                entity.Property(e => e.Activo).HasColumnName("b_Activo");
            });

            modelBuilder.Entity<TbRolPermiso>(entity =>
            {
                entity.HasKey(e => e.PKIdRolPermiso);
                entity.ToTable("tb_rol_permiso");
                entity.Property(e => e.PKIdRolPermiso).HasColumnName("id_rol_permiso");
                entity.Property(e => e.FKIdRol).HasColumnName("id_rol");
                entity.Property(e => e.FKIdPermiso).HasColumnName("id_permiso");
                entity.Property(e => e.Activo).HasColumnName("b_activo");

                entity.HasOne(d => d.FKIdRolNavigation)
                    .WithMany(p => p.TbRolPermiso)
                    .HasForeignKey(d => d.FKIdRol)
                    .HasConstraintName("fk_cat_rol_id_rol");

                entity.HasOne(d => d.FKIdPermisoNavigation)
                    .WithMany(p => p.TbRolPermiso)
                    .HasForeignKey(d => d.FKIdPermiso)
                    .HasConstraintName("fk_cat_permiso_id_permiso");
            });
        }
    }
}

