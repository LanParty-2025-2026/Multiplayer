using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float moveSpeed = 5f;
    public LayerMask solidObjectsLayer; // Trascina qui il layer SolidObjects nell'Inspector
    
    private bool isMoving;
    private Vector2 input;

    void Update() {
        if (!isMoving) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0; // Impedisce diagonali

            if (input != Vector2.zero) {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // Controlla se la posizione target è libera
                if (IsWalkable(targetPos)) {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
    }

    IEnumerator Move(Vector3 targetPos) {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos) {
        // Crea un piccolo cerchio immaginario sulla casella target. 
        // Se tocca qualcosa nel layer solidObjectsLayer, restituisce false.
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) == null;
    }
}