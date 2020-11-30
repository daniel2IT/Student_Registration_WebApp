<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Student_Registration_WebApp.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <div style="padding-top:20px; width:300px;">
        <div>
            <asp:Label ID="Label1" runat="server" Width="100%" Text="Name:"></asp:Label>
            <asp:TextBox ID="nameField" runat="server" Width="100%" Text=""></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Width="100%" Text="Surname:"></asp:Label>
            <asp:TextBox ID="surnameField" runat="server" Width="100%" Text=""></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="Label3" runat="server" Width="100%" Text="Personal code:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="100%" Text=""></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Width="100%" Text="Gender:"></asp:Label>
            <asp:DropDownList ID="genderSelection" runat="server" Width="30%">
                <asp:ListItem Value="0">Gender</asp:ListItem>
                <asp:ListItem Value="1">Male</asp:ListItem>
                <asp:ListItem Value="2">Female</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Width="100%" Text="Address:"></asp:Label>
            <asp:TextBox ID="usernameField" runat="server" Width="100%" Text=""></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Width="100%" Text="Telephone Number:"></asp:Label>
            <asp:TextBox ID="passwordField" runat="server" Width="100%" Text=""></asp:TextBox>
        </div>
      <div>
            <asp:Label ID="Label7" runat="server" Width="100%" Text="Study Program:"></asp:Label>
            <asp:DropDownList ID="programSelection" runat="server" Width="50%">
                <asp:ListItem Value="0">Study Program</asp:ListItem>
                <asp:ListItem Value="1">Electronics engineering</asp:ListItem>
                <asp:ListItem Value="2">Information systems</asp:ListItem>
                <asp:ListItem Value="3">Computer engineering</asp:ListItem>
                <asp:ListItem Value="4">Computer systems</asp:ListItem>
                <asp:ListItem Value="5">Software systems</asp:ListItem>
                <asp:ListItem Value="6">Telecommunication systems</asp:ListItem>
            </asp:DropDownList>
      </div>
      <div>
            <asp:Label ID="Label8" runat="server" Width="100%" Text="Mode Of Study:"></asp:Label>
            <asp:DropDownList ID="modeSelection" runat="server" Width="40%">
                <asp:ListItem Value="0">Mode Of Study</asp:ListItem>
                <asp:ListItem Value="1">Full-time</asp:ListItem>
                <asp:ListItem Value="2">Part-time</asp:ListItem>
            </asp:DropDownList>
      </div>
        <div>
            <asp:CheckBox ID="agreeCheck" Checked="false" Width="100%" runat="server" Text="Agree to policy" />
        </div>
        <div style="text-align:center;">
            <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Width="100%" Text=""></asp:Label>
        </div>
        <div style="padding-top: 10px;">
           
        </div>
    </div>
</asp:Content>
