using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador
    void Update()
    {
        // Obtener la entrada del usuario para moverse horizontal y verticalmente
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula el desplazamiento en función de la entrada y la velocidad
        float horizontalMovement = moveHorizontal * speed * Time.deltaTime;
        float verticalMovement = moveVertical * speed * Time.deltaTime;

        // Mueve el objeto en el plano horizontal y vertical (en 2D)
        transform.Translate(new Vector2(horizontalMovement, verticalMovement));
        
    }

}
