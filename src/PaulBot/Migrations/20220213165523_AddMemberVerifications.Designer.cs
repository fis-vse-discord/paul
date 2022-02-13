﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaulBot.Data;

#nullable disable

namespace PaulBot.Migrations
{
    [DbContext(typeof(PaulBotDbContext))]
    [Migration("20220213165523_AddMemberVerifications")]
    partial class AddMemberVerifications
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaulBot.Discord.Verification.Models.MemberVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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
