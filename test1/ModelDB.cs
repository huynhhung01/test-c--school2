using System;
using System.Data.Entity;
using System.Linq;
using test1;
using test1.DTO;

namespace test1
{
    public class ModelDB : DbContext
    {
        // Your context has been configured to use a 'ModelDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Test_Thi.ModelDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelDB' 
        // connection string in the application configuration file.
        public ModelDB()
            : base("name=ModelDB")
        {
            Database.SetInitializer<ModelDB>(new CreatDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<HP> HPs { get; set; }
        public virtual DbSet<SV_HP> SV_HPs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           /* modelBuilder.Entity<SV>()
                .HasMany<HP>(s => s.HPs)
                .WithMany(c => c.SVs)
                .Map(cs =>
                {
                    cs.MapLeftKey("SVRefId");
                    cs.MapRightKey("HPRefId");
                    cs.ToTable("SV_HP");
                });*/
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}