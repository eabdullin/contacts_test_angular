using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using DAL.Common.Entities;
using DAL.Common.Entities.Base;
using DAL.Common.Entities.Common;
using DAL.EF.Migrations;

namespace DAL.EF
{
    public class EFContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public EFContext() : base("Main")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync()
        {

            PreSaveAction();
            try
            {
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Debug.Fail(string.Format("Property: {0} Error: {1}", dbEx, validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                throw;
            }

        }

        public override int SaveChanges()
        {
            PreSaveAction();
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //_logger.ErrorFormat("Property: {0} Error: {1}", dbEx, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private void PreSaveAction()
        {
            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified).Where(
                    e => e.IsRelationship == false &&
                         e.Entity != null &&
                         e.Entity is IBaseEntity);

            var currentTime = DateTime.Now;

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as IBaseEntity;
                if (entityBase != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entityBase.CreatedDate = currentTime;
                    }

                    entityBase.LastModifiedDate = currentTime;

                }
            }
        }
    }
}