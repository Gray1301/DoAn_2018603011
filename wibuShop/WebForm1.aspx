<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="wibuShop.WebForm1" %>
<table width="100%">
   <tr bgcolor="#3399ff">
      <td style="width: 174px">
       <%= Application["DangTruyCap"].ToString() %> Users Online
      </td>
   </tr>
   <tr bgcolor="#ff66ff">
       <td>
       Has :<%=Application["Count_Visited"].ToString()%> Visitors
       </td>
   </tr>
</table>
