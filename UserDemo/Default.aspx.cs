using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using Unity.WebForms;
using UserDemo.App_Data;
using UserDemo.Migrations;
using UserDemo.Models.DTO;
using UserDemo.Services;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace UserDemo
{
    public partial class Default : System.Web.UI.Page
    {
        [Dependency]
        public UserContext UserContext { get; set; }

        [Dependency]
        public IUserService UserService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DbInitializer.Initialize(UserContext);
                if (IsUserLogged())
                {
                    WelcomeUser();
                    if (IsUserAdmin())
                    {
                        FetchData(1, 5);
                    }
                }
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl();
            }
        }

        private void FetchData(int pageNumber, int numberofRows)
        {
                var reports = UserContext.GetUserReports(pageNumber, numberofRows);

                PagedDataSource page = new PagedDataSource();
                page.AllowCustomPaging = true;
                page.AllowPaging = true;
                page.DataSource = reports;
                page.PageSize = 5;
                Repeater1.DataSource = page;
                Repeater1.DataBind();

                if (!IsPostBack)
                {
                    CreatePagingControl();
                }
        }

        private void CreatePagingControl()
        {
            int rowCount = UserContext.GetUserReportsCount();
            for (int i = 0; i < (rowCount / 5) + 1; i++)
            {
                LinkButton lnk = new LinkButton();
                lnk.Click += new EventHandler(lbl_Click);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                plcPaging.Controls.Add(lnk);
                Label spacer = new Label();
                spacer.Text = "&nbsp;";
                plcPaging.Controls.Add(spacer);
            }
        }

        void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            FetchData(currentPage,5);
        }

        private bool IsUserLogged()
        {
            if (this.Session[SharedResources.Session.USER_ID] != null)
            {
                return true;
            }
            return false;
        }

        private void WelcomeUser()
        {
            lblUserInfo.Text = "Hello " + this.Session[SharedResources.Session.FULL_NAME].ToString();

        }

        private bool IsUserAdmin()
        {
            var adminRole = UserContext.Roles.FirstOrDefault(i => i.RoleName == "Admin");
            if (this.Session[SharedResources.Session.ROLE_ID] != null)
            {
                return adminRole.Id == int.Parse(Session[SharedResources.Session.ROLE_ID].ToString());
            }
            return false;
        }

    }
}