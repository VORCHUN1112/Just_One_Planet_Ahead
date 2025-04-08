using Alchemy.Inspector;
using JOPA.Modules.PortAndWire.Data;
using TMPro;
using UnityEngine;

namespace JOPA.Modules.PortAndWire
{
	public class PortInfo : MonoBehaviour
	{
		[BoxGroup("Данные")]
		[OnValueChanged(nameof(UpdateText))]
		[SerializeField] private PortData _port;

		[BoxGroup("Ссылка на дисплей")]
		[SerializeField] private TextMeshProUGUI _textField;

		public PortData Port => _port;
		
		private void Start()
		{
			UpdateText();
		}

		[OnInspectorEnable]
		private void UpdateText()
		{
			if (_port == null) return;
			
			string text = _port.Value;
			_textField.text = text;
		}
	}
}