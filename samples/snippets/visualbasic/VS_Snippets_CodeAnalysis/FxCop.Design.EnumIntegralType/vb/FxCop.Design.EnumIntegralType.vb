'<Snippet1>
Imports System

Namespace Samples

	<Flags()> _
	Public Enum Days As UInteger
		None = 0
		Monday = 1
		Tuesday = 2
		Wednesday = 4
		Thursday = 8
		Friday = 16
		All = Monday Or Tuesday Or Wednesday Or Thursday Or Friday
	End Enum

	Public Enum Color As SByte
		None = 0
		Red = 1
		Orange = 3
		Yellow = 4
	End Enum

End Namespace
'</Snippet1>
