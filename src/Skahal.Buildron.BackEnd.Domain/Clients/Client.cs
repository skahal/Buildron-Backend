//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;

namespace Skahal.Buildron.BackEnd.Domain.Clients
{
	#region Enums
	public enum ClientDevice
	{
		iPod,
		iPhone,
		iPad,
		Mac,
		Windows,
		Android,
		Editor
	}

	public enum ClientKind
	{
		Buildron,
		RemoteControl
	}
	#endregion

	public class Client
	{
		#region Constructors
		public Client(string id)
		{
			if(id == null)
			{
				throw new ArgumentNullException("id");
			}

			if(String.IsNullOrEmpty(id))
			{
				throw new ArgumentException("Client ID cannot be empty.", "id");
			}

			Id = id;
		}
		#endregion

		#region Properties
		public string Id { get; private set; }
		public ClientDevice Device { get; set; }
		public ClientKind Kind { get; set; } 
		public string Version { get; set; }
		#endregion
	}
}

