﻿namespace ArchiMetrics.CodeReview.Semantic
{
	using Roslyn.Compilers.CSharp;

	internal class UnusedMethodRule : UnusedCodeRule
	{
		public override SyntaxKind EvaluatedKind
		{
			get { return SyntaxKind.MethodDeclaration; }
		}
	}
}