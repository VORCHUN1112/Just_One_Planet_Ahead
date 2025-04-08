using System.Collections;
using System.Collections.Generic;
using JOPA.Modules.PortAndWire;
using UnityEngine;
using UnityEngine.Events;

public class PortAreaListener : MonoBehaviour
{
	[Header("Events")]
	public UnityEvent<IPort> OnPortAreaEntered;
	public UnityEvent<IPort> OnPortAreaStay;
	public UnityEvent<IPort> OnPortAreaExited;

	private void OnTriggerEnter(Collider other)
	{
		HandleTrigger(other, OnPortAreaEntered);
	}
	
	private void OnTriggerStay(Collider other)
	{
		HandleTrigger(other, OnPortAreaStay);
	}
	
	private void OnTriggerExit(Collider other)
	{
		HandleTrigger(other, OnPortAreaExited);
	}
	
	private void HandleTrigger(Collider interacted, UnityEvent<IPort> callback)
	{
		if (interacted.TryGetComponent<IPort>(out IPort port))
		{
			callback?.Invoke(port);
		}
	}
}
