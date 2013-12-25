// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolutionProvider.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2013
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the SolutionProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.UI.DataAccess
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using ArchiMetrics.Common;
	using Roslyn.Services;

	public class SolutionProvider : IProvider<string, ISolution>
	{
		private ConcurrentDictionary<string, ISolution> _cache = new ConcurrentDictionary<string, ISolution>();

		public SolutionProvider()
		{
			_cache.TryAdd(string.Empty, Solution.Create(SolutionId.CreateNewId("empty")));
		}

		~SolutionProvider()
		{
			Dispose(false);
		}

		public ISolution Get(string path)
		{
			return _cache.GetOrAdd(
				path ?? string.Empty,
				p =>
				{
					var solution = Solution.Load(p, "Release");
					return solution;
				});
		}

		public IEnumerable<ISolution> GetAll(string key)
		{
			return from file in Directory.GetFiles(key, "*.sln", SearchOption.AllDirectories)
				   let s = Get(file)
				   where s != null
				   select s;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				if (_cache != null)
				{
					_cache.Clear();
					_cache = null;
				}
			}
		}
	}
}
