using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public GameObject objectToHide;
    public GameObject playerObject;

    private int hasBeen = 0; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            if(hasBeen > 0)
            {
                hasBeen++;
            }
            if(objectToHide.activeSelf != true)
            {
                objectToHide.SetActive(true);
                hasBeen++;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            if(hasBeen > 1)
            {
                objectToHide.SetActive(false);
                hasBeen = 0;
            }
        }
    }
}
