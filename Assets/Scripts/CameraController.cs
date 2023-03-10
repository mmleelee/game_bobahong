using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float vSpeed;
    [SerializeField] private float hSpeed;

    private float currentPosY;
    private Vector3 velocity = Vector3.zero;

    //follow player
    [SerializeField] private Transform player;

    private void Update () {
        
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x + hSpeed, transform.position.y, transform.position.z), ref velocity, vSpeed);

        //var cameraPosition = Camera.main.gameObject.transform.position;
        // cameraPosition.x += speed;
        // cameraPosition.y = player.position.y;
        // Camera.main.gameObject.transform.position = cameraPosition;
        
        if(StartingPoint.isStart) {
            if (Straw.isInStraw) {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x + hSpeed, transform.position.y, transform.position.z), ref velocity, vSpeed);
            } else {
                
                if (player.position.y > 0) {
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x + hSpeed, player.position.y, transform.position.z), ref velocity, vSpeed);
                } else {
                    transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x + hSpeed, 0, transform.position.z), ref velocity, vSpeed);
                }
            }
        }
    }
}
