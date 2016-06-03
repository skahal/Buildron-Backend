//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;

namespace Skahal.Buildron.BackEnd.Domain.Clients
{
	public static class ClientService
	{
		#region Constants
		public const string CurrentBuildronMacVersion = "1.6.0";
		public const string CurrentBuildronWinVersion = "1.6.0";
		public const string CurrentRemoteControlVersion = "2.1.0";
		#endregion

		public static string GetCurrentVersion (Client client)
		{
			if(client == null)
			{
				throw new ArgumentNullException("client");
			}
		
			switch(client.Kind)
			{
			case ClientKind.Buildron:
				if(client.Device == ClientDevice.Mac)
				{
					return CurrentBuildronMacVersion;
				}
				else
				{
					return CurrentBuildronWinVersion;
				}

			default:
				return CurrentRemoteControlVersion;
			}
		}
	}
}

