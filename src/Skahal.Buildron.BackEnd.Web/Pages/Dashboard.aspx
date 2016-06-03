<%@ Page Language="C#" Inherits="Skahal.Buildron.BackEnd.Web.Pages.Dashboard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head runat="server">
	<title>Buildron - BackEnd :: Dashboard</title>
	<style type="text/css" title="currentStyle">
		@import "media/css/demo_page.css"; 
		@import "media/css/demo_table.css";
	</style>
	 <link type="text/css" rel="stylesheet" href="http://jqueryui.com/themes/base/ui.all.css" />
	<script type="text/javascript" language="javascript" src="media/js/jquery.js"></script>
	<script type="text/javascript" language="javascript" src="media/js/jquery.dataTables.js"></script>
	<script type="text/javascript" charset="utf-8">
		$(document).ready(function() {
			$('#gamesTable').dataTable();
			$('#playersTable').dataTable();
		} );
	</script>
</head>
<body>
<form id="form1" runat="server">
	<h2>Server history</h2>			
	<table cellpadding="0" cellspacing="0" border="0" class="display" width="100%">
		<thead>
			<tr>
				<th>Clients</th> 
				<th>Buildron</th>
				<th>Remote Control</th>
				<th>iPod devices</th>
				<th>iPhone devices</th>
				<th>iPad devices</th> 
				<th>Mac devices</th>
				<th>Windows devices</th>
				<th>Android devices</th>
				<th>Editor devices</th> 
			</tr> 
		</thead>		 
		<tbody>
			<tr>
				<td><%= Statistics.TotalClientsCount %></td>
				<td><%= Statistics.TotalBuildronKindsCount %></td>
				<td><%= Statistics.TotalRemoteCountrolKindsCount %></td>
				<td><%= Statistics.TotaliPodDevicesCount %></td>
				<td><%= Statistics.TotaliPhoneDevicesCount %></td>
				<td><%= Statistics.TotaliPadDevicesCount %></td>
				<td><%= Statistics.TotalMacDevicesCount %></td>
				<td><%= Statistics.TotalWindowsDevicesCount %></td>
				<td><%= Statistics.TotalAndroidDevicesCount %></td>
				<td><%= Statistics.TotalEditorDevicesCount %></td>
			</tr>
		</tbody>
	</table>	
</form>
</body>
</html>