using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using connectivesportService.DataObjects;


namespace connectivesportService.Models
{
    public class connectivesportContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public connectivesportContext() : base(connectionStringName)
        {
        } 

        public DbSet<TodoItem> TodoItems { get; set; }
        


        /* Connective Sport Entities */
        public DbSet<User> Users { get; set; }

        public DbSet<UserHealthDetail> UserHealthDetail { get; set; }

        public DbSet<Friend> Friend { get; set; }

        public DbSet<Medal> Medals { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<SportType> SportTypes { get; set; }

        public DbSet<SportMembership> SportMemberships { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<UserStatus> UserStatus { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            modelBuilder.Entity<Friend>()
                        .HasRequired(m => m.AcceptUser)
                        .WithMany(t => t.AcceptFriends)
                        .HasForeignKey(m => m.AcceptUserId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Friend>()
                        .HasRequired(m => m.RequestUser)
                        .WithMany(t => t.RequestFriends)
                        .HasForeignKey(m => m.RequestUserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Achievement>()
                        .HasRequired(m => m.AchieveUser)
                        .WithMany(t => t.Achievements)
                        .HasForeignKey(m => m.AchieveUserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Achievement>()
                        .HasRequired(m => m.Medal)
                        .WithMany(t => t.Achievements)
                        .HasForeignKey(m => m.MedalId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sport>()
                        .HasRequired(m => m.SportType)
                        .WithMany(t => t.Sports)
                        .HasForeignKey(m => m.SportTypeId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<SportMembership>()
                        .HasRequired(m => m.Sport)
                        .WithMany(t => t.Memberships)
                        .HasForeignKey(m => m.SportId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<SportMembership>()
                        .HasRequired(m => m.User)
                        .WithMany(t => t.Memberships)
                        .HasForeignKey(m => m.UserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Challenge>()
                        .HasRequired(m => m.ChallengeeUser)
                        .WithMany(t => t.Challengees)
                        .HasForeignKey(m => m.ChallengeeUserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Challenge>()
                       .HasRequired(m => m.ChallengerUser)
                       .WithMany(t => t.Challengers)
                       .HasForeignKey(m => m.ChallengerUserId)
                       .WillCascadeOnDelete(false);

            modelBuilder.Entity<Goal>()
                        .HasRequired(m => m.User)
                        .WithMany(t => t.Goals)
                        .HasForeignKey(m => m.UserId)
                        .WillCascadeOnDelete(false);

        
                  

        }


    }

}
