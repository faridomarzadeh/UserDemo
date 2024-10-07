using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserDemo.Models;
using UserDemo.Pages.Validators;
using UserDemo.Services;

namespace UserDemo.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        [Dependency]
        public IUserService UserService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Validate();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if( Page.IsValid )
            {
                var user = GetUser();
                if(RegisterUserValidator.IsUserValid(user) )
                {
                    if(UserService.RegisterUser(user))
                    {
                        lblMessage.Text = SharedResources.Messages.SUCCESSFUL;
                    }
                    else
                    {
                        lblMessage.Text = SharedResources.Messages.USER_EXISTS;
                    }
                }
                else
                {
                    lblMessage.Text = SharedResources.Messages.INVALID_INPUT;
                }
            }
            else
            {
                lblMessage.Text = SharedResources.Messages.INVALID_INPUT;
            }
        }

        private User GetUser()
        {
            var user = new User();
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Email = txtEmail.Text;
            if(txtPassword.Text == txtConfirmPassword.Text )
            {
                user.Password = txtPassword.Text;
            }
            user.ProfilePicture = Upload();
            return user;
        }

        private string Upload()
        {
            int splitCount = fileUpload.FileName.Split('.').Length;
            string[] splitted = fileUpload.FileName.Split('.');
            string imageFormat = "." + splitted[splitCount-1];
            string imageName = splitted[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + imageFormat;
            string imagePath = Server.MapPath("~")+"/Images/" + imageName;
            if(RegisterUserValidator.IsValidImage(fileUpload.PostedFile)
                && RegisterUserValidator.IsImage(fileUpload.PostedFile))
            {
                fileUpload.SaveAs(imagePath);
                return imagePath;
            }
            return string.Empty;
        }
    }
}