using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using BLL;
using BLL.Implementations;
using DAL.Common.Repositories;
using DAL.EF;
using DAL.EF.Repositories;
using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Mvc;

namespace TestApp.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();


            #region Core

            container.RegisterType<DbContext, EFContext>(new PerRequestLifetimeManager());

            #endregion

            #region Services

            container.RegisterType<IContactService, ContactService>();

            #endregion

            #region Repositories

            container.RegisterType<IContactRepository, EFContactRepository>();
            container.RegisterType<IDictionaryRepository, EFDictionaryRepository>();

            #endregion

            //#region Validators
            //AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
            //    .ForEach(x =>
            //    {
            //        container.RegisterType(x.InterfaceType, x.ValidatorType, new PerRequestLifetimeManager());
            //    })
            //    ;
            //#endregion
            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
