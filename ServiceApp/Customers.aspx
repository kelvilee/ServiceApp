﻿<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ServiceApp.Customers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Customer</h2>
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
    <br />
    <br />
    <br />
    <h2>Customer List</h2>
    <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListView1">
        <ItemTemplate>
            <%--<asp:Image ID="pictureControlID" runat="server" Height="75px" Width="75px" ImageUrl='<% # "data:image;base64," + Convert.ToBase64String((byte[])Eval("picture")) %>'/>--%>
            <asp:Image ID="Image1" runat="server" Height="75px" Width="75px" ImageUrl='<%# (Eval("picture") != System.DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("picture")) : "https://muschealth.org/MUSCApps/HealthAssets/ProfileImages/NoImageProvided.png") %>'/>
            <asp:Label runat="server" Text='<%# Eval("name") %>'> </asp:Label>
            <asp:Label runat="server" Text='<%# Eval("address") %>'></asp:Label>
            <asp:Label runat="server" Text='<%# Eval("birthdate") %>'></asp:Label>
            <asp:Label runat="server" Text='<%# Eval("gender") %>'></asp:Label>
            <br />
            <br />
        </ItemTemplate>
    </asp:ListView>
    <asp:Literal runat="server" ID="Literal1"></asp:Literal>
</asp:Content>
