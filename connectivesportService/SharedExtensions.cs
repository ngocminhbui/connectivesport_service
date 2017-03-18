using System.Linq;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace connectivesportService
{
	public static partial class Extensions
	{
		public static Dictionary<string, string> ToKeyValuePair(this string querystring)
		{
			return Regex.Matches(querystring, "([^?=&]+)(=([^&]*))?").Cast<Match>().ToDictionary(x => x.Groups[1].Value, x => x.Groups[3].Value);
		}

		public static bool IsEmpty(this string s)
		{
			return string.IsNullOrWhiteSpace(s);
		}

		public static string ToOrdinal(this int num)
		{
			if(num <= 0)
				return num.ToString();

			switch(num % 100)
			{
				case 11:
				case 12:
				case 13:
					return num + "th";
			}

			switch(num % 10)
			{
				case 1:
					return num + "st";
				case 2:
					return num + "nd";
				case 3:
					return num + "rd";
				default:
					return num + "th";
			}

		}
	}

	public class DeviceRegistration
	{
		public string Platform
		{
			get;
			set;
		}

		public string Handle
		{
			get;
			set;
		}

		public string[] Tags
		{
			get;
			set;
		}
	}

	public class NotificationPayload
	{
		public NotificationPayload()
		{
			Payload = new Dictionary<string, string>();
		}

		public string Action
		{
			get;
			set;
		}

		public Dictionary<string, string> Payload
		{
			get;
			set;
		}
	}

	public struct PushActions
	{
		public static string ChallengePosted = "ChallengePosted";
		public static string ChallengeRevoked = "ChallengeRevoked";
		public static string ChallengeAccepted = "ChallengeAccepted";
		public static string ChallengeDeclined = "ChallengeDeclined";
		public static string ChallengeCompleted = "ChallengeCompleted";
		public static string LeagueStarted = "LeagueStarted";
		public static string LeagueEnded = "LeagueEnded";
		public static string LeagueEnrollmentStarted = "LeagueEnrollmentStarted";
	}
}