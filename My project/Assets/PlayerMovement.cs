using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    private Vector3 velocidad = Vector3.zero;
    public float velocidadDeMovimiento;
    public float suavizadoDeMovimiento;


    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();

    }

    private void Update() {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
    }

    private void FixedUpdate() {
        Mover(movimientoHorizontal * Time.fixedDeltaTime);   
    }

    private void Mover(float mover) {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

       
    }
}
