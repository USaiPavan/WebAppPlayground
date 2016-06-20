<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditableGrid.aspx.cs" Inherits="WebApplication1.EditableGrid" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editable Grid</title>
    <script type="text/javascript">
        function updateEditStatus(clientID) {
            var hiddenEditControl = document.getElementById(clientID);
            if (hiddenEditControl != null) {
                hiddenEditControl.value = "true";
            }
        }
    </script>
    <style type="text/css">
    .hiddencol
    {
        display: none;
    }
    </style>
</head>
<body>
    <form id="frmEditableGrid" runat="server">
    <div>
        <asp:GridView ID="grdEditableGrid" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdEditableGrid_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="CategoryID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" >
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCategoryID" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CategoryName">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit Status" ItemStyle-CssClass=hiddencol HeaderStyle-CssClass=hiddencol>
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hdnEditStatus" Value='' EnableViewState="true" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Button Text="Save Data" runat="server" ID="btnSaveData" 
            onclick="btnSaveData_Click" />
    </div>
    </form>
</body>
</html>
