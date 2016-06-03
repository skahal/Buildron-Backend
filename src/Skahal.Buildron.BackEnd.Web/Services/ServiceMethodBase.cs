//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;

namespace Skahal.Buildron.BackEnd.Web.Services
{
	public abstract class ServiceMethodBase<TResult> : 
		Skahal.Web.Services.ServiceMethodBase<ServiceMethodContext, TResult>
	{
		protected override TResult Execute(ServiceMethodContext context)
		{
			return default(TResult);
		}
	}
}

