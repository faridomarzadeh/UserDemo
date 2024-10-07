using System;
using Unity.WebForms;
using UserDemo.App_Start;
using UserDemo.Migrations;

namespace UserDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ConfiguRoutes();
            Migrate();
            var container = Application.GetContainer();
            UnityConfig.RegisterTypes(container);
        }
        private void ConfiguRoutes()
        {
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Login", "Login", "~/Pages/Login.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Register", "Register", "~/Pages/Register.aspx");

        }

        private void Migrate()
        {
            var configuration = new Configuration();
            var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
            migrator.Update();
        }
    }
}