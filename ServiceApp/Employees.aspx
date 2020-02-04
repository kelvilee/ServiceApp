<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="ServiceApp.Employees" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div> 
        <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListView1" > 
           
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("name") %>'> </asp:Label>
                    <asp:Label runat="server" Text='<%# Eval("address") %>'></asp:Label> 
                    <br> </br>
                    <asp:Image id="pictureControlID" runat="server" AlternateText='<% #Eval("name") %>' ImageUrl='<%# "~/Desert.jpg" %>' />

              <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select" Text='<% #Eval("name") %>' />
           

</ItemTemplate>
        </asp:ListView> 
        <asp:Literal runat="server" ID="Literal1"></asp:Literal> 
    </div> 
</asp:Content>

