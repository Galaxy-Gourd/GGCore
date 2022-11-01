using System.Collections;
using UnityEngine;

namespace GG.Core
{
	public class SineHover : MonoBehaviour 
	{
		#region enum 

		public enum HoverAxis { X, Y, Z }
	
		#endregion 


		#region Variables 

		#region Public 

		[Header ("Values")]
		public HoverAxis axis = HoverAxis.Y;
		public float hoverStrength;
		public float hoverSpeed;

		#endregion 

		#region Private 

		private Vector3 _originalPos;

		#endregion 

		#endregion 


		#region Hover 

		// Hover
		IEnumerator HoverTick ()
		{
			while (true)
			{
				switch (axis)
				{
					case HoverAxis.X:
						transform.position = new Vector3 (_originalPos.x + (Mathf.Sin (Time.time * hoverSpeed) * hoverStrength), transform.position.y, transform.position.z);
						break;
					case HoverAxis.Y:
						transform.position = new Vector3 (transform.position.x, _originalPos.y + (Mathf.Sin (Time.time * hoverSpeed) * hoverStrength), transform.position.z);
						break;
					case HoverAxis.Z:
						transform.position = new Vector3 (transform.position.x, transform.position.y, _originalPos.z + (Mathf.Sin (Time.time * hoverSpeed) * hoverStrength));
						break;
				}
			
				yield return null;
			}
		}

		#endregion 


		#region Enable 

		void OnEnable ()
		{
			_originalPos = transform.position;
			StartCoroutine ("HoverTick");
		}


		void OnDisable ()
		{
			StopCoroutine ("HoverTick");
		}

		#endregion 
	}
}
