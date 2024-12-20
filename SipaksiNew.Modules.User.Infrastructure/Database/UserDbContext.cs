﻿using Microsoft.EntityFrameworkCore;
using SipaksiNew.Modules.User.Application.Abstractions.Data;
using SipaksiNew.Modules.User.Infrastructure.User;

namespace SipaksiNew.Modules.User.Infrastructure.Database
{
    public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Domain.User.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.User.User>().ToTable(Schemas.User);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }

}
