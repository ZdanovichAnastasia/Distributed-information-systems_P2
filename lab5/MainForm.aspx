<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="lab5.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/template.css" rel="stylesheet" type="text/css" />  
<link href="css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />  
<script src="js/jquery-1.6.min.js" type="text/javascript"></script>  
<script src="js/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>  
<script src="js/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>  
        <script type="text/javascript">  
    jQuery(document).ready(function () {  
        jQuery("#form1").validationEngine();  
    });  
        </script> 
    <style type="text/css">
        .auto-style1 {
            width: 217px;
        }
        .auto-style2 {
            width: 215px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="visitGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="idvisit" OnRowDataBound="visitGridView_RowDataBound" OnRowEditing="visitGridView_RowEditing" OnRowCancelingEdit="visitGridView_RowCancelingEdit" OnRowUpdating="visitGridView_RowUpdating" OnRowDeleting="visitGridView_RowDeleting" Width="1307px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="lecture" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lbllecture" runat="server" Text='<%#Eval("lecture")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtlecture" runat="server" Text='<%#Eval("lecture")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="editValidator" runat="server" ControlToValidate ="txtlecture" ErrorMessage="Please input value"/>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FIOstudent" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblstudent" runat="server" Text='<%#Eval("FIOstudnet")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtstudent" runat="server" Text='<%#Eval("FIOstudnet")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="editValidator" runat="server" ControlToValidate ="txtstudent" ErrorMessage="Please input value"/>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="isVisit" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:CheckBox ID="lblVisit" runat="server" Enabled="false" Checked = '<%#Eval("isVisit").ToString().Equals("1")%>' ></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chbIsVisit" runat="server" Checked = '<%#Eval("isVisit").ToString().Equals("1")%>'></asp:CheckBox>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="group" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblNGroup" runat="server" Text='<%#Eval("Ngroup")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNGroup" runat="server" Text='<%#Eval("Ngroup")%>'></asp:TextBox>
                            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                            ControlToValidate="txtNGroup" ErrorMessage="Value must be a whole number" />
                        <asp:RequiredFieldValidator ValidationGroup="editValidator" runat="server" ControlToValidate ="txtNGroup" ErrorMessage="Please input value"/>
                        </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="date" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("date")%>'></asp:Label>
                        </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" ValidationGroup="editValidator">
<ItemStyle Width="150px"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <table border="1" cellpadding="0" cellspacing="0" style="border-color: #C0C0C0; border-collapse: collapse; background-color: #808080; color: #FFFFFF;" aria-atomic="False" class="auto-style7">
                <tr>
                    <td aria-autocomplete="none" class="auto-style1">
                        Lecture:<br />
                        <asp:TextBox ID="txtLecture" runat="server" Width="140"/>
                        <asp:RequiredFieldValidator ValidationGroup="addValidator" runat="server" ControlToValidate ="txtLecture" ErrorMessage="Please input value"/>
                    </td>
                    <td aria-autocomplete="none" class="auto-style2">
                        Name of student:<br />
                        <asp:TextBox ID="txtStudent" runat="server" Width="140"/>
                        <asp:RequiredFieldValidator ValidationGroup="addValidator" runat="server" ControlToValidate ="txtStudent" ErrorMessage="Please input  кум value"/>
                    </td>
                    <td aria-autocomplete="none" class="auto-style1">
                        Visit?:<br />
                        <asp:CheckBox ID="chbVisit" runat="server" Width="140" />
                    </td>
                    <td aria-autocomplete="none" class="auto-style2">
                        Group:<br />
                        <asp:TextBox ID="txtGroup" runat="server" Width="140"/>
                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" 
                            ControlToValidate="txtGroup" ErrorMessage="Value must be a whole number" />
                        <asp:RequiredFieldValidator ValidationGroup="addValidator" runat="server" ControlToValidate ="txtGroup" ErrorMessage="Please input value"/>
                    </td>
                    <td aria-autocomplete="none">
                        <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" Width="438px" ValidationGroup="addValidator"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
