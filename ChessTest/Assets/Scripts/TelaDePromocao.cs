using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaDePromocao : MonoBehaviour
{
    BoxCollider2D bc;
    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    
}
