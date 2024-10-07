using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using UserDemo.Models;
using UserDemo.Models.DTO;

namespace UserDemo.App_Data
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(x => x.ProfilePicture)
                .IsOptional();

            modelBuilder.Entity<UserManagerRelation>()
                .HasKey(um => new { um.UserId, um.ManagerId });

            modelBuilder.Entity<UserManagerRelation>()
                .HasRequired<User>(um => um.Manager)
                .WithMany(u => u.Users)
                .HasForeignKey(f => f.ManagerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserManagerRelation>()
                .HasRequired(um=>um.User)
                .WithMany(u => u.Managers)
                .HasForeignKey(f=>f.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserManagerRelation> UserManagers { get; set; }
        public DbSet<LoginReport> LoginReports { get; set; }

        public List<UserReportDto> GetUserReports(int page, int numberofRows)
        {
            return this.Database.SqlQuery<UserReportDto>("exec UserReportsProcedure @PageNumber, @NumberOfRecordsToRetrieve",
                new Object[] {
                new SqlParameter("@PageNumber",page),
                new SqlParameter("@NumberOfRecordsToRetrieve", numberofRows) 
                }).ToList();
        }

        public int GetUserReportsCount()
        {
            var result = this.Database.SqlQuery<UserReportsCount>("UserReportsCountProcedure");
            return result.FirstOrDefault().Count;
        }
    }
}