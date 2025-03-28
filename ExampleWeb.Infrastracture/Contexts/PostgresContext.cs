using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core;
using ExampleWeb.Domain;
using ExampleWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleWeb.Infrastracture.Contexts;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }


    /// <summary>
    /// Юзер
    /// </summary>
    public DbSet<User> UserSet { get; set; } = null!;



    /// <summary>
    /// Паспорт
    /// </summary>
    public DbSet<Passport> PassportSet { get; set; } = null!;


    /// <summary>
    /// Паспорт
    /// </summary>
    public DbSet<Contact> ContactSet { get; set; } = null!;

    /// <summary>
    /// Создание моделей
    /// </summary>
    /// <param name="modelBuilder"><see cref="ModelBuilder"/></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load(typeof(IInfrastructureAssembly).Namespace!));
    }
}
