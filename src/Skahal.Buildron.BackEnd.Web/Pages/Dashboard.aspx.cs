//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using System.Web;
using System.Web.UI;
using Skahal.Buildron.BackEnd.Domain.Servers;

namespace Skahal.Buildron.BackEnd.Web.Pages
{
	public partial class Dashboard : System.Web.UI.Page
	{
		public ServerStatistics Statistics { get; private set; }
		
		protected override void OnLoad (EventArgs e)
		{
			Statistics = ServerService.GetStatistics();
			
			base.OnLoad(e);	
		}
	}
}