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

            if (nameField.Text.Equals("") || surnameField.Text.Equals("") || personalCodeField.Text.Equals("") ||
                genderSelection.SelectedIndex == 0 || addressField.Text.Equals("") || telephoneField.Text.Equals("") ||
                programSelection.SelectedIndex == 0)
            {
                errorLabel.Text = "Fill/Select all Labels/Selections";
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