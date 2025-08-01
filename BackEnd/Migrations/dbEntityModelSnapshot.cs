﻿// <auto-generated />
using CRUD_4t.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD_4t.Migrations
{
    [DbContext(typeof(dbEntity))]
    partial class dbEntityModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.7");

            modelBuilder.Entity("CRUD_4t.Models.Fazenda", b =>
                {
                    b.Property<int>("Cod_fazenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Area_HA")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_fazenda");

                    b.ToTable("Fazendas");
                });

            modelBuilder.Entity("CRUD_4t.Models.Movimentacao", b =>
                {
                    b.Property<int>("Cod_movimentacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cod_Fazenda")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cod_Operacao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cod_Produtor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_movimentacao");

                    b.HasIndex("Cod_Fazenda");

                    b.HasIndex("Cod_Operacao");

                    b.HasIndex("Cod_Produtor");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("CRUD_4t.Models.Operacao", b =>
                {
                    b.Property<int>("Cod_Operacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_Operacao");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("CRUD_4t.Models.Produtor", b =>
                {
                    b.Property<int>("Cod_Produtor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_Produtor");

                    b.ToTable("Produtores");
                });

            modelBuilder.Entity("CRUD_4t.Models.Movimentacao", b =>
                {
                    b.HasOne("CRUD_4t.Models.Fazenda", "Fazenda")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("Cod_Fazenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRUD_4t.Models.Operacao", "Operacao")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("Cod_Operacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRUD_4t.Models.Produtor", "Produtor")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("Cod_Produtor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fazenda");

                    b.Navigation("Operacao");

                    b.Navigation("Produtor");
                });

            modelBuilder.Entity("CRUD_4t.Models.Fazenda", b =>
                {
                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("CRUD_4t.Models.Operacao", b =>
                {
                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("CRUD_4t.Models.Produtor", b =>
                {
                    b.Navigation("Movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
