using UnityEngine;
using System;
using System.Collections.Generic;
using Alchemy.Inspector;

namespace JOPA.Modules.PortAndWire.Data
{
    [Serializable]
	[HorizontalGroup]
	public class EvaluationResult
	{
		[OnValueChanged(nameof(OnValueChanged))]
		[BoxGroup("Результат")]
		[LabelText("Тип результата")]
		[SerializeField] private ResultType _resultType;
		
		[ShowIf(nameof(PortType))]
		[BoxGroup("Результат")]
		[LabelText("Порт")]
		[SerializeField] private PortData _port;
		
		[ShowIf(nameof(PortListType))]
		[BoxGroup("Результат")]
		[LabelText("Порт из списка")]
		[SerializeField] private List<PortData> _portList;
		
		public ResultType ResultType => _resultType; 
		public PortData Port => _port; 
		public List<PortData> PortList => _portList;
		
		public bool PortType => _resultType == ResultType.TargetPort;
		public bool PortListType => _resultType == ResultType.PortList;
		public bool AnyPortType => _resultType == ResultType.AnyPort;

		private void OnValueChanged()
		{
			_port = null;
			_portList = new List<PortData>();
		}
	}
}