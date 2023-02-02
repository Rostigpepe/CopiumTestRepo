using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDEATH : MonoBehaviour
{
    [SerializeField] private float despawnDistance = 200f;

    private void Start()
    {
        StartCoroutine(BulletCleaner(gameObject.transform.position, despawnDistance));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Actor actor = collision.gameObject.GetComponent<Actor>();

        if (actor)
        {
            collision.gameObject.GetComponent<Actor>().TakeDamange(5);
            StopAllCoroutines();
            Destroy(gameObject);StopAllCoroutines();
            Destroy(gameObject);
        }
        //Instant death
        //Destroy(collision.gameObject);
    }

    private IEnumerator BulletCleaner(Vector3 startPos, float despawnDistance)
    {
        while (Vector3.Distance(transform.position, startPos) < despawnDistance)
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

}
