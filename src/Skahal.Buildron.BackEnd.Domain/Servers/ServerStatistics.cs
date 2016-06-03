//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;

namespace Skahal.Buildron.BackEnd.Domain.Servers
{
	public class ServerStatistics
	{
		#region Properties
		public long TotalClientsCount { get; set; }
		public long TotalBuildronKindsCount { get; set; }
		public long TotalRemoteCountrolKindsCount { get; set; }
		public long TotaliPodDevicesCount { get; set; }
		public long TotaliPhoneDevicesCount { get; set; }
		public long TotaliPadDevicesCount { get; set; }
		public long TotalMacDevicesCount { get; set; }
		public long TotalWindowsDevicesCount { get; set; }
		public long TotalAndroidDevicesCount { get; set; }
		public long TotalEditorDevicesCount { get; set; }
		#endregion
	}
}