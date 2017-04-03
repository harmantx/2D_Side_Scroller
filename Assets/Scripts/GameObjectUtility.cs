using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtility {

	private static Dictionary<RecycleGameObjects, ObjectPool> pools = new Dictionary<RecycleGameObjects, ObjectPool>();



	public static GameObject Instantiate(GameObject prefab, Vector3 pos)
	{
		GameObject instance = null;

		var recycledGameObject = prefab.GetComponent<RecycleGameObjects> ();
		if (recycledGameObject != null)
		{
			var pool = GetObjectPools(recycledGameObject);
			instance = pool.NextObject (pos).gameObject;
		} else 
		{
			instance = GameObject.Instantiate(prefab);
			instance.transform.position = pos;
		}

		return instance;
	}

	public static void Destroy(GameObject gameObject)
	{

		var recycleGameObject = gameObject.GetComponent<RecycleGameObjects> ();

		if (recycleGameObject != null) {
			recycleGameObject.Shutdown ();
		} else 
		{
			GameObject.Destroy (gameObject);
		}
	
	
	}

	private static ObjectPool GetObjectPools(RecycleGameObjects reference)
	{
		ObjectPool pool = null;

		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else {
			var poolContainer = new GameObject (reference.gameObject.name + "ObjectPool");
			pool = poolContainer.AddComponent<ObjectPool> ();
			pool.prefab = reference;
			pools.Add (reference, pool);
		}

		return pool;
	}
}