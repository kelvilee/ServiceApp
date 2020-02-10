<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="ServiceApp.Employees" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div> 
        <h2>
            Employees List</h2>
         <hr />
        <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListViewEmployees" 
            OnItemDataBound="ListView_ItemDataBound" OnItemCommand="ListView_ItemCommand">
           
            <ItemTemplate>
                <asp:Label ID="Name" runat="server" Text='<%# "Name: " + Eval("NAME") %>'> </asp:Label>
                <br />
                 <asp:Label ID="Title" runat="server" Text='<%# "Job title: " + Eval("JOBTITLE") %>'> </asp:Label>
                <br />
                <div id="toggleDiv" runat="server">
                    <asp:Label ID="Address" runat="server" Text='<%# "Address: " + Eval("ADDRESS") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="ManagerID" runat="server" Text='<%# "Manager ID: " + Eval("MANAGERID") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="CertifiedFor" runat="server" Text='<%# "Certified For: " + Eval("CertifiedFor") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="StartDate" runat="server" Text='<%# "Start Date: " + Eval("STARTDATE") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="Salary" runat="server" Text='<%# "Salary: " + Eval("SALARY") %>'></asp:Label> 
                </div>

                <br/> 
                <asp:Button ID="DetailsButton" runat="server" CommandName="DetailsButton" Text='Details' />
                <asp:Button ID="UpdateButton" runat="server" CommandName="UpdateButton" Text='Update' />
                <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteButton" CommandArgument='<%# BitConverter.ToString((byte[])Eval("ID")) %>' Text='Delete' />

                <br />
                <asp:Label ID="DeleteConfirm" runat="server" Text=''></asp:Label> 
                <br/> <br />
                <hr />
            </ItemTemplate>
        </asp:ListView> 
        <asp:Literal runat="server" ID="Literal1"></asp:Literal> 
    </div> 
</asp:Content>

