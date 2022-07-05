﻿// <auto-generated />
using System;
using Concesionaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Concesionaria.Migrations
{
    [DbContext(typeof(ConcesionariaContext))]
    [Migration("20220704083153_Migracion")]
    partial class Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Concesionaria.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanClienteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Concesionaria.Models.Factura", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MontoAbonado")
                        .HasColumnType("float");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("float");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("facturas");
                });

            modelBuilder.Entity("Concesionaria.Models.Plan", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CuotasRestantes")
                        .HasColumnType("int");

                    b.Property<double>("MontoAbonado")
                        .HasColumnType("float");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("float");

                    b.Property<int>("PlazoEntrega")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.Property<bool>("fueAprobado")
                        .HasColumnType("bit");

                    b.HasKey("ClienteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("planes");
                });

            modelBuilder.Entity("Concesionaria.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FueVendido")
                        .HasColumnType("bit");

                    b.Property<int>("Kilometros")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecioVenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RutaImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAuto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("vehiculos");
                });

            modelBuilder.Entity("Concesionaria.Models.Vendedor", b =>
                {
                    b.Property<int>("IdVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVendedor"), 1L, 1);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVendedor");

                    b.ToTable("vendedores");
                });

            modelBuilder.Entity("Concesionaria.Models.Cliente", b =>
                {
                    b.HasOne("Concesionaria.Models.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanClienteId");

                    b.HasOne("Concesionaria.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId");

                    b.Navigation("Plan");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Concesionaria.Models.Factura", b =>
                {
                    b.HasOne("Concesionaria.Models.Cliente", "Cliente")
                        .WithOne("Factura")
                        .HasForeignKey("Concesionaria.Models.Factura", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Concesionaria.Models.Plan", b =>
                {
                    b.HasOne("Concesionaria.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Concesionaria.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Concesionaria.Models.Cliente", b =>
                {
                    b.Navigation("Factura");
                });
#pragma warning restore 612, 618
        }
    }
}
