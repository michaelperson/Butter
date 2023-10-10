﻿using Butter.DataAccess.Configs;
using Butter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.DataAccess
{
    public class ButterContext :DbContext
    {

        private readonly string _cnstr;
        public DbSet<UserEntity> Users { get; set; }
        //DbSet<FriendEntity> Friends { get; set; }

        /// <summary>
        /// Constructeur pour les migrations uniquement
        /// </summary>
        public ButterContext()
        {
            this._cnstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ButterDev;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        public ButterContext(string cnstr)
        {
            this._cnstr = cnstr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_cnstr);
             
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<UserEntity>(new UserConfig());
            modelBuilder.ApplyConfiguration<FriendEntity>(new FriendsConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
