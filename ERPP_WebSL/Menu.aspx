<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ERPP_WebSL.ERPPMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menu</title>
    <style type="text/css">
        body {
            background-color: #CCEEFF;
        }
        .container {
            text-align: center;
            background-color: #FFFFFF;
            width: 50%;
            display: block;
            margin: 1.5% auto 0 auto;
            opacity: 0.9;
            border-radius: 4px;
        }
        .form {
            width: 365px;
            /*border-style:groove;*/
            width: 750px;
            /*height: 1024px;*/
            margin-right: auto;
            margin-left: auto;                        
        }
        .table {
            width: 100%;
            height: 220px;
        }
        .style4
        {
            height: 114px;
        }
        .style5
        {
            height: 75px;
            text-align: left;
        }
        .btn-back
        {
            font-family: Tahoma;
            font-size: xx-large;
            text-align: left;
            height: 55px;
            width: 185px;
            border-width: 5px;
            border-color: black;
            border-style: solid;
        }
        .list {
            font-family: Tahoma;
            font-size: 24pt;
            font-weight: bold;
            border-style: solid;
            border-width: 5px;
            border-color: black;
            width: 400px;
            height: 90px;
        }
    </style>
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>
</head>
<body>
    <div class="container">   
        <form runat="server" class="form" >
            <table class="table">
                <tr>
                    <td class="style5">
                        <asp:Button
                            ID="btnBack"
                            runat="server"
                            CssClass="btn-back" 
                            onclick="btnBack_Click"
                            Text="&lt;&lt; Back" />
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button
                            ID="btnPORcpt"
                            runat="server"
                            CssClass="list"
                            onclick="btnPORcpt_Click"
                            Text="PO Receiving" />
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button
                            ID="btnOrderShip"
                            runat="server"
                            CssClass="list"
                            onclick="btnOrderShip_Click"
                            Text="Order Shipping" />
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button
                            ID="btnQtyMove"
                            runat="server" 
                            CssClass="list"
                            Text="Quantity Move"
                            onclick="btnQtyMove_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
