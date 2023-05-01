using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class LaunchProjectile : MonoBehaviour
{
    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 500.0f;

    public int ammo = 10;
    public GameObject ammoCounter = null;
    public AudioClip launchSound = null;
    public AudioClip emptySound = null;

    public void Fire()
    {
        if(ammo > 0)
        {
            GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);

            if (newObject.TryGetComponent(out Rigidbody rigidBody))
            {
                ApplyForce(rigidBody);
            }

            gameObject.GetComponent<AudioSource>().PlayOneShot(launchSound);

            ammo--;
            ammoCounter.GetComponent<TextMeshProUGUI>().SetText("Ammo:" + "\n" + ammo);       
        }
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(emptySound);
        }
        
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = startPoint.forward * launchSpeed;
        rigidBody.AddForce(force);
    }
}
