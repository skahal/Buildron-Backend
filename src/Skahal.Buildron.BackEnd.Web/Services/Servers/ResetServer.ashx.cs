//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios

using System;
using System.Web;
using System.Web.UI;
using Skahal.Buildron.BackEnd.Domain.Servers;

namespace Skahal.Buildron.BackEnd.Web.Services.Servers
{
	public class ResetServer : ServiceMethodBase<string>
	{
		protected override string Execute (ServiceMethodContext context)
		{
			ServerService.Reset();
			return String.Empty;
		}
	}
}
