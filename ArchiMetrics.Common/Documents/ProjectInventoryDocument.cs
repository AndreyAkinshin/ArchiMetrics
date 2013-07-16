// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectInventoryDocument.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectInventoryDocument type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArchiMetrics.Common.Documents
{
	using System;

	public class ProjectInventoryDocument : ProjectDocument
	{
		public string Id { get; set; }

		public string Tag { get; set; }

		public DateTime Date { get; set; }

		public string[] TestProjectNames { get; set; }

		public string[] ProductionProjectNames { get; set; }

		public static string GetId(string projectName, string projectVersion)
		{
			return string.Format("Inventory.{0}.v{1}", projectName, projectVersion);
		}
	}
}