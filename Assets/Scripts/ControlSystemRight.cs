using UnityEngine;
using System.Collections;

public class ControlSystemRight : MonoBehaviour {

	public GameObject cell;

	// Use this for initialization
	void Start () {
	
	}

	bool isPressed( SteamVR_Controller.DeviceRelation rel, ulong button){
		if (SteamVR_Controller.GetDeviceIndex(rel) >= 0 && SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(rel)) != null)
			return SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(rel)).GetPress(button);
		else
			return false;
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("left")) {
			
		}
		/*else if (Input.GetKey("right")) {
			for (int i = 0; i < buttons.Length; i++) {
				buttons [i].transform.localScale = new Vector3(buttons[i].transform.localScale.x, .1f, buttons[i].transform.localScale.z);
			}
			fastForward.transform.localScale = new Vector3(fastForward.transform.localScale.x, .0001f, fastForward.transform.localScale.z);
		}*/
		else if (Input.GetKey("up")) {

		}
		else if (Input.GetKey("down")) {
			
		}

		if (isPressed (SteamVR_Controller.DeviceRelation.Rightmost, SteamVR_Controller.ButtonMask.Trigger)) {

			print ("UP");
			cell.transform.localScale += new Vector3 (.0001F, .0001F, .0001F); 

		}

		if(isPressed ( SteamVR_Controller.DeviceRelation.Rightmost, SteamVR_Controller.ButtonMask.Touchpad )){


			Vector2 PadButton = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)).GetAxis();


			//UP
			if (PadButton.y > .4 && PadButton.x < .4) {
				print ("UP");
				cell.transform.position -= new Vector3 (0, .001F, 0); 

			
			}
			//DOWN
			else if (PadButton.y < (-.4) && Mathf.Abs (PadButton.x) < .4) {
				print ("DOWN");

				cell.transform.position += new Vector3 (0, .001F, 0);  

			}

			else if (PadButton.x < (-.5) && Mathf.Abs(PadButton.y) < .5) {
				print ("LEFT");

				cell.transform.position -= new Vector3 (0, 0, .001f); 
			}
			//RIGHT
			else if (PadButton.x > .5 && Mathf.Abs(PadButton.y) < .5) {
				print ("Right");

				cell.transform.position += new Vector3 (0, 0, .001f);  
			}
		}
		
	}
}
