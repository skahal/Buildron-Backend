//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios

using System;
using System.Web;
using System.Web.UI;
using Skahal.Buildron.BackEnd.Web.Services;
using Skahal.Buildron.BackEnd.Domain.Messaging;
using Skahal.Buildron.BackEnd.Domain.Servers;
using GoogleAnalyticsTracker;

namespace Skahal.Buildron.BackEnd.Web.Services.Clients
{
	public class CheckUpdates : ServiceMethodBase<Message>
	{
		protected override Message Execute (ServiceMethodContext context)
		{
			var client = context.Client;

			using (var tracker = new Tracker("UA-21386817-3", "buildronback-end.apphb.com"))
			{
				tracker.UserAgent = client.Kind + " - " + client.Device;
				tracker.TrackPageView("CheckUpdate", HttpContext.Current.Request.Url.ToString());
			}

			return ServerService.CheckUpdates(client);
		}
	}
}