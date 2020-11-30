using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Registration_WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {

            if (nameField.Text.Equals(""))
            {
                errorLabel.Text = "Enter your name";
                return;
            }

            if (surnameField.Text.Equals(""))
            {
                errorLabel.Text = "Enter your surname";
                return;
            }

            if (personalCodeField.Text.Equals(""))
            {
                errorLabel.Text = "Enter your confirmation password";
                return;
            }

            if (/*programSelection.SelectedIndex == 0 ||*/ genderSelection.SelectedIndex == 0/* || modeSelection.SelectedIndex == 0*/)
            {
                errorLabel.Text = "Select Something";
                return;
            }

            if (addressField.Text.Equals(""))
            {
                errorLabel.Text = "Enter your username";
                return;
            }

            if (telephoneField.Text.Equals(""))
            {
                errorLabel.Text = "Enter your password";
                return;
            }
            if (programSelection.SelectedIndex == 0)
            {
                errorLabel.Text = "Select Something";
                return;
            }
            if (modeSelection.SelectedIndex == 0)
            {
                errorLabel.Text = "Select Something";
                return;
            }


            if (agreeCheck.Checked == false)
            {
                errorLabel.Text = "Accept our policy";
                return;
            }

            Response.Redirect("Default.aspx");
        }
    }
}