//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios

using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using Skahal.Buildron.BackEnd.Domain.Servers;
using Skahal.Buildron.BackEnd.Infrastructure.Repositories;
using Skahal.Buildron.BackEnd.Domain.Clients;
using Skahal.Buildron.BackEnd.Infrastructure;
using Skahal.Buildron.BackEnd.Infrastructure.Providers;

namespace Skahal.Buildron.BackEnd.Web
{
	public class Global : System.Web.HttpApplication
	{
		
		protected virtual void Application_Start (Object sender, EventArgs e)
		{
			ServerService.Initialize(
				new MySqlServerRepository(), 
				new MemoryNotificationMessageRepository());
			
			ClientService.Initialize (
				new CacheClientInfoProvider(new GitHubClientInfoProvider (), TimeSpan.FromHours(1)));
		}
		
		protected virtual void Session_Start (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_BeginRequest (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_EndRequest (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_AuthenticateRequest (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_Error (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Session_End (Object sender, EventArgs e)
		{
		}
		
		protected virtual void Application_End (Object sender, EventArgs e)
		{
		}
	}
}

