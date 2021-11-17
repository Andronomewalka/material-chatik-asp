﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalChatik;

namespace SignalChatik.Migrations
{
    [DbContext(typeof(ChatikContext))]
    [Migration("20211117120605_MessagesContentChanged")]
    partial class MessagesContentChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChannelChannel", b =>
                {
                    b.Property<int>("ConnectedChannelsId")
                        .HasColumnType("int");

                    b.Property<int>("ForChannelsId")
                        .HasColumnType("int");

                    b.HasKey("ConnectedChannelsId", "ForChannelsId");

                    b.HasIndex("ForChannelsId");

                    b.ToTable("ChannelChannels");
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthUserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthUserRoleId");

                    b.ToTable("AuthUsers");
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUserRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthUserId")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthUserId");

                    b.ToTable("AuthRefreshTokens");
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUserRole", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthRoles");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "User"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("SignalChatik.Models.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChannelTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ChannelTypeId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("SignalChatik.Models.ChannelType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChannelTypes");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "User"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Room"
                        });
                });

            modelBuilder.Entity("SignalChatik.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverChannelId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderChannelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverChannelId");

                    b.HasIndex("SenderChannelId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChannelChannel", b =>
                {
                    b.HasOne("SignalChatik.Models.Channel", null)
                        .WithMany()
                        .HasForeignKey("ConnectedChannelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignalChatik.Models.Channel", null)
                        .WithMany()
                        .HasForeignKey("ForChannelsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUser", b =>
                {
                    b.HasOne("SignalChatik.Models.AuthUserRole", null)
                        .WithMany("AuthUsers")
                        .HasForeignKey("AuthUserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUserRefreshToken", b =>
                {
                    b.HasOne("SignalChatik.Models.AuthUser", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AuthUserId");
                });

            modelBuilder.Entity("SignalChatik.Models.Channel", b =>
                {
                    b.HasOne("SignalChatik.Models.ChannelType", null)
                        .WithMany("Channels")
                        .HasForeignKey("ChannelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignalChatik.Models.Message", b =>
                {
                    b.HasOne("SignalChatik.Models.Channel", "ReceiverChannel")
                        .WithMany()
                        .HasForeignKey("ReceiverChannelId");

                    b.HasOne("SignalChatik.Models.Channel", "SenderChannel")
                        .WithMany()
                        .HasForeignKey("SenderChannelId");

                    b.Navigation("ReceiverChannel");

                    b.Navigation("SenderChannel");
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUser", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("SignalChatik.Models.AuthUserRole", b =>
                {
                    b.Navigation("AuthUsers");
                });

            modelBuilder.Entity("SignalChatik.Models.ChannelType", b =>
                {
                    b.Navigation("Channels");
                });
#pragma warning restore 612, 618
        }
    }
}
