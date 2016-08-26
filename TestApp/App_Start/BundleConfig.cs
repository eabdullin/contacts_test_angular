using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace TestApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-animate/angular-animate.min.js",
                "~/Scripts/angular-aria/angular-aria.min.js",
                "~/Scripts/angular-material/angular-material.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/*.js"
                //"~/Scripts/app/app.js",
                //"~/Scripts/app/contact-controller.js",
                //"~/Scripts/app/contact-service.js",
                //"~/Scripts/app/dictionary-service.js",
                //"~/Scripts/app/contact-service.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/angular*",
                 "~/Content/Site.css"));
        }
    }
}
