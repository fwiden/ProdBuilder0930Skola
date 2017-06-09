using System.Web.Optimization;

namespace ProdBuilder0920.web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/StyleSheet.css")
                .Include("~/Content/Site.css")
                .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include("~/Scripts/jquery*")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/main.js"));

        }
    }
}