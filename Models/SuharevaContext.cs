using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Acosta.Models;

public partial class SuharevaContext : DbContext
{
    public SuharevaContext()
    {
    }

    public SuharevaContext(DbContextOptions<SuharevaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceptance> Acceptances { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Outlet> Outlets { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductReport> ProductReports { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsAndEmployee> ProjectsAndEmployees { get; set; }

    public virtual DbSet<ProjectsAndOutlet> ProjectsAndOutlets { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TradeNetwork> TradeNetworks { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.ru;Port=5442;Database=Suhareva;Username=33P;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceptance>(entity =>
        {
            entity.HasKey(e => e.Acceptanceid).HasName("Acceptance_pkey");

            entity.ToTable("Acceptance");

            entity.Property(e => e.Acceptanceid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("acceptanceid");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeesid).HasName("Employees_pkey");

            entity.Property(e => e.Employeesid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("employeesid");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(30)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employees_role_fkey");
        });

        modelBuilder.Entity<Outlet>(entity =>
        {
            entity.HasKey(e => e.Outletid).HasName("Outlets_pkey");

            entity.Property(e => e.Outletid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("outletid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.TradeNetworks).HasColumnName("Trade networks");

            entity.HasOne(d => d.TradeNetworksNavigation).WithMany(p => p.Outlets)
                .HasForeignKey(d => d.TradeNetworks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Outlets_Trade networks_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("Products_pkey");

            entity.Property(e => e.Productid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("productid");
            entity.Property(e => e.Project).HasColumnName("project");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Project)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Products_project_fkey");
        });

        modelBuilder.Entity<ProductReport>(entity =>
        {
            entity.HasKey(e => e.Productreportid).HasName("Product reports_pkey");

            entity.ToTable("Product reports");

            entity.Property(e => e.Productreportid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("productreportid");
            entity.Property(e => e.Actualbalance).HasColumnName("actualbalance");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Pricetothecard).HasColumnName("pricetothecard");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.Virtualbalance).HasColumnName("virtualbalance");
            entity.Property(e => e.Visit).HasColumnName("visit");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.ProductReports)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product reports_product_fkey");

            entity.HasOne(d => d.VisitNavigation).WithMany(p => p.ProductReports)
                .HasForeignKey(d => d.Visit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product reports_visit_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("Projects_pkey");

            entity.Property(e => e.Projectid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("projectid");
            entity.Property(e => e.Numofvisitsperweek).HasColumnName("numofvisitsperweek");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ProjectsAndEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Projects and employees");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Projectid).HasColumnName("projectid");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Projects and employees_employeeid_fkey");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Projects and employees_projectid_fkey");
        });

        modelBuilder.Entity<ProjectsAndOutlet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Projects and outlets");

            entity.Property(e => e.Outletid).HasColumnName("outletid");
            entity.Property(e => e.Projectid).HasColumnName("projectid");

            entity.HasOne(d => d.Outlet).WithMany()
                .HasForeignKey(d => d.Outletid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Projects and outlets_outletid_fkey");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Projects and outlets_projectid_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("Roles_pkey");

            entity.Property(e => e.Roleid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("roleid");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TradeNetwork>(entity =>
        {
            entity.HasKey(e => e.Tradeid).HasName("Trade networks_pkey");

            entity.ToTable("Trade networks");

            entity.Property(e => e.Tradeid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("tradeid");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Visitid).HasName("Visits_pkey");

            entity.Property(e => e.Visitid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("visitid");
            entity.Property(e => e.Accepted).HasColumnName("accepted");
            entity.Property(e => e.Merchcomment)
                .HasMaxLength(200)
                .HasColumnName("merchcomment");
            entity.Property(e => e.Outlet).HasColumnName("outlet");
            entity.Property(e => e.Project).HasColumnName("project");
            entity.Property(e => e.Visitdate).HasColumnName("visitdate");
            entity.Property(e => e.Visittime).HasColumnName("visittime");

            entity.HasOne(d => d.AcceptedNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Accepted)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Visits_accepted_fkey");

            entity.HasOne(d => d.OutletNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Outlet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Visits_outlet_fkey");

            entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Project)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Visits_project_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
