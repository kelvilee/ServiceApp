<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerService.aspx.cs" Inherits="ServiceApp.CustomerService" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:form id="form1" runat="server">--%>
        <h2>Customer Service List</h2>
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="Add" />
        </div>
        <hr />
        <div> 
        <asp:ListView ID="ListView2" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" OnItemDataBound="ListView_ItemDataBound">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("name") %>'> </asp:Label>
                <asp:Label runat="server" Text='<%# Eval("certificationrqts") %>'></asp:Label> 
                <asp:Label runat="server" Text='<%# Eval("rate") %>'></asp:Label> 
                <asp:Label runat="server" Text='<%# Eval("expectedduration") %>'></asp:Label> 
                <br/> 
                <div id="toggleDiv" runat="server">
                    <asp:Label ID="ServiceID" runat="server" Text='<%# "Address: " + Eval("servicetypeid") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="CustomerServiceID" runat="server" Text='<%# "Manager ID: " + Eval("customerserviceid") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="CustomerID" runat="server" Text='<%# "Certified For: " + Eval("customerid") %>'></asp:Label> 
                </div>
                <br/> 
                <asp:Button ID="DetailsButton" runat="server" CommandName="DetailsButton" Text='Details' />
                <asp:Button ID="UpdateButton" runat="server" CommandName="UpdateButton" Text='Edit' />
                <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteButton" CommandArgument='<%# BitConverter.ToString((byte[])Eval("customerserviceid")) %>' Text='Delete' />

                <br />
                <asp:Label ID="DeleteConfirm" runat="server" Text=''></asp:Label> 
                <br/> <br />
                <hr />
            </ItemTemplate>
        </asp:ListView>
     </div> 
<%--    </asp:form>--%>
</asp:Content>
