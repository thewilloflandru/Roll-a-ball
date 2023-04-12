using UnityEngine;
using System.Collections;

// NOTES:
// this object has been turned into a unity prefab
// an asset that contains a template or blueprint of a GameObject's family
// can use prefabs in any scene in current project
// IOW can make chances to prefab asset itself or any instance to propogate to all 
public class Rotator : MonoBehaviour
{

	// Before rendering each frame..
	void Update()
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.

		// deltaTime is a float representing the difference in seconds since the last frame update occurred
		// so IOW using deltaTime helps ensure this rotation is dynamically matched to frame lengths 
		// which could vary based on performance

		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
