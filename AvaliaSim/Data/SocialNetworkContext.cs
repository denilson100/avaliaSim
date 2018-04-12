using DomainModel;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SocialNetworkContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public SocialNetworkContext()
            : base(Data.Properties.Settings.Default.DbConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}