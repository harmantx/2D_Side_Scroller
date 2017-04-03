using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public RecycleGameObjects prefab;

	private List<RecycleGameObjects> poolInstances = new List<RecycleGameObjects>();

	private RecycleGameObjects CreateInstance(Vector3 pos)
	{
		var clone = GameObject.Instantiate (prefab);
		clone.transform.position = pos;
		clone.transform.parent = transform;
	
		poolInstances.Add(clone);

		return clone;
	}

	public RecycleGameObjects NextObject(Vector3 pos)
	{
		RecycleGameObjects instance = null;

		foreach (var go in poolInstances) {
			if (go.gameObject.activeSelf != true) {
				instance = go;
				instance.transform.position = pos;
			}
		}
		if(instance == null)
			instance = CreateInstance (pos);

		instance.Restart ();

		return instance;
	}
}
