using Alchemy.Inspector;
using JOPA.Modules.PortAndWire.Data;
using TMPro;
using UnityEngine;

namespace JOPA.Modules.PortAndWire
{
	public class ConnectorInfo : MonoBehaviour
	{
		[BoxGroup("Данные")]
		[OnValueChanged(nameof(UpdateText))]
		[SerializeField] private ConnectorData _connector;
		
		[BoxGroup("Данные")]
		[OnValueChanged(nameof(UpdateWire))]
		[SerializeField] private WireMaterialData _material;

		[BoxGroup("Ссылка на дисплей")]
		[SerializeField] private TextMeshProUGUI _textField;
		
		[BoxGroup("Ссылка на рендерер провода")]
		[SerializeField] private LineRenderer _renderer;

		public ConnectorData Connector => _connector;
		public WireMaterialData Material => _material;

		private void Start()
		{
			UpdateText();
			UpdateWire();
		}

		private void UpdateText()
		{
			if (_connector == null) return;

			string text = _connector.Value;
			_textField.text = text;
		}
		
		private void UpdateWire()
		{
			if (_renderer == null) return;

			_renderer.material = _material.Value;
		}
	}
}