using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D ball_rigidbody;
    public Rigidbody2D connection_point;
    public SpringJoint2D springJoint;
    bool clicked = false;
    public float max_distance;
    public GameObject cine_Camera;
    public level_control control;
    public GameObject ballPrefab;
    GameObject newBall;
    bool didDismiss = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clicked){
             Vector2 mouse_position = ball_rigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             if(Vector3.Distance(mouse_position,connection_point.position) > max_distance){
                 ball_rigidbody.position = connection_point.position + (mouse_position-connection_point.position).normalized * max_distance;

             }else{
                 ball_rigidbody.position = mouse_position;
             }
        }
        
       
        
    }

    
    void OnMouseDown()
    {
        if(didDismiss){
            return;
        }
        clicked = true;
        ball_rigidbody.isKinematic = true;
        cine_Camera.SetActive(false); 
    }
        void OnMouseUp()
    {
    
        if(didDismiss){
            return;
        }
        clicked = false;
        ball_rigidbody.isKinematic = false;
        didDismiss = true;
        cine_Camera.SetActive(true); 
        release();
        Destroy(gameObject, 4f);
        StartCoroutine(createBall());

    }
    void release(){
        
        Destroy(GetComponent<SpringJoint2D>(),0.04f);
    }
    void OnDestroy() {
        
        control.ballNum --;
        if(control.ballNum  > 0){
            
            Cinemachine.CinemachineVirtualCamera virtualCamera = GameObject.Find("CM vcam1").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            virtualCamera.Follow = newBall.transform;
            
            
        }
        

        
        
        
    }
    IEnumerator createBall(){
        yield return new WaitForSeconds(3.0f);
        if(control.ballNum > 0){
            newBall = Instantiate(ballPrefab,connection_point.position,new Quaternion());
            newBall.AddComponent<SpringJoint2D>().connectedBody = connection_point;
            springJoint = newBall.GetComponent<SpringJoint2D>();
            springJoint.frequency = 5;
            springJoint.dampingRatio = 1;
        }

    }
}
