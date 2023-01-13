<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QtyMove.aspx.cs" Inherits="ERPP_WebSL.Form.QtyMove" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Quantity Move</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css"/>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>

    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=cbTranDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy " + (new Date).getHours() + ":" + (new Date).getMinutes(),
                yearRange: (new Date).getFullYear() - 2 + ':' + (new Date).getFullYear()
                
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
            width: 399px;
            text-align: right;
            font-family: Tahoma;
            font-size: xx-large;
        }
     
        .style15
        {
            width: 399px;
            height: 70px;
            text-align: right;
        }
        .style19
        {
            height: 24px;
        }
        .style20
        {
            height: 24px;
            width: 371px;
            text-align: right;
        }
        .style24
        {
            height: 70px;
        }
        .style25
        {
            width: 399px;
            height: 70px;
            text-align: right;
            font-family: Tahoma;
            font-size: xx-large;
       </style>
</head>
<body>
    <form id="frmQtyMove" runat="server" 
    
    
    style="border-style: groove; margin-right: auto; margin-left: auto; background-color: #CCEEFF; width: 750px; height: 1024px;" 
    class="style5">

    <div id="loader" style="margin:0; position:absolute; top:50%; left:50%; margin-right:-50%; transform:translate(-50%,-50%); display:none;">
        <img src="../Image/loading1.gif" />
    </div>

    <div class="style7">
    
        <div class="style7">
    
        <asp:Button ID="btnBack" runat="server"
                Text="&lt;&lt; Back" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" 
                Height="55px" style="font-family: Tahoma; font-size: xx-large" 
                Width="185px" TabIndex="3" PostBackUrl="~/Menu.aspx" />
            
            <br />
    
        <br />
            <table style="width:100%; height: 307px;">
                <tr>
                    <td class="style25">
                        Warehouse : 
                    <td class="style24">
                        <asp:DropDownList ID="cbbWhse" runat="server" Height="60px" Width="200px" 
                            style="font-family: Tahoma; font-size: xx-large">
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="style15">
    
            <span lang="en-us"><span class="style4">Trans Date :</span></span></td>
                    <td class="style24">
    
        <asp:TextBox ID="cbTranDate" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="313px" Height="55px"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        Tag :</td>
                    <td class="style24">

        <asp:TextBox ID="tbTag" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="262px" Height="55px" AutoPostBack="True" 
                            ontextchanged="tbTag_TextChanged"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        Item :</td>
                    <td class="style24">
    
        <asp:TextBox ID="tbItem" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="262px" Height="55px" AutoPostBack="True" 
                            Enabled="False" ReadOnly="True"></asp:TextBox>
    
                    &nbsp;<span class="style2"> U/M :</span><asp:TextBox ID="tbUM" runat="server" 
                            Height="55px" 
                            style="margin-top: 0px; font-family: Tahoma; font-size: xx-large;" Width="72px" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="3px" ReadOnly="True" AutoPostBack="True" 
                            Enabled="False"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;<td>
                        <asp:TextBox ID="tbDesc" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="3px" Height="55px" Width="498px" 
                            ReadOnly="True" AutoPostBack="True" Enabled="False" 
                            style="font-family: Tahoma; font-size: xx-large"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="style25">
                        From Location : 
                    <td class="style24">
                        <asp:DropDownList ID="cbbFromLoc" runat="server" Height="60px" Width="200px" 
                            style="font-family: Tahoma; font-size: xx-large" AutoPostBack="True" 
                            onselectedindexchanged="cbbFromLoc_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;<asp:TextBox ID="tbFromLoc" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="3px" Height="55px" Width="233px" 
                            AutoPostBack="True" ontextchanged="tbFromLoc_TextChanged" 
                            style="font-family: Tahoma; font-size: xx-large"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="style25">
                        To Location : <td class="style24">
                        <asp:DropDownList ID="cbbToLoc" runat="server" Height="60px" Width="200px" 
                            style="font-family: Tahoma; font-size: xx-large" AutoPostBack="True" 
                            onselectedindexchanged="cbbToLoc_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;<asp:TextBox ID="tbToLoc" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="3px" Height="55px" Width="233px" 
                            AutoPostBack="True" ontextchanged="tbToLoc_TextChanged" 
                            style="font-family: Tahoma; font-size: xx-large"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="style25">
                        Lot&nbsp; :</td>
                    <td class="style24">
    
        <asp:TextBox ID="tbLot" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="261px" Height="55px" AutoPostBack="True" 
                            ontextchanged="tbLot_TextChanged"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        Serial :</td>
                    <td class="style24">
    
        <asp:TextBox ID="tbSerial" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="261px" Height="55px" AutoPostBack="True" 
                            ontextchanged="tbSerial_TextChanged"></asp:TextBox>
    
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        Qty :</td>
                    <td class="style24">
    
        <asp:TextBox ID="tbQty" runat="server" CssClass="style2" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="3px" Width="261px" Height="55px" AutoPostBack="True" 
                            ontextchanged="tbQty_TextChanged"></asp:TextBox>
    
                    </td>
                </tr>
            </table>
        <br />
            <table style="width:100%;">
                <tr>
                    <td class="style20">
                        <asp:Button ID="btnClear" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="3px" 
                            style="font-family: Tahoma; font-size: xx-large" Text="Clear" 
                            Height="69px" Width="124px" onclick="btnClear_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style19">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMove" runat="server" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="3px" onclick="btnMove_Click" 
                            style="font-family: Tahoma; font-size: xx-large" Text="Move" Height="70px" 
                            Width="120px" />
                    </td>
                </tr>
            </table>
        <br />
    
        </div>
    
    </div>
    </form>
</body>
</html>
