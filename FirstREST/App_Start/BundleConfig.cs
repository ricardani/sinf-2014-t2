using System.Web;
using System.Web.Optimization;

namespace FirstREST
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            bundles.Add(new ScriptBundle("~/bundles/AwesomeAngularMVCApp")
            .IncludeDirectory("~/Scripts/Controller", "*.js")
            .Include("~/Scripts/Controller/AwesomeAngularMVCApp.js"));

            bundles.Add(new ScriptBundle("~/bundles/MainApp")
            .Include("~/Scripts/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/Controllers")
            .Include(
                "~/Scripts/js/factories/AuthHttpResponseInterceptor.js",
                "~/Scripts/js/controllers/listOrdersController.js",
                "~/Scripts/js/controllers/loginControllers.js",
                "~/Scripts/js/controllers/orderControllers.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/BowerComponents")
            .Include(
                "~/Scripts/js/bower_components/jquery/jquery.js",
                "~/Scripts/js/bootstrap//bootstrap.min.js",
                "~/Scripts/js/bower_components/angular/jquery.js",
                "~/Scripts/js/bower_components/angular-animate/angular-animate.js",
                "~/Scripts/js/bower_components/angular-route/angular-route.js",
                "~/Scripts/js/bower_components/angular-resource/angular-resource.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/BootstrapCSS")
            .Include("~/Scripts/js/bower_components/bootstrap/dist/bootstrap.css"));
        }
    }
}