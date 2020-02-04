<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ServiceApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customer</h1>
    <br />
    <asp:Label ID="nameLabel" runat="server" Text="Name:"></asp:Label><br />
    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox><br />
    <asp:Label ID="addressLabel" runat="server" Text="Address:"></asp:Label><br />
    <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="maleRadioLbl" runat="server" Text="Male:"></asp:Label><asp:RadioButton ID="maleRadioBtn" GroupName="gender" runat="server" />
    <asp:Label ID="femaleRadioLbl" runat="server" Text="Female:"></asp:Label><asp:RadioButton ID="femaleRadioBtn" GroupName="gender" runat="server" />
    <asp:Calendar ID="birthCalendar" runat="server"></asp:Calendar>
    <br />
    <asp:Label ID="imageLabel" runat="server" Text="Image:"></asp:Label><asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="UploadBtn" runat="server" Text="Submit" OnClick="UploadBtn_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>

</asp:Content>
