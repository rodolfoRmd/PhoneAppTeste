using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Contexto
{
    public class ContextPhone : DbContext, IContexto
    {

        public ContextPhone(DbContextOptions<ContextPhone> options) : base(options)
        { }

        #region DBSET
        public DbSet<Models.PhoneNumberType> PhoneTypes { get; set; }
        public DbSet<Models.PersonPhone> PersonPhones { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new Mapeamento.PhoneNumberTypeMAP());
            model.ApplyConfiguration(new Mapeamento.PersonPhoneMAP());
        }

        public override int SaveChanges()
        {

            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
