<%@ Page Title="Services" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="ServiceApp.Services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 ID="AddHeader" runat="server">Add Service</h2>
    <br />
    <asp:Label ID="nameLabel" runat="server" Text="Name:"></asp:Label><br/>
    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox><br/>
    <asp:Label ID="requirementsLabel" runat="server" Text="Requirements:"></asp:Label><br/>
    <asp:TextBox ID="requirementsTextBox" runat="server"></asp:TextBox><br/>
    <asp:Label ID="rateLabel" runat="server" Text="Rate:"></asp:Label><br/>
    <asp:TextBox ID="rateTextBox" runat="server"></asp:TextBox><br/>
    <br />
    <asp:Button ID="UploadBtn" runat="server" Text="Submit" OnClick="UploadBtn_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <h2 ID="ListHeader" runat="server">Services List</h2>
    <br />
    <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListViewServices" OnItemCommand="ListView_ItemCommand"> 
        <LayoutTemplate>
                <table id="itemPlaceholderContainer" style="width: 90%;">
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Requirements
                        </th>
                        <th>
                            Rate
                        </th>
                        <th>
                            Actions
                        </th>
                    </tr>
                    <tr runat="server" id="Test">
                    </tr>
                </table>
            </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" Text='<%# Eval("NAME") %>'> </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text='<%# Eval("CERTIFICATIONRQTS") %>'></asp:Label> 
                </td>
                <td>
                    <asp:Label runat="server" Text='<%# Eval("RATE") %>'></asp:Label> 
                </td>
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="EditButton" Text='Edit' />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteButton" CommandArgument='<%# BitConverter.ToString((byte[])Eval("ID")) %>' Text='Delete' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
