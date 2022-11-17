using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    
	public PlayerController playerController;
	public GameObject RestartPanel;
	Vector3 PlayerStartPos;
	public GameObject speedBoosterIcon;

	private void Start()
	{
		PlayerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		speedBoosterIcon.SetActive(false);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag("finish"))
		{
			playerController.runningSpeed = 0f;
			transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
			RestartPanel.SetActive(true);
		}
		if (other.CompareTag("speedboost"))
		{
			playerController.runningSpeed = playerController.runningSpeed + 3f;
			speedBoosterIcon.SetActive(true);
			StartCoroutine(SlowAfterAWhileCoroutine());
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("obstacle"))
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			transform.position = PlayerStartPos;
		}
	}

	private IEnumerator SlowAfterAWhileCoroutine()
	{
		yield return new WaitForSeconds(2.0f);
		playerController.runningSpeed = playerController.runningSpeed - 3f;
		speedBoosterIcon.SetActive(false);
	}

}
