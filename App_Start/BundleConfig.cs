using System.Web;
using System.Web.Optimization;

namespace VideoClubALFA
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

           

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                       "~/Content/font-awesome-4.7.0/css/font-awesome.css"));

            //Datatables
            bundles.Add(new StyleBundle("~/bundles/DataTables/css").Include(
                        "~/Content/DataTables/css/jquery.dataTables.css",
                        "~/Content/DataTables/Responsive/css/responsive.dataTables.min.css",
                        "~/Content/DataTables/Buttons/css/buttons.*"));
            bundles.Add(new Bundle("~/bundles/DataTables/js").Include(
                        "~/Scripts/DataTables/js/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/Responsive/js/dataTables.responsive.min.js",
                        "~/Scripts/DataTables/Buttons/js/dataTables.buttons.min.js",
                        "~/Scripts/DataTables/Buttons/js/buttons.*"));

            //Added for toaster
            bundles.Add(new StyleBundle("~/Content/toastr").Include(
                "~/Content/toastr.css"));
            bundles.Add(new Bundle("~/bundles/toastr").Include(
                       "~/Scripts/toastr.js*"));

            //Added for ALERTIFY JS
            bundles.Add(new StyleBundle("~/Content/alertify").Include(
               "~/Content/alertify.css",
               "~/Content/themes/semantic.css"));
            bundles.Add(new Bundle("~/bundles/alertify").Include(
                       "~/Scripts/alertify.js" ));

            //Added for MOMENT         
            bundles.Add(new Bundle("~/bundles/moment").Include(
                       "~/Scripts/moment.js"));

            // Jquery UI
            bundles.Add(new Bundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui.js"));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/overcast/jquery-ui.min.css"
              ));
        }
    }
}
