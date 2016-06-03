//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios

using System;
using System.Web;
using System.Web.UI;
using Skahal.Buildron.BackEnd.Domain.Servers;
using Skahal.Buildron.BackEnd.Domain.Messaging;

namespace Skahal.Buildron.BackEnd.Web.Services.Clients
{
	public class RegisterClient : ServiceMethodBase<Message>
	{
		protected override Message Execute (ServiceMethodContext context)
		{
			return ServerService.RegisterClient(context.Client);
		}
	}
}