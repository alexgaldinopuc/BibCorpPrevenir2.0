﻿// <auto-generated />
using System;
using BibCorpPrevenir.Persistence.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibCorpPrevenir.Persistence.Migrations
{
    [DbContext(typeof(BibCorpPrevenirContext))]
    partial class BibCorpPrevenirContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Acervos.Acervo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnoPublicacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Autor")
                        .HasColumnType("longtext");

                    b.Property<string>("CapaUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Comentarios")
                        .HasColumnType("longtext");

                    b.Property<string>("DataCriacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Edicao")
                        .HasColumnType("longtext");

                    b.Property<string>("Editora")
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("QtdPaginas")
                        .HasColumnType("int");

                    b.Property<int>("QtdeDisponivel")
                        .HasColumnType("int");

                    b.Property<int>("QtdeEmTransito")
                        .HasColumnType("int");

                    b.Property<int>("QtdeEmprestada")
                        .HasColumnType("int");

                    b.Property<string>("Resumo")
                        .HasColumnType("longtext");

                    b.Property<string>("SubTitulo")
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ISBN");

                    b.ToTable("Acervos");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Emprestimos.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Acao")
                        .HasColumnType("int");

                    b.Property<int>("AcervoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataPrevistaDevolucao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LocalDeColeta")
                        .HasColumnType("longtext");

                    b.Property<string>("LocalDeEntrega")
                        .HasColumnType("longtext");

                    b.Property<int>("PatrimonioId")
                        .HasColumnType("int");

                    b.Property<int>("QtdeDiasAtraso")
                        .HasColumnType("int");

                    b.Property<int>("QtdeDiasEmprestimo")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcervoId");

                    b.HasIndex("PatrimonioId");

                    b.HasIndex("UserName");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Patrimonios.Patrimonio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcervoId")
                        .HasColumnType("int");

                    b.Property<string>("Coluna")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataIndisponibilidade")
                        .HasColumnType("longtext");

                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Localizacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Posicao")
                        .HasColumnType("longtext");

                    b.Property<string>("Prateleira")
                        .HasColumnType("longtext");

                    b.Property<string>("Sala")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcervoId");

                    b.HasIndex("ISBN");

                    b.ToTable("Patrimonios");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Usuarios.Papel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NomeFuncao")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FotoURL")
                        .HasColumnType("longtext");

                    b.Property<string>("Localizacao")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Usuarios.UsuarioPapel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Emprestimos.Emprestimo", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Acervos.Acervo", "Acervo")
                        .WithMany()
                        .HasForeignKey("AcervoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibCorpPrevenir.Domain.Models.Patrimonios.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("PatrimonioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", null)
                        .WithMany("Emprestimos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Acervo");

                    b.Navigation("Patrimonio");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Patrimonios.Patrimonio", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Acervos.Acervo", "Acervo")
                        .WithMany("Patrimonios")
                        .HasForeignKey("AcervoId");

                    b.Navigation("Acervo");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Usuarios.UsuarioPapel", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Papel", "Papel")
                        .WithMany("UsuariosPapeis")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", "Usuario")
                        .WithMany("UsuariosPapeis")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Papel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Acervos.Acervo", b =>
                {
                    b.Navigation("Patrimonios");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Usuarios.Papel", b =>
                {
                    b.Navigation("UsuariosPapeis");
                });

            modelBuilder.Entity("BibCorpPrevenir.Domain.Models.Usuarios.Usuario", b =>
                {
                    b.Navigation("Emprestimos");

                    b.Navigation("UsuariosPapeis");
                });
#pragma warning restore 612, 618
        }
    }
}
