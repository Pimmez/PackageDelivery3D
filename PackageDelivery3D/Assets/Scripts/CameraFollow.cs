using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform objectToFollow;
	[SerializeField] private float damping = 2f;
	[SerializeField] private Vector3 offset = Vector3.zero;

	private void Update()
    {
		CameraLerp();
    }

	private void CameraLerp()
	{
		float _interpolation = damping * Time.deltaTime;

		Vector3 position = this.transform.position;

		position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.position.x, _interpolation);
		//position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.position.y, _interpolation);
		position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.position.z + offset.z, _interpolation);

		this.transform.position = position;
	}
}