<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="ServiceApp.Employees" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div> 
        <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListViewEmployees" > 
           
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("NAME") %>'> </asp:Label>
                <asp:Label runat="server" Text='<%# Eval("ADDRESS") %>'></asp:Label> 
                <asp:Label runat="server" Text='<%# Eval("JOBTITLE") %>'></asp:Label> 
                <br> 

            <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select" Text='<%# Eval("name") %>' />
            </ItemTemplate>
        </asp:ListView> 
        <asp:Literal runat="server" ID="Literal1"></asp:Literal> 
    </div> 
</asp:Content>

