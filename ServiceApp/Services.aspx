<%@ Page Title="Services" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="ServiceApp.Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 ID="Title" runat="server">Services</h2>
    <asp:ListView ID="ListView1" runat="server">
        <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListViewServices" > 

            <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("NAME") %>'> </asp:Label>
                <asp:Label runat="server" Text='<%# Eval("CERTIFICATIONRQTS") %>'></asp:Label> 
                <asp:Label runat="server" Text='<%# Eval("RATE") %>'></asp:Label> 
                <br> 

            <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select" Text='<%# Eval("name") %>' />
            </ItemTemplate>
        </asp:ListView>
    </asp:ListView>
</asp:Content>
