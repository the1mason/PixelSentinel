using System;
using System.Collections.Generic;
using FluentMigrator.Runner.Versioning;
using Microsoft.EntityFrameworkCore;

namespace ServerIndex.Data;

public partial class IndexContext : DbContext
{
    public IndexContext()
    {
    }

    public IndexContext(DbContextOptions<IndexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnalyticServer> AnalyticServers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<ServerReaction> ServerReactions { get; set; }

    public virtual DbSet<ServerTag> ServerTags { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserServer> UserServers { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalyticServer>(entity =>
        {
            entity.ToTable("AnalyticServer");

            entity.HasIndex(e => e.Id, "IX_AnalyticServer_Id").IsUnique();

            entity.Property(e => e.Data).HasColumnType("json");

            entity.HasOne(d => d.Server).WithMany(p => p.AnalyticServers)
                .HasForeignKey(d => d.ServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnalyticServer_ServerId_Server_Id");
        });

        modelBuilder.Entity<MasScanHistory>(entity =>
        {
            entity.ToTable("MasScanHistory");

            entity.HasIndex(e => e.Id, "IX_MasScanHistory_Id").IsUnique();

            entity.Property(e => e.Date)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Range).HasMaxLength(512);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.Id, "IX_Role_Id").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Role_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(16);
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.ToTable("Server");

            entity.HasIndex(e => e.Id, "IX_Server_Id").IsUnique();

            entity.Property(e => e.Displayname).HasMaxLength(128);
            entity.Property(e => e.DomainName).HasMaxLength(512);
            entity.Property(e => e.GameVersion).HasMaxLength(16);
            entity.Property(e => e.LastMetadata).HasColumnType("json");
            entity.Property(e => e.LongDescription).HasMaxLength(2048);
            entity.Property(e => e.ShortDescription).HasMaxLength(128);
            entity.Property(e => e.Version)
                .HasDefaultValueSql("(now() AT TIME ZONE 'UTC'::text)")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Website).HasMaxLength(256);
        });

        modelBuilder.Entity<ServerReaction>(entity =>
        {
            entity.ToTable("ServerReaction");

            entity.HasIndex(e => e.Id, "IX_ServerReaction_Id").IsUnique();

            entity.HasOne(d => d.Server).WithMany(p => p.ServerReactions)
                .HasForeignKey(d => d.ServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServerReaction_ServerId_Server_Id");

            entity.HasOne(d => d.User).WithMany(p => p.ServerReactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ServerReaction_UserId_User_Id");
        });

        modelBuilder.Entity<ServerTag>(entity =>
        {
            entity.ToTable("ServerTag");

            entity.HasIndex(e => e.Id, "IX_ServerTag_Id").IsUnique();

            entity.Property(e => e.TagName).HasMaxLength(32);

            entity.HasOne(d => d.Server).WithMany(p => p.ServerTags)
                .HasForeignKey(d => d.ServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServerTag_ServerId_Server_Id");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Token);

            entity.ToTable("Session");

            entity.HasIndex(e => e.Token, "IX_Session_Token").IsUnique();

            entity.Property(e => e.Token).HasMaxLength(128);
            entity.Property(e => e.Version)
                .HasDefaultValueSql("(now() AT TIME ZONE 'UTC'::text)")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.HasIndex(e => e.Key, "IX_Settings_Key").IsUnique();

            entity.Property(e => e.Key).HasMaxLength(32);
            entity.Property(e => e.Value).HasMaxLength(2048);
            entity.Property(e => e.Version)
                .HasDefaultValueSql("(now() AT TIME ZONE 'UTC'::text)")
                .HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Tag");

            entity.HasIndex(e => e.DisplayName, "IX_Tag_DisplayName").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Tag_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(32);
            entity.Property(e => e.Data).HasColumnType("json");
            entity.Property(e => e.DisplayName).HasMaxLength(32);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "IX_User_Email").IsUnique();

            entity.HasIndex(e => e.Id, "IX_User_Id").IsUnique();

            entity.Property(e => e.DsplayName).HasMaxLength(24);
            entity.Property(e => e.Email).HasMaxLength(320);
            entity.Property(e => e.Password).HasMaxLength(96);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_RoleId_Role_Id");
        });

        modelBuilder.Entity<UserServer>(entity =>
        {
            entity.ToTable("UserServer");

            entity.HasIndex(e => e.Id, "IX_UserServer_Id").IsUnique();

            entity.HasOne(d => d.Server).WithMany(p => p.UserServers)
                .HasForeignKey(d => d.ServerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServer_ServerId_Server_Id");

            entity.HasOne(d => d.User).WithMany(p => p.UserServers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServer_UserId_User_Id");
        });

        modelBuilder.Entity<UserSession>(entity =>
        {
            entity.ToTable("UserSession");

            entity.HasIndex(e => e.Id, "IX_UserSession_Id").IsUnique();

            entity.Property(e => e.Displayname).HasMaxLength(32);
            entity.Property(e => e.SessionToken).HasMaxLength(128);

            entity.HasOne(d => d.SessionTokenNavigation).WithMany(p => p.UserSessions)
                .HasForeignKey(d => d.SessionToken)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSession_SessionToken_Session_Token");

            entity.HasOne(d => d.User).WithMany(p => p.UserSessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSession_UserId_User_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
