//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using System.Web;
using Skahal.Buildron.BackEnd.Domain.Clients;

namespace Skahal.Buildron.BackEnd.Web.Helpers
{
	public static class ClientHelper
	{
		public static Client Parse(HttpRequest request)
		{
			var id = request["id"];
			var device = request["device"];
			var kind = request["kind"];
			var version = request["version"];
		
			if(id != null && device != null && kind != null && version != null)
			{
				var client = new Client(id);
				client.Device = (ClientDevice) Enum.Parse(typeof(ClientDevice), device);
				client.Kind = (ClientKind) Enum.Parse(typeof(ClientKind), kind);
				client.Version = version;

				return client;
			}

			return null;
		}
	}
}

