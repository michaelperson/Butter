using Butter.DataAccess.Configs;
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
        public DbSet<UserEntity> Users { get; set; }
        //DbSet<FriendEntity> Friends { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Butter;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
             
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
