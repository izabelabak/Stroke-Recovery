using UnityEngine;
using System.Collections;

public class Interact_Script : MonoBehaviour {
    public float Distance = 5f;
    public Canvas GameSentence;
   
    void Update ()
    {
        Cursor.visible = true;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance))
            {
                if (hit.collider.CompareTag("door"))
                {
                    hit.collider.transform.parent.GetComponent<Door_script>().ChangeDoorState();
                }
            }
        }

    }
}
