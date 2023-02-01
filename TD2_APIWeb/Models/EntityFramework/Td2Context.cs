using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TD2_APIWeb.Models.EntityFramework;

public partial class Td2Context : DbContext
{
    public Td2Context()
    {
    }

    public Td2Context(DbContextOptions<Td2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Serie> Series { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=TD2; uid=postgres; password=postgres;");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Serie>(entity =>
        {
            entity.HasKey(e => e.Serieid).HasName("serie_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);    
}
