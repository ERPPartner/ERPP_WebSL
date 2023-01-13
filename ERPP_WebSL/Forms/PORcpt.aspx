<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PORcpt.aspx.cs" Inherits="ERPP_WebSL.Form.PORcpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PO Receiving</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css"/>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=cbTranDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy "+(new Date).getHours()+":"+(new Date).getMinutes() ,
                yearRange: (new Date).getFullYear()-2+':'+ (new Date).getFullYear() 
                //yearRange: '2000:'+ (new Date).getFullYear() 
            });
        });

    </script>
    <style type="text/css">
        .style2
        {
            font-size: xx-large;
            font-family: Tahoma;
        }
        .style4
        {
            font-size: 26pt;
            font-family: Tahoma;
            text-align: right;
        }
        .style5
        {
            width: 948px;
            height: 1024px;
        }
        .style7
        {
            text-align: left;
        }
        .style10
        {
            width: 208px;
            text-align: right;
            font-family: Tahoma;
            font-size: xx-large;
        }
        .style11
        {
            width: 208px;
            height: 62px;
            text-align: right;
            font-family: Tahoma;
            font-size: xx-large;
        }
        .style12
        {
            height: 62px;
        }
        #Select1
        {
            width: 159px;
        }
        .style13
        {
            width: 208px;
            height: 71px;
            text-align: right;
            font-family: Tahoma;
            font-size: xx-large;
        }
        .style14
        {
            height: 71px;
        }
        .style15
        {
            width: 208px;
            height: 65px;
            text-align: right;
        }
        .style16
        {
            height: 65px;
        }
        </style>
</head>
<body>
    <form id="frmPORcpt" runat="server" 
    
    
    style="border-style: groove; margin-right: auto; margin-left: auto; background-color: #CCEEFF; width: 750px; height: 1024px;" 
    class="style5">
    <div class="style7">
    
        <div class="style7">
    
        <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" 
                Text="&lt;&lt; Back" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" 
                Height="55px" style="font-family: Tahoma; font-size: xx-large" Width="185px" />
        <br />
    
        <br />
            <table style="width:100%;">
                <tr>
                    <td class="style15">
    
            <span lang="en-us"><span class="style4">Trans Date :</span></span></td>
                    <td class="style16">
    
        <asp:TextBox ID="cbTranDate" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="263px"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style13">
                        PO :</td>
                    <td class="style14">
    
        <asp:TextBox ID="tbPO" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" ontextchanged="tb_TextChanged" Width="261px"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style11">
                        Vendor :</td>
                    <td class="style12">
    
        <asp:TextBox ID="tb0" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="262px"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        GRN : <td>
                        <asp:DropDownList ID="cbbGRN" runat="server" Height="68px" Width="152px" 
                            style="font-family: Tahoma; font-size: xx-large">
                        </asp:DropDownList>
                        </td>
                </tr>
            </table>
        <br />
        <br />
    
        </div>
    
    </div>
    </form>
</body>
</html>
