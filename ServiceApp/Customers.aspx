<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ServiceApp.Customers"%>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <h2>Add Customer</h2>
    <br />
    <asp:Label ID="nameLabel" runat="server" Text="Name:"></asp:Label><br />
    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox><br />
    <asp:Label ID="addressLabel" runat="server" Text="Address:"></asp:Label><br />
    <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="maleRadioLbl" runat="server" Text="Male:"></asp:Label><asp:RadioButton ID="maleRadioBtn" GroupName="gender" runat="server" />
    <asp:Label ID="femaleRadioLbl" runat="server" Text="Female:"></asp:Label><asp:RadioButton ID="femaleRadioBtn" GroupName="gender" runat="server" />
    <asp:Calendar ID="birthCalendar" runat="server"></asp:Calendar>
    <br />
    <asp:Label ID="imageLabel" runat="server" Text="Image:"></asp:Label><asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="UploadBtn" runat="server" Text="Submit" OnClick="UploadBtn_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
        <h3>Customers</h3>
        <asp:ListView ID="ContactsListView"
            DataSourceID="ContactsDataSource"
            DataKeyNames="ID"
            runat="server">
            <LayoutTemplate>
                <table cellpadding="2" width="640px" border="1" runat="server" id="tblProducts">
                    <tr runat="server">
                        <th runat="server">Image</th>
                        <th runat="server">First Name</th>
                        <th runat="server">Address</th>
                        <th runat="server">Birthdate</th>
                        <th runat="server">Gender</th>
                        <th runat="server">Action</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
                <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="12">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                            FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                            NextPageText=" &gt; " PreviousPageText=" &lt; " />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <asp:Image ID="Image1" runat="Server" Height="64px" Width="64px" ImageUrl='<%# (Eval("Picture") != System.DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Picture")) : "https://muschealth.org/MUSCApps/HealthAssets/ProfileImages/NoImageProvided.png") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddressLabel" runat="Server" Text='<%#Eval("Address") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BirthdateLabel" runat="Server" Text='<%#Eval("Birthdate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GenderLabel" runat="Server" Text='<%#Eval("Gender") %>' />
                    </td>
                    <td>
                        <asp:Button ID="EditButton" runat="Server" Text="Edit" CommandName="Edit" />
                        <asp:Button ID="DeleteButton" runat="Server" Text="Delete" CommandName="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #ADD8E6">
                    <td></td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%#Bind("Name") %>'
                            MaxLength="50" /><br />
                    </td>
                    <td>
                        <asp:TextBox ID="AddressTextBox" runat="server" Text='<%#Bind("Address") %>'
                            MaxLength="50" /><br />
                    </td>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />&nbsp;
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="ContactsDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM Customer"
            UpdateCommand="UPDATE Customer
                       SET Name = :Name, Address = :Address
                       WHERE ID = :ID"
            DeleteCommand="DELETE FROM Customer
                        WHERE ID = :ID"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
            <DeleteParameters>
                <asp:Parameter Name="ID"/>
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID" />
            </UpdateParameters>
        </asp:SqlDataSource>
</asp:Content>
