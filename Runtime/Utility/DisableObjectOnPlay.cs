using UnityEngine;

namespace GG.Core
{
	public class DisableObjectOnPlay : MonoBehaviour {

		// Use this for initialization
		void Start () {
			gameObject.SetActive (false);
		}
	}
}
