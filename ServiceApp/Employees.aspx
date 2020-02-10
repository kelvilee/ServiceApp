<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="ServiceApp.Employees" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div> 
        <h2>
            Employees List</h2>
         <hr />
        <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListViewEmployees" 
            OnItemDataBound="ListView_ItemDataBound" OnItemCommand="ListView_ItemCommand">
           
            <ItemTemplate>
                Name: <asp:Label ID="Name" runat="server" Text='<%#Eval("NAME") %>'> </asp:Label>
                <br />
                 Job title: <asp:Label ID="Title" runat="server" Text='<%#Eval("JOBTITLE") %>'> </asp:Label>
                <br />
                <div id="toggleDetailsDiv" runat="server">
                    Address: <asp:Label ID="Address" runat="server" Text='<%#Eval("ADDRESS") %>'></asp:Label> 
                    <br />
                    Manager ID: <asp:Label ID="ManagerID" runat="server" Text='<%# Eval("MANAGERID") %>'></asp:Label> 
                    <br />
                   Certified For:  <asp:Label ID="CertifiedFor" runat="server" Text='<%# Eval("CertifiedFor") %>'></asp:Label> 
                    <br />
                   Start Date: <asp:Label ID="StartDate" runat="server" Text='<%#Eval("STARTDATE") %>'></asp:Label> 
                    <br />
                    Salary: <asp:Label ID="Salary" runat="server" Text='<%#Eval("SALARY") %>'></asp:Label> 
                </div>

                <asp:Panel ID="updateInfoPanel" runat="server" ScrollBars="Auto" Width="100%" Height="300px">
                    <br />
                    <h3>Update Information</h3>
                    <h5>Enter new values</h5>
                    <table>
                    <tr>
                         <td>
                             Name: 
                         </td>
                        <td>
                            <asp:TextBox runat="server" ID="NameValue"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td>
                             Title: 
                        </td>
                         <td>
                             <asp:TextBox runat="server" ID="TitleValue"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                         <td>
                         Address: 
                        </td>
                         <td>
                             <asp:TextBox runat="server" ID="AdressValue"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            CertifiedFor:
                        </td>
                          <td>
                              <asp:TextBox runat="server" ID="CertifiedForValue"></asp:TextBox>
                         </td>
                     </<tr>
                    <tr>
                        <td>
                        Salary: 
                       </td>
                        <td>
                            <asp:TextBox runat="server" ID="SalaryValue"></asp:TextBox>
                        </td>
                     </tr>
                    <tr>
                        <td>
                            <asp:Button ID="SubmitButton" runat="server" CommandName="SubmitButton" Text="Submit" CommandArgument='<%# BitConverter.ToString((byte[])Eval("ID")) %>'/>
                        </td> 
                    </tr>
                        </table>

                </asp:Panel>

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

