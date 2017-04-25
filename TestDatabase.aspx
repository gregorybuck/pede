<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDatabase.aspx.cs" Inherits="PatriciaEdgarAndDonEdgar.TestDatabase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnTestDatabase" runat="server" Text="Press to test database connection" OnClick="btnTestDatabase_Click" />
        <br />
        <br />
        Message:
        <asp:Literal ID="message" runat="server"></asp:Literal>
    
    </div>
    </form>
</body>
</html>
