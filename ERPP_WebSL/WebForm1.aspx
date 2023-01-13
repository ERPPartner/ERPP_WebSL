<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ERPP_WebSL.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loading Pages</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.3/jquery-ui.min.js"></script>

    <style>
   .content
   {
       display:none;
       }
          .preload
   {
       margin:0;
       position:absolute;
       top:50%;
       left:50%;
       margin-right:-50%;
       transform:translate(-50%,-50%);
       }
   
    </style>
</head>
<body>
  <div class="preload" >
      <img src="Image/loading1.gif" />
  </div>

    <div class="content" >
      aaa
  </div>
        <script>
            $(function () {
                $(".preload").fadeOut(2000, function () {
                    $(".content").fadeIn(1000);
                });
            });
  </script>

</body>
</html>
