using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeProjectile : MonoBehaviour
{
    [SerializeField] private float duration = 1f;  // Durasi gerakan proyektil
    [SerializeField] private AnimationCurve animCurve;  // Kurva animasi untuk tinggi proyektil
    [SerializeField] private float heightY = 3f;  // Tinggi maksimal proyektil
    [SerializeField] private GameObject grapeProjectileShadow;  // Bayangan proyektil
    [SerializeField] private GameObject splatterPrefab;  // Prefab untuk efek percikan

    private void Start()
    {
        // Pastikan PlayerController.Instance ada sebelum mengaksesnya
        if (PlayerController.Instance == null)
        {
            Debug.LogError("PlayerController.Instance is null! Cannot proceed with projectile.");
            return;  // Hentikan eksekusi jika PlayerController tidak ditemukan
        }

        // Instansiasi bayangan proyektil
        GameObject grapeShadow = Instantiate(grapeProjectileShadow, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);

        // Ambil posisi pemain
        Vector3 playerPos = PlayerController.Instance.transform.position;
        Vector3 grapeShadowStartPosition = grapeShadow.transform.position;

        // Mulai coroutine untuk gerakan proyektil dan bayangan
        StartCoroutine(ProjectileCurveRoutine(transform.position, playerPos));
        StartCoroutine(MoveGrapeShadowRoutine(grapeShadow, grapeShadowStartPosition, playerPos));
    }

    // Coroutine untuk gerakan proyektil dengan kurva animasi
    private IEnumerator ProjectileCurveRoutine(Vector3 startPosition, Vector3 endPosition)
    {
        float timePassed = 0f;

        // Gerakkan proyektil mengikuti kurva animasi
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            float heightT = animCurve.Evaluate(linearT);  // Ambil nilai dari animCurve
            float height = Mathf.Lerp(0f, heightY, heightT);

            // Posisi proyektil dengan gerakan melengkung
            transform.position = Vector2.Lerp(startPosition, endPosition, linearT) + new Vector2(0f, height);

            yield return null;
        }

        // Setelah proyektil sampai, instansiasi efek percikan
        Instantiate(splatterPrefab, transform.position, Quaternion.identity);

        // Hancurkan proyektil
        Destroy(gameObject);
    }

    // Coroutine untuk gerakan bayangan proyektil
    private IEnumerator MoveGrapeShadowRoutine(GameObject grapeShadow, Vector3 startPosition, Vector3 endPosition)
    {
        float timePassed = 0f;

        // Gerakkan bayangan proyektil
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            grapeShadow.transform.position = Vector2.Lerp(startPosition, endPosition, linearT);
            yield return null;
        }

        // Hancurkan bayangan setelah selesai
        Destroy(grapeShadow);
    }
}
