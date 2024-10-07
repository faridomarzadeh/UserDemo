using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserDemo.Models;
using UserDemo.Services;

namespace UserDemo.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        [Dependency]
        public IUserService UserService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Validate();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var email = txtEmailAddress.Text;
                var password = txtPassword.Text;
                var loggedUser = UserService.Login(email, password);
                if (loggedUser == null)
                {
                    lblError.Text = SharedResources.Messages.FAILED_LOGIN;
                }
                else
                {
                    SetUserSessions(loggedUser);
                    Response.Redirect(SharedResources.URLs.HOME, false);
                }
            }
            else
            {
                lblError.Text = SharedResources.Messages.REQUIRED;
            }
        }

        private void SetUserSessions(User loggedUser)
        {
            this.Session[SharedResources.Session.FULL_NAME] = loggedUser.FirstName + " " + loggedUser.LastName;
            this.Session[SharedResources.Session.USER_ID] = loggedUser.Id;
            this.Session[SharedResources.Session.ROLE_ID] = loggedUser.RoleId;
            this.Session[SharedResources.Session.LOGIN_DATE] = DateTime.Now;
        }
    }
}