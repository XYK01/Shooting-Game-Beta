using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public LayerMask shootableLayers;

    public Button fireButton;
    public GameObject muzzleFlashPrefab;
    public Transform muzzlePoint;

    void Start()
    {
        fireButton.onClick.AddListener(Shoot);
    }

    void Shoot()
    {
        if (muzzleFlashPrefab && muzzlePoint)
        {
            GameObject flash = Instantiate(muzzleFlashPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Destroy(flash, 0.5f);
        }

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, range, shootableLayers))
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }
}
