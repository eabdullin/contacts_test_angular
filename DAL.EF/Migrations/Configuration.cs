using System.IO;
using System.Reflection;
using DAL.Common.Entities;
using Newtonsoft.Json.Linq;

namespace DAL.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.EF.EFContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            var jsonText = File.ReadAllText(folder + "MOCK_DATA.json");
            JArray jarray = JArray.Parse(jsonText);
            foreach (var jToken in jarray)
            {
                var contact = (JObject) jToken;
                string gender = contact["gender"].ToString();
                string genderId = string.Format("gender-{0}", gender.ToLower());

                if (!context.Dictionaries.Any(x => x.Id == genderId))
                {
                    context.Dictionaries.Add(new Gender()
                    {
                        Id = genderId,
                        Value = gender
                    });
                    context.SaveChanges();
                }
                var company = contact["company_name"].ToString();
                string companyId = string.Format("company-{0}", company.Replace(" ", "_").ToLower());
                if (!context.Dictionaries.Any(x => x.Id == companyId))
                {
                    context.Dictionaries.Add(new Company()
                    {
                        Id = companyId,
                        Value = company
                    });
                    context.SaveChanges();
                }
                var jobTitle = contact["job_title"].ToString();
                string jobTitleId = string.Format("job_title-{0}", jobTitle.Replace(" ", "_").ToLower());
                if (!context.Dictionaries.Any(x => x.Id == jobTitleId))
                {
                    context.Dictionaries.Add(new JobTitle()
                    {
                        Id = jobTitleId,
                        Value = jobTitle
                    });
                    context.SaveChanges();
                }

                var contactEntity = new Contact()
                {
                    Id = (long) contact["id"],
                    CompanyId = companyId,
                    JobTitleId = jobTitleId,
                    GenderId = genderId,
                    FirstName = contact["first_name"].ToString(),
                    LastName = contact["last_name"].ToString(),
                    Email = contact["email"].ToString(),
                    AvatarUrl = contact["avatar"].ToString(),
                    Phone = contact["phone"].ToString(),

                };
                context.Contacts.Add(contactEntity);
            }
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
