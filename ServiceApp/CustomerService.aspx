<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerService.aspx.cs" Inherits="ServiceApp.CustomerService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
