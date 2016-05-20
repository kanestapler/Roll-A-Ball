using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;
	private int numberOfPickUps = 12;
	public float speed;
	public Text countText;
	public Text winText;


	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void FixedUpdate() {
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (movementHorizontal, 0, movementVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
			checkIfWonAndDisplayMessage ();
		}
	}

	private void setCountText() {
		countText.text = "Count: " + count.ToString ();
	}

	private void checkIfWonAndDisplayMessage() {
		if (count == numberOfPickUps) {
			winText.text = "You Win!";
		}
	}
}
