using System.Collections;
using UnityEngine;

namespace Light2D.Examples {
    public class PlayerFollow : MonoBehaviour {
        public GameObject player;

        private void LateUpdate () {
            Vector3 pos = player.transform.position;
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }
}