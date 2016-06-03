#region Usings
using System;
using Skahal.Data.MySql;
using Skahal.Buildron.BackEnd.Domain.Servers;
#endregion

namespace Skahal.Buildron.BackEnd.Infrastructure.Repositories
{
	/// <summary>
	/// A MySql IServerRepository.
	/// </summary>
	public class MySqlServerRepository : IServerRepository
	{
		#region IServerRepository implementation
		public void SaveStatistics (ServerStatistics statistics)
		{
			MySqlHelper.Update(@"
				UPDATE 
						ServerStatistics 
				SET TotalAndroidDevicesCount 	= @TotalAndroidDevicesCount,
					TotalBuildronKindsCount		= @TotalBuildronKindsCount,
					TotalClientsCount 			= @TotalClientsCount, 
					TotalEditorDevicesCount 	= @TotalEditorDevicesCount,
					TotaliPadDevicesCount		= @TotaliPadDevicesCount,
					TotaliPhoneDevicesCount 	= @TotaliPhoneDevicesCount,
					TotaliPodDevicesCount		= @TotaliPodDevicesCount, 
					TotalMacDevicesCount		= @TotalMacDevicesCount, 
					TotalRemoteCountrolKindsCount = @TotalRemoteCountrolKindsCount, 
					TotalWindowsDevicesCount	= @TotalWindowsDevicesCount
			",
			"@TotalAndroidDevicesCount", statistics.TotalAndroidDevicesCount,
			"@TotalBuildronKindsCount", statistics.TotalBuildronKindsCount,
			"@TotalClientsCount", statistics.TotalClientsCount,
			"@TotalEditorDevicesCount", statistics.TotalEditorDevicesCount,
			"@TotaliPadDevicesCount", statistics.TotaliPadDevicesCount,
			"@TotaliPhoneDevicesCount", statistics.TotaliPhoneDevicesCount,
			"@TotaliPodDevicesCount", statistics.TotaliPodDevicesCount,
			"@TotalMacDevicesCount", statistics.TotalMacDevicesCount,
			"@TotalRemoteCountrolKindsCount", statistics.TotalRemoteCountrolKindsCount,
			"@TotalWindowsDevicesCount", statistics.TotalWindowsDevicesCount);
		}

		public ServerStatistics FindStatistics ()
		{
			var statistics = new ServerStatistics();
			
			MySqlHelper.Select((row) => {
				statistics.TotalAndroidDevicesCount = row.GetInt32("TotalAndroidDevicesCount");
				statistics.TotalBuildronKindsCount = row.GetInt32("TotalBuildronKindsCount");
				statistics.TotalClientsCount = row.GetInt32("TotalClientsCount");
				statistics.TotalEditorDevicesCount = row.GetInt32("TotalEditorDevicesCount");
				statistics.TotaliPadDevicesCount = row.GetInt32("TotaliPadDevicesCount");
				statistics.TotaliPhoneDevicesCount = row.GetInt32("TotaliPhoneDevicesCount");
				statistics.TotaliPodDevicesCount = row.GetInt32("TotaliPodDevicesCount");
				statistics.TotalMacDevicesCount = row.GetInt32("TotalMacDevicesCount");
				statistics.TotalRemoteCountrolKindsCount = row.GetInt32("TotalRemoteCountrolKindsCount");
				statistics.TotalWindowsDevicesCount = row.GetInt32("TotalWindowsDevicesCount");	
			}, 
			"SELECT * FROM ServerStatistics");
			
			return statistics;
		}
		#endregion
	}
}