//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2012 Skahal Studios
using System;
using System.Collections.Generic;

namespace Skahal.Buildron.BackEnd.Domain.Messaging
{
	public class Message
	{
		#region Constructors
		public Message (string name)
		{
			if(name == null)
			{
				throw new ArgumentNullException("name");
			}

			if(String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Message name cannot be empty.", "name");
			}

			Name = name;
			Values = new Dictionary<string, object>();
		}
		#endregion

		#region Properties
		public string Name { get; private set; }
		public IDictionary<string, object> Values { get; private set; }
		#endregion
	}
}