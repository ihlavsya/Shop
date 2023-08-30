﻿using Microsoft.EntityFrameworkCore;
using Shop.Files;
using Shop.Orders;
using Shop.Products;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Shop.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ShopDbContext :
    AbpDbContext<ShopDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ShopConsts.DbTablePrefix + "YourEntities", ShopConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<Product>(p =>
        {
            p.ToTable(ShopConsts.DbTablePrefix + "Products", ShopConsts.DbSchema);
            p.ConfigureByConvention();
            p.Property(x => x.ProductCategory).IsRequired();
        });

        builder.Entity<File>(f =>
        {
			f.ToTable(ShopConsts.DbTablePrefix + "Files", ShopConsts.DbSchema);
			f.ConfigureByConvention();
			f.Property(x => x.Name).IsRequired();
            f.Property(x => x.Content).IsRequired();
			f.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).IsRequired();
		});

        builder.Entity<Order>(o =>
        {
            o.ToTable(ShopConsts.DbTablePrefix + "Orders", ShopConsts.DbSchema);
            o.ConfigureByConvention();
            o.Property(x => x.ReferenceNo).IsRequired();
            o.Property(x => x.TotalItemCount).IsRequired();
        });

        builder.Entity<OrderLine>(ol =>
        {
            ol.ToTable(ShopConsts.DbTablePrefix + "OrderLines", ShopConsts.DbSchema);
            ol.ConfigureByConvention();
            ol.HasKey(ol => new { ol.OrderId, ol.ProductId });
            ol.Property(x => x.Count).IsRequired();
        });
    }
}
