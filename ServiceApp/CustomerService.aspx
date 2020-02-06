<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerService.aspx.cs" Inherits="ServiceApp.CustomerService" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%--    <asp:form id="form1" runat="server">--%>
        <h2>Customer Service Details</h2>
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="Add" />
        </div>
        <div> 
        <asp:ListView ID="ListView2" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("customerid") %>'> </asp:Label>
                <asp:Label runat="server" Text='<%# Eval("ServiceTypeID") %>'></asp:Label> 
                <asp:Label runat="server" Text='<%# Eval("ExpectedDuration") %>'></asp:Label> 
                <br> </br>
<%--                <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select" Text='<% #Eval("CustomerID") %>' />  --%>        
            </ItemTemplate>
        </asp:ListView>
     </div> 
<%--    </asp:form>--%>
</asp:Content>
