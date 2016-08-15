using UnityEngine;
using System.Collections;
  
public class CameraSmoothFollow : MonoBehaviour {

	public GameObject target;
	public float MaxLeftPos;
	public float MaxRightPos;
	public Vector3 targetPos;

	private float delta;
    private Vector3 offset = new Vector3(0,.13f,0);

     void Update() {
         if (target) {

             Vector3 pos = transform.position;
             pos.z = target.transform.position.z;

             //target follow
             Vector3 targetDirection = (target.transform.position - pos);
             delta = targetDirection.magnitude * 5f;
             targetPos = transform.position + (targetDirection.normalized * delta * Time.deltaTime); 

             //clamp values
             targetPos = new Vector3(Mathf.Clamp(targetPos.x, MaxLeftPos, MaxRightPos), targetPos.y, targetPos.z);

             //move camera
             transform.position = Vector3.Lerp( transform.position, targetPos + offset, .3f);
         }
     }
 }