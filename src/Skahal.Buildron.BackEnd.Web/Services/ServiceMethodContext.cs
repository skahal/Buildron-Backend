//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using System.Web;
using Skahal.Web.Services;
using Skahal.Buildron.BackEnd.Domain.Clients;
using Skahal.Buildron.BackEnd.Web.Helpers;

namespace Skahal.Buildron.BackEnd.Web.Services
{
	public sealed class ServiceMethodContext : ServiceMethodContextBase
	{
		#region Properties
		public Client Client
		{
			get
			{
				return ClientHelper.Parse(Request);
			}
		}
		#endregion
	}
}