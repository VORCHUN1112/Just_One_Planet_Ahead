using UnityEngine;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
	[CreateAssetMenu(fileName = "new subcondition", 
	menuName = "JOPA/Port And Wire/PW Presets/New Subcondition", 
	order = 10)]
	public class Subcondition : ScriptableObject
	{
		[OnValueChanged(nameof(ClearInit))]
		[BoxGroup("Условие")]
		[LabelText("Что сравнить")]
		[SerializeField] private InputArgument _argument;
		
		[BoxGroup("Условие")]
		[SerializeField] private EvaluationNode _evaluation;

		public InputArgument Argument => _argument;
		public EvaluationNode Evaluation => _evaluation;

		public void ClearInit()
		{
			_evaluation.ClearInit(_argument);
		}

		[OnInspectorEnable]
		public void NonClearInit()
		{
			_evaluation.Init(_argument);
		}
	}
}