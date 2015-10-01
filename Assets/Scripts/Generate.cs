using UnityEngine;

public class Generate : MonoBehaviour
{
	public GameObject obstacle;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, 50f);
	}

	void CreateObstacle()
	{
		Instantiate(obstacle);
	}
}