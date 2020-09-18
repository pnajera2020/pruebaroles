﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20200918193837_e")]
    partial class e
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Data.CtPermiso", b =>
                {
                    b.Property<long>("PKIdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_permiso")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("b_Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .HasColumnName("ds_descripcion")
                        .HasColumnType("text");

                    b.HasKey("PKIdPermiso");

                    b.ToTable("cat_permiso");
                });

            modelBuilder.Entity("Data.CtRol", b =>
                {
                    b.Property<long>("PKIdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_rol")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("b_Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .HasColumnName("ds_descripcion")
                        .HasColumnType("text");

                    b.HasKey("PKIdRol");

                    b.ToTable("cat_rol");
                });

            modelBuilder.Entity("Data.TbRolPermiso", b =>
                {
                    b.Property<long>("PKIdRolPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id_rol_permiso")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Activo")
                        .HasColumnName("b_activo")
                        .HasColumnType("boolean");

                    b.Property<long>("FKIdPermiso")
                        .HasColumnName("id_permiso")
                        .HasColumnType("bigint");

                    b.Property<long>("FKIdRol")
                        .HasColumnName("id_rol")
                        .HasColumnType("bigint");

                    b.HasKey("PKIdRolPermiso");

                    b.HasIndex("FKIdPermiso");

                    b.HasIndex("FKIdRol");

                    b.ToTable("tb_rol_permiso");
                });

            modelBuilder.Entity("Data.TbRolPermiso", b =>
                {
                    b.HasOne("Data.CtPermiso", "FKIdPermisoNavigation")
                        .WithMany("TbRolPermiso")
                        .HasForeignKey("FKIdPermiso")
                        .HasConstraintName("fk_cat_permiso_id_permiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.CtRol", "FKIdRolNavigation")
                        .WithMany("TbRolPermiso")
                        .HasForeignKey("FKIdRol")
                        .HasConstraintName("fk_cat_rol_id_rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}