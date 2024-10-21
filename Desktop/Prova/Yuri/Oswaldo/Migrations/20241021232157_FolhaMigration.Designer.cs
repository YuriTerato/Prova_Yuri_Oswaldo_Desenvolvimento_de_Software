﻿// <auto-generated />
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Oswaldo.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20241021232157_FolhaMigration")]
    partial class FolhaMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("API.Models.Folha", b =>
                {
                    b.Property<int>("folhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("impossoFgts")
                        .HasColumnType("REAL");

                    b.Property<double>("impostoInss")
                        .HasColumnType("REAL");

                    b.Property<double>("impostoIrrf")
                        .HasColumnType("REAL");

                    b.Property<int>("mes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<double>("salarioBruto")
                        .HasColumnType("REAL");

                    b.Property<double>("salarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<double>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("folhaId");

                    b.HasIndex("funcionarioId");

                    b.ToTable("Folha");
                });

            modelBuilder.Entity("API.Models.Funcionario", b =>
                {
                    b.Property<int>("funcionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("funcionarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("API.Models.Folha", b =>
                {
                    b.HasOne("API.Models.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("funcionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
