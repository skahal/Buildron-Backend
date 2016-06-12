using System;
using Skahal.Buildron.BackEnd.Domain.Clients;

namespace Skahal.Buildron.BackEnd.Infrastructure.Providers
{
	public class StaticClientInfoProvider : IClientInfoProvider
	{
		#region Constants
		public const string CurrentBuildronMacVersion = "1.6.0";
		public const string CurrentBuildronWinVersion = "1.6.0";
		public const string CurrentRemoteControlVersion = "2.1.0";
		#endregion

		#region IClientInfoProvider implementation
		public string FindLatestVersion (ClientDevice device, ClientKind kind)
		{
			switch(kind)
			{
				case ClientKind.Buildron:
					if(device == ClientDevice.Mac)
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
		#endregion
		
	}
}

