﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaulBot.Data;

#nullable disable

namespace PaulBot.Migrations
{
    [DbContext(typeof(PaulBotDbContext))]
    partial class PaulBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaulBot.Discord.Verification.Models.MemberVerification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AzureId")
                        .HasColumnType("text")
                        .HasColumnName("azure_id");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_revoked");

                    b.Property<decimal>("MemberId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("member_id");

                    b.HasKey("Id")
                        .HasName("pk_verifications");

                    b.HasIndex("MemberId")
                        .IsUnique()
                        .HasDatabaseName("ix_verifications_member_id");

                    b.ToTable("verifications", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
