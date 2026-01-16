using UnityEngine;
using UnityEngine.ImputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 1f;
    private float horizontalMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext Context){
        var movementVector = Context.ReadValue<Vector2>();
        horizontalMovement = movementVec.x;

        Debug.log()
    }
}
