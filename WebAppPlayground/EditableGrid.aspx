<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditableGrid.aspx.cs" Inherits="WebApplication1.EditableGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmEditableGrid" runat="server">
    <div>
        
        <asp:GridView ID="grdEditableGrid" runat="server">
        <Columns>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:TextBox runat="server" ID="txtCategoryID" Text='<% DataBinder.Eval("CategoryID") %>' />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
            
    </div>
    </form>
</body>
</html>
