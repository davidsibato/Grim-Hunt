using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 1.0f;
        public Vector2 maxPositon;
        public Vector2 minposition;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            targetPos.x = Mathf.Clamp(targetPos.x, minposition.x, maxPositon.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minposition.y, maxPositon.y);
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        } 

    }

