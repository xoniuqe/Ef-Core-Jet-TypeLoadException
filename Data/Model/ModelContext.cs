using Microsoft.EntityFrameworkCore;

namespace EFCoreJetTesst.Model
{
    public class ModelContext : DbContext
    {
        public virtual DbSet<Model> Models { get; set; }

        public ModelContext()
        {
        }
        public ModelContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = "\\test.mdb";
            var connectionString =
                "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Engine Type=5;User ID=Admin; Data Source=\"{0}\";OLE DB Services = 0;Mode=Share Deny None;Jet OLEDB:Database Password=\"PASSWORD\";";
            optionsBuilder.UseJetOleDb(string.Format(connectionString, dbPath));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>();
        }
    }

    public class Model
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Model() { }


        public Model(int pID, string pName)
        {
            ID = pID;
            Name = pName;
        }
    }
}
