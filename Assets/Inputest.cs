using UnityEngine;
using UnityEngine.EventSystems;

public class InputTester : MonoBehaviour
{
    void Update()
    {
        bool tap = false;

        if (Input.GetKeyDown(KeyCode.Space)) tap = true;
        if (Input.GetMouseButtonDown(0)) tap = true;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            tap = true;

        if (tap)
            Debug.Log("Input detected!");
    }
}
