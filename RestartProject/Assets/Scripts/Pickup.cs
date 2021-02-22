using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace _Complete
{
    public class Pickup : MonoBehaviour
    {

        private int coinCount;
        public TextMeshProUGUI coinText;
        public AudioClip coinSound;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("coin"))
            {
                AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
                coinCount++;
                coinText.text = coinCount.ToString();
                Destroy(other.gameObject);

            }
        }

    }
}
