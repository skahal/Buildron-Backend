//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;

namespace Skahal.Buildron.BackEnd.Domain.Clients
{
	/// <summary>
	/// Domain service that provides information about Buildron clients.
	/// </summary>
	public static class ClientService
	{
		#region Fields
		private static IClientInfoProvider s_clientInfoProvider;
		#endregion

		#region Methods
		/// <summary>
		/// Initialize the service.
		/// </summary>
		/// <param name="clientInfoProvider">Client info provider.</param>
		public static void Initialize (IClientInfoProvider clientInfoProvider)
		{
			s_clientInfoProvider = clientInfoProvider;
		}

		/// <summary>
		/// Gets the latest client version.
		/// </summary>
		/// <returns>The latest version.</returns>
		/// <param name="client">Client.</param>
		public static string GetLatestVersion (Client client)
		{
			if(client == null)
			{
				throw new ArgumentNullException("client");
			}
		
			return s_clientInfoProvider.FindLatestVersion (client.Device, client.Kind);
		}
		#endregion
	}
}