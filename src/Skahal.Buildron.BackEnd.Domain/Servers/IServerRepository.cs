//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;

namespace Skahal.Buildron.BackEnd.Domain.Servers
{
	public interface IServerRepository
	{
		void SaveStatistics(ServerStatistics statistics);
		ServerStatistics FindStatistics();
	}
}

