using UnityEngine;
using System.Collections.Generic;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new PW Condition", 
	menuName = "JOPA/Port And Wire/PW Presets/New PW Condition", 
	order = 1)]
	public class Condition : ScriptableObject
	{	
		[BoxGroup("Условия")]
		[InlineEditor]
		[SerializeField] private List<Subcondition> _subconditions;

		[BoxGroup("При провале условий")]
		[SerializeField] private EvaluationResult _elseResult;

		public List<Subcondition> Subconditions => _subconditions;
		public EvaluationResult ElseResult => _elseResult;
	}
}