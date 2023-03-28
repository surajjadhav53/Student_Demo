using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Student_Demo.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundle(BundleCollection bundles)
        {
            //script bundle
            bundles.Add(new ScriptBundle("~/bundles/alljs").Include(
                       "~/JS/jquery-3.6.0.js",
                       "~/JS/bootstrap.bundle.js",
                        "~/JS/jquery.validate.js",
                         "~/JS/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/bundles/allcss").Include(
                     "~/CSS/bootstrap.css"));


        }
    }
}