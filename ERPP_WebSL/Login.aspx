<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERPP_WebSL.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>(ERPP) Log In</title>
    <style type="text/css">
        body {
            background-color: #CCEEFF;
        }
        .container {
            background-color: #FFFFFF;
            width: 70%;
            display: block;
            margin: 1.5% auto 0 auto;
            opacity: 0.9;
            border-radius: 4px;
        }
        .form {
            margin: auto;
            /*border-style: outset;*/
            width: 100%; 
            /*height: 1024px;*/            
        }
        .table {
            width: 100%;
            height: 631px;
            width: 100%; font-family: Tahoma; margin-right: 17px; height: 100%;
        }
        .logo {
            font-weight: 700;
            text-align: center;
            font-size: medium;
            height: 69px;
        }
        .logoImage {
            width: 399px;
            height: 123px;
            border-width: thick;
            border-style: outset;
        }
        .title {
            font-weight: 600;
            text-align: center;
            font-size: 36pt;
            /*height: 70px;*/
        }
        .labelfor {
            width: 289px;
            height: 57px;
            font-weight: bold;
            font-size: 24pt;
        }
        .inputbox {
            font-family: Tahoma;
            font-size: 24pt;
            background-color: #FFFF66;
            font-weight: 700;
            width: 250px;
            height: 48px;
            border-style: solid;
            border-color: black;
            border-width: 5px;
        }
        .notification {
            font-size: 24pt;
            color: red;
            text-align: center;
        }
        .style1 {
            height: 23px;
        }               
        .style12
        {
            height: 25px;
            text-align: left;
        }
        .style13
        {
            height: 134px;
            text-align: center;
        }
        .style14
        {
            height: 4px;
            text-align: center;
        }        
        .style17
        {
            height: 25px;
            text-align: right;
            font-size: xx-large;
        }                
        .style23 {
            width: 289px;
            font-weight: bold;
            height: 10px;
        }      
        .style30
        {
            font-weight: 700;
            text-align: center;
            font-size: medium;
            height: 57px;
            width: 82px;
        }        
        .style37
        {
            width: 278px;
            height: 57px;
            font-size: 24pt;
        }
        .style38
        {
            height: 57px;
        }
        .style40
        {
            width: 278px;
            height: 64px;
            font-size: 24pt;
        }
        .style41
        {
            height: 64px;
        }
        .style44
        {
            width: 289px;
            height: 55px;
            font-weight: bold;
            font-size: 30pt;
        }
        .style45
        {
            width: 278px;
            height: 55px;
            font-size: 24pt;
        }
        .style46
        {
            height: 55px;
        }
        .btn
        {
            font-family: Tahoma;
            font-size: 24pt;
            font-weight: bold;
            width: 155px;
            height: 60px;
            border-color: black;
            border-style: solid;
            border-width: 5px;
        }
        .style49
        {
            width: 82px;
            height: 64px;
        }
        .style50
        {
            width: 82px;
            height: 55px;
        }        
        .style52
        {
            font-family: Tahoma;
            font-size: 24pt;
        }
        
    </style>
<script language="javascript" type="text/javascript">
// <!CDATA[

function TextArea1_onclick() {

}

// ]]>
</script>
</head>
<body>
    <div class="container">
        <form runat="server" class="form">            
            <table class="table">
                <tr>
                    <td class="logo" colspan="4">
                        <img alt="" class="logoImage" src="Image/ERPP.png" />
                    </td>
                </tr>
                <tr>
                    <td class="title" colspan="4">Login</td>
                </tr>
                <tr>
                    <td class="style23"></td>
                    <td class="style23"></td>
                    <td class="style23"></td>
                    <td class="style23"></td>
                </tr>
                <tr>
                    <td class="style30"></td>
                    <td class="labelfor">Username</td>
                    <td class="style37">
                        <asp:TextBox
                            ID="txtUser"
                            runat="server"
                            Wrap="False"
                            CssClass="inputbox"></asp:TextBox>
                    </td>
                    <td class="style38"></td>
                </tr>
                <tr>
                    <td class="style49"></td>
                    <td class="labelfor">Password</td>
                    <td class="style40">
                        <asp:TextBox
                            ID="txtPass"
                            runat="server"
                            TextMode="Password"
                            Wrap="False"
                            CssClass="inputbox"
                            TabIndex="1"></asp:TextBox>
                    </td>
                    <td class="style41"></td>
                </tr>
                <tr>
                    <td class="style1"></td>
                    <td class="style1"></td>
                    <td class="style1"></td>
                    <td class="style1"></td>
                </tr>
                <tr>
                    <td class="style50"></td>
                    <td class="labelfor">Configuration</td>
                    <td class="style45">
                        <asp:DropDownList
                            ID="cbConfig"
                            runat="server"
                            CssClass="inputbox"
                            EnableTheming="True"
                            Font-Bold="False"
                            TabIndex="4">
                        </asp:DropDownList>
                    </td>
                    <td class="style46"></td>
                </tr>
                <tr>
                    <td class="style13" colspan="4">
                        <asp:Label
                            ID="label_Error"
                            runat="server"
                            Text="Error"
                            CssClass="notification"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style17" colspan="2">
                        <asp:Button
                            ID="btnOK"
                            runat="server"
                            Text="OK"
                            OnClick="btnOK_Click"
                            CssClass="btn"
                            EnableTheming="True" />
                        <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span>
                    </td>
                    <td class="style12" colspan="2">
                        <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                        <asp:Button
                            ID="btnCancel"
                            runat="server"
                            Text="Cancel"
                            CssClass="btn" />
                    </td>
                </tr>
                <%--<tr>
                    <td class="style14" colspan="2"></td>
                    <td class="style14" colspan="2"></td>
                </tr>--%>
                <tr>
                    <td class="style17" colspan="4">
                        <asp:Label ID="label_ver" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </form>
    </div>
    
</body>
</html>
