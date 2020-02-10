<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerService.aspx.cs" Inherits="ServiceApp.CustomerService" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:form id="form1" runat="server">--%>
        <h2>Customer Service List</h2>
        <br />
        <div>
            <asp:Label ID="addServiceLabel" runat="server" Text="Add a Service:"></asp:Label><br />
            <asp:dropdownlist runat="server" ID="ServiceDropDownList"> 
            </asp:dropdownlist><br />
            <asp:Label ID="Label2" runat="server" Text="Select a Customer:"></asp:Label><br />
            <asp:dropdownlist runat="server" ID="CustomerDropDownList"> 
            </asp:dropdownlist><br />
            <asp:Label ID="Label1" runat="server" Text="Expected Duration:"></asp:Label>
            <asp:TextBox ID="durationInput" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Add_Service_Btn"/>
        </div>
        <hr />
        <div> 
        <asp:ListView ID="ListView2" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" OnItemDataBound="ListView_ItemDataBound">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# "Service: " + Eval("serviceName") %>'> </asp:Label><br />
                <asp:Label runat="server" Text='<%# "Customer: " + Eval("customerName") %>'> </asp:Label><br />
                <asp:Label runat="server" Text='<%# "Rate: $" + Eval("rate") %>'></asp:Label><br />
                <asp:Label runat="server" Text='<%# "Expected Duration (minutes): " + Eval("expectedduration") %>'></asp:Label> 
                <br/> 
                <div id="toggleDetailsDiv" runat="server">
                    <asp:Label ID="ServiceID" runat="server" Text='<%# "Customer Gender: " + Eval("gender") %>'></asp:Label> 
                    <br />
                    <asp:Label ID="CustomerID" runat="server" Text='<%# "Certification Requirements: " + Eval("certificationrqts") %>'></asp:Label> 
                </div>
                <br/> 
                <asp:Button ID="DetailsButton" runat="server" CommandName="DetailsButton" Text='Details' />
                <asp:Button ID="UpdateButton" runat="server" CommandName="UpdateButton" Text='Edit Expected Duration' />
                <div id="toggleUpdateDiv" runat="server">
                    <asp:Label ID="DurationUpdateLabel" runat="server" Text='Updated Expected Duration (mins):'></asp:Label>
                    <asp:TextBox ID="updateDurationTextBox" runat="server" Text='<%# Eval("expectedduration") %>'></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" CommandName="SubmitUpdateButton" CommandArgument='<%# BitConverter.ToString((byte[])Eval("customerserviceid")) %>' Text='Submit' />
                    <asp:Button ID="Button4" runat="server" CommandName="CancelButton" Text='Cancel' />
                    <br/>
                </div>
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
